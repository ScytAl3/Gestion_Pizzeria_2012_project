using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace pizzeria
{
    public partial class GestionCommande : Form
    {
        #region "Déclaration des variables utilisées dans cette Form"
        //Déclaration des variables
        string sqlDtg;
        string dateJour;
        string etatCde;
        //Variables utilisées pour afficher le bon de production
        string numCde;
        string dateCde;
        DateTime date;
        string typeCde;
        string heureCde;
        string nomClientCde;
        string numTelCde;
        string sqlBonProd;
        string sqlDetailMenu;
        #endregion

        public GestionCommande()
        {
            InitializeComponent();
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Traitement lors du chargement de la page
        //Chargement du DataGridView à la date du jour,avec les colonnes que l'on désire afficher
        private void GestionCommande_Load(object sender, EventArgs e)
        {
            dateJour = DateTime.Now.ToString("yyyy-MM-dd");
            dtgCommandeLoad();
        }

        //Chargement du DataGridView
        private void dtgCommandeLoad()
        {
            sqlDtg = "SELECT c.NumCommande, c.DateCommande, c.TypeCommande, c.HeureVoulue, c.EtatCommande, c.NumClient, x.NomClient, x.TelClient, f.MntFacture";
            sqlDtg += " FROM Commande c, Client x, Facture f";
            sqlDtg += " WHERE c.NumClient = x.NumClient";
            sqlDtg += " AND c.NumCommande = f.NumFacture";
            sqlDtg += " AND c.DateCommande = '" + dateJour + "'";
            fonctions.OuvrirConnection();
            if (fonctions.Existe(sqlDtg))
            {
                fonctions.FermerConnection();
                try
                { formeDtgCommande(sqlDtg); }
                catch (MySqlException ex)
                { lblMessage.Text = ex.Message; }
            }
            else
            { dtgCommande.DataSource = null; dtgCommande.Refresh(); }
        }

        //Fonction commune de chargement du DataGridView
        private void chargeDtg(string requete, DataGridView dtg)
        {
            try
            {
                fonctions.OuvrirConnection();
                dtg.DataSource = fonctions.Adapt(sqlDtg);
                fonctions.FermerConnection();
            }
            catch (MySqlException ex)
            { MessageBox.Show("Erreur de chargement du DataGridView! " + ex.Message); }
        }

        //Mise en forme du DataGridView commande en indiquant la largeur des colonnes que l'on désir afficher
        private void formeDtgCommande(string requete)
        {
            chargeDtg(sqlDtg, dtgCommande);
            dtgCommande.Columns[0].Width = 60;
            dtgCommande.Columns[1].Width = 100;
            dtgCommande.Columns[2].Width = 100;
            dtgCommande.Columns[3].Width = 100;
            dtgCommande.Columns[4].Width = 50;
            dtgCommande.Columns[5].Visible = false;
            dtgCommande.Columns[6].Width = 150;
            dtgCommande.Columns[7].Width = 100;
            dtgCommande.Columns[8].Width = 80;
            dtgCommande.Width = 740 + 60;
        }

        //Traitement pour afficher les commandes à une date données
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            dateJour = dtpDate.Value.ToString("yyyy-MM-dd");
            dtgCommandeLoad();
            lbxBonProd.Items.Clear();
        }

        //Traitement pour passer une commande, ouvre la Form passerCommande
        //Comme il n'y a pas de sélection d'un client, le bouton '+' pour la vérification du numéro de téléphone sera visible
        private void btnPasserCmd_Click(object sender, EventArgs e)
        {
            PasserCommande ecranPassCmd = new PasserCommande();
            ecranPassCmd.V_btnVerifTel = true;
            ecranPassCmd.ShowDialog();
            dtgCommandeLoad();

        }

        //Traitement pour regler une commande, ouvre la forme reglementCommande
        //On passe les valeurs (total, numéro de commande et nom du client) de la commande sélectionnée à cette nouvelle forme
        private void btnReglerCmd_Click(object sender, EventArgs e)
        {
            if (dtgCommande.SelectedRows.Count != 1)
            { MessageBox.Show("Veuillez selectionner une ligne et une seule!"); return; }
            //On récupère le numéro de la ligne du DataGridView
            int i = dtgCommande.CurrentCell.RowIndex;
            //On contrôle que la commande n'a pas déjà été payée
            etatCde = dtgCommande.Rows[i].Cells[4].Value.ToString();
            if (etatCde == "Payée")
            { MessageBox.Show("Cette commande à déjà été soldée!"); return; }
            //Si elle n'est pas encore réglée on affiche l'écran du mode de réglement
            ReglementCommande ecranReglement = new ReglementCommande();
            ecranReglement.V_total = float.Parse(dtgCommande.Rows[i].Cells[8].Value.ToString());
            ecranReglement.V_numCde = int.Parse(dtgCommande.Rows[i].Cells[0].Value.ToString());
            ecranReglement.V_nomClient = dtgCommande.Rows[i].Cells[6].Value.ToString();
            ecranReglement.ShowDialog();
            dtgCommandeLoad();
        }

        //Traitement pour afficher le bon de production d'une commande
        private void btnEditerCmd_Click(object sender, EventArgs e)
        {
            lbxBonProd.Items.Clear();
            List<int> detailMenu = new List<int>();
            if (dtgCommande.SelectedRows.Count != 1)
            { MessageBox.Show("Veuillez selectionner une ligne et une seule!"); return; }
            //On récupère le numéro de la ligne du DataGridView
            int i = dtgCommande.CurrentCell.RowIndex;
            numCde = dtgCommande.Rows[i].Cells[0].Value.ToString();
            date = Convert.ToDateTime(dtgCommande.Rows[i].Cells[1].Value.ToString()); dateCde = date.ToString("dd-MM-yyyy");
            typeCde = dtgCommande.Rows[i].Cells[2].Value.ToString();
            heureCde = dtgCommande.Rows[i].Cells[3].Value.ToString();
            nomClientCde = dtgCommande.Rows[i].Cells[6].Value.ToString();
            numTelCde = dtgCommande.Rows[i].Cells[7].Value.ToString();


            lbxBonProd.Items.Add("Commande n°: " + numCde + "\t\t" + dateCde);
            lbxBonProd.Items.Add("Type de retrait: " + typeCde + "\t" + heureCde);
            lbxBonProd.Items.Add("Nom du client: " + nomClientCde + "\t" + numTelCde);
            lbxBonProd.Items.Add("\n\n");

            sqlBonProd = "SELECT lc.IdLigneCde, lc.QuantiteCde, a.LibArticle, lc.Commentaire";
            sqlBonProd += " FROM Commande c, Client x, ligne_commande lc, Article a";
            sqlBonProd += " WHERE c.NumClient = x.NumClient";
            sqlBonProd += " AND c.NumCommande = lc.NumCommande";
            sqlBonProd += " AND lc.CodeArticle = a.CodeArticle";
            sqlBonProd += " AND c.NumCommande = " + numCde.ToString();

            fonctions.OuvrirConnection();
            MySqlDataReader myReader = fonctions.Lire(sqlBonProd);
            while (myReader.Read())
            {
                int idLigne = int.Parse(myReader.GetValue(0).ToString());
                string quantite = myReader.GetValue(1).ToString();
                string libArt = myReader.GetValue(2).ToString();
                string comment = myReader.GetValue(3).ToString();

                lbxBonProd.Items.Add("\t" + quantite + " x " + libArt);

                if (!string.IsNullOrEmpty(comment))
                {
                    lbxBonProd.Items.Add("\t\t" + comment);
                }
                Regex rgFormule = new Regex("Classico|Classico Duo|Classico Quattro");
                if (rgFormule.IsMatch(libArt))
                { detailMenu.Add(idLigne); }
            }
            fonctions.FermerConnection();

            if (detailMenu.Count > 0)
            {
                lbxBonProd.Items.Add("\n\n"); lbxBonProd.Items.Add("Détail Menu:");

                int k = 0;
                string codeLigne = "";
                for (int j = 0; j < (detailMenu.Count - 1); j++)
                {
                    codeLigne += detailMenu[j].ToString() + ","; k = j;
                }
                if (detailMenu.Count == 1)
                { k = 0; codeLigne += detailMenu[k].ToString(); }
                else
                { k = k + 1; codeLigne += detailMenu[k].ToString(); }
                //codeLigne += detailMenu[k].ToString();
                sqlDetailMenu = "SELECT COUNT(a.LibArticle), a.LibArticle";
                sqlDetailMenu += " FROM Article a, ligne_menu lm";
                sqlDetailMenu += " WHERE lm.CodeArticleChoix = a.CodeArticle";
                sqlDetailMenu += " AND lm.IdLigneCde IN (" + codeLigne + ")";
                sqlDetailMenu += " GROUP BY a.LibArticle";

                fonctions.OuvrirConnection();
                MySqlDataReader myReaderMenu = fonctions.Lire(sqlDetailMenu);
                while (myReaderMenu.Read())
                {
                    string quantMenu = myReaderMenu.GetValue(0).ToString();
                    string libMenu = myReaderMenu.GetValue(1).ToString();

                    lbxBonProd.Items.Add(quantMenu + " x\t " + libMenu);
                }
                fonctions.FermerConnection();
            }
        }

        //Traitement pour ajouter des articles à une commande existante
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (dtgCommande.SelectedRows.Count != 1)
            { MessageBox.Show("Veuillez selectionner une ligne et une seule!"); return; }
            //On récupère le numéro de la ligne du DataGridView
            int i = dtgCommande.CurrentCell.RowIndex;
            //On contrôle que la commande n'a pas déjà été payée
            etatCde = dtgCommande.Rows[i].Cells[4].Value.ToString();
            if (etatCde == "Payée")
            { MessageBox.Show("Cette commande à déjà été soldée!"); return; }
            AjouterCommande ecranAjoutCde = new AjouterCommande();
            ecranAjoutCde.V_numCde = int.Parse(dtgCommande.Rows[i].Cells[0].Value.ToString());
            ecranAjoutCde.V_nomClient = dtgCommande.Rows[i].Cells[6].Value.ToString();
            ecranAjoutCde.ShowDialog();
            dtgCommandeLoad(); lbxBonProd.Items.Clear();
        }
    }
}

