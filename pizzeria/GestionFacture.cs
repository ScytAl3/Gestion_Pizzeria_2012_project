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
    public partial class GestionFacture : Form
    {
        #region "Déclaration des variables utilisées dans cette Form"
        //Déclaration des variables
        string sqlDtg;
        string dateJour;
        //Variables utilisées pour afficher le bon de détail de la facture
        string numFac;
        string dateFac;
        DateTime date;
        string typeCde;
        string mntFacture;
        int numClient;
        string nomClient;
        string telClient;
        string sqlAdresse;
        string adrClient;
        string cpClient;
        string villeClient;
        string commAdr;
        //Variables utilisées pour les calculs de TVA
        string sqlPremTva;
        string totalPremTva;
        decimal premTva;
        decimal tauxPremTva = Convert.ToDecimal("1,07");
        decimal mntPremTva;
        string sqlDeuxTva;
        string totalDeuxTva;
        decimal deuxTva;
        decimal tauxDeuxTva = Convert.ToDecimal("1,196");
        decimal mntDeuxTva;
        #endregion

        public GestionFacture()
        {
            InitializeComponent();
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Traitement lors du chargement de la page
        //Chargement du DataGridView à la date du jour,avec les colonnes que l'on désire afficher
        private void GestionFacture_Load(object sender, EventArgs e)
        {
            dateJour = DateTime.Now.ToString("yyyy-MM-dd");
            dtgFactureLoad();  
        }

        //Chargement du DataGridView
        private void dtgFactureLoad()
        {
            sqlDtg = "SELECT f.NumFacture, f.DateFacture, c.TypeCommande, f.MntFacture, f.EtatFacure, f.NumClient, x.NomClient, x.TelClient";
            sqlDtg += " FROM  Facture f, Commande c, Client x";
            sqlDtg += " WHERE f.NumClient = x.NumClient";
            sqlDtg += " AND f.NumFacture = c.NumCommande";
            sqlDtg += " AND f.DateFacture = '" + dateJour + "'";
            fonctions.OuvrirConnection();
            if (fonctions.Existe(sqlDtg))
            {
                fonctions.FermerConnection();
                try
                { formeDtgFacture(sqlDtg); }
                catch (MySqlException ex)
                { lblMessage.Text = ex.Message; }
            }
            else
            { dtgFacture.DataSource = null; dtgFacture.Refresh(); }
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

        //Mise en forme du DataGridView facture en indiquant la largeur des colonnes que l'on désir afficher
        private void formeDtgFacture(string requete)
        {
            chargeDtg(sqlDtg, dtgFacture);
            dtgFacture.Columns[0].Width = 60;
            dtgFacture.Columns[1].Width = 100;
            dtgFacture.Columns[2].Width = 60;
            dtgFacture.Columns[3].Width = 100;
            dtgFacture.Columns[4].Width = 100;            
            dtgFacture.Columns[5].Visible = false;
            dtgFacture.Columns[6].Width = 100;
            dtgFacture.Columns[7].Width = 100;
            dtgFacture.Width = 620 + 60;
        }

        //Traitement pour afficher les factures à une date données
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            dateJour = dtpDate.Value.ToString("yyyy-MM-dd"); 
            dtgFactureLoad();
        }

        #region "Traitement pour les calculs de TVA"
        //Traitement pour le calcul de la TVA à 7%
        private void totalPremiereTva()
        {
            sqlPremTva = "SELECT SUM(ROUND((l.QuantiteCDE * a.PrixTTC_Article), 2)) AS total";
            sqlPremTva += " FROM Commande cd, Ligne_commande l, Article a, tva t";
            sqlPremTva += " WHERE cd.NumCommande = l.NumCommande";
            sqlPremTva += " AND l.CodeArticle = a.CodeArticle";
            sqlPremTva += " AND a.CodeTVA = t.CodeTVA";
            sqlPremTva += " AND a.CodeTVA = 1";
            sqlPremTva += " AND cd.NumCommande = " + numFac.ToString();

            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ",";
            provider.NumberGroupSeparator = ".";

            fonctions.OuvrirConnection();
            if (fonctions.Existe(sqlPremTva))
            {
                fonctions.FermerConnection();
                try
                {
                    fonctions.OuvrirConnection();
                    MySqlDataReader myReader = fonctions.Lire(sqlPremTva);
                    myReader.Read();
                    totalPremTva = (myReader.GetValue(0).ToString());
                    fonctions.FermerConnection();
                }
                catch (Exception ex)
                { lblMessage.Text = "Load_TotalTVA_7% : " + ex.Message; fonctions.FermerConnection(); }
            }
            if (!string.IsNullOrEmpty(totalPremTva))
            {
                premTva = Convert.ToDecimal(totalPremTva, provider);
                mntPremTva = (premTva - (premTva / tauxPremTva));
                //tbxPremTva.Text = mntPremTva.ToString("0.00");
            }
        }

        //Traitement pour le calcul de la TVA à 19,6%
        private void totalDeuxiemeTva()
        {
            sqlDeuxTva = "SELECT SUM(ROUND((l.QuantiteCDE * a.PrixTTC_Article), 2)) AS total";
            sqlDeuxTva += " FROM Commande cd, Ligne_commande l, Article a, tva t";
            sqlDeuxTva += " WHERE cd.NumCommande = l.NumCommande";
            sqlDeuxTva += " AND l.CodeArticle = a.CodeArticle";
            sqlDeuxTva += " AND a.CodeTVA = t.CodeTVA";
            sqlDeuxTva += " AND a.CodeTVA = 2";
            sqlDeuxTva += " AND cd.NumCommande = " + numFac.ToString();

            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
            provider.NumberDecimalSeparator = ",";
            provider.NumberGroupSeparator = ".";

            fonctions.OuvrirConnection();
            if (fonctions.Existe(sqlDeuxTva))
            {
                fonctions.FermerConnection();
                try
                {
                    fonctions.OuvrirConnection();
                    MySqlDataReader myReader = fonctions.Lire(sqlDeuxTva);
                    myReader.Read();
                    totalDeuxTva = (myReader.GetValue(0).ToString());
                    fonctions.FermerConnection();
                }
                catch (Exception ex)
                { lblMessage.Text = "Load_TotalTVA_19,6% : " + ex.Message; fonctions.FermerConnection(); }
            }
            if (!string.IsNullOrEmpty(totalDeuxTva))
            {
                deuxTva = Convert.ToDecimal(totalDeuxTva, provider);
                mntDeuxTva = (deuxTva - (deuxTva / tauxDeuxTva));
                //tbxDeuxTva.Text = mntDeuxTva.ToString("0.00");
            }
        }
        #endregion

        //Traitement pour afficher le détail de la facture d'une commande
        private void btnEditerFacture_Click(object sender, EventArgs e)
        {
            lbxDetailFacture.Items.Clear();

            if (dtgFacture.SelectedRows.Count != 1)
            { MessageBox.Show("Veuillez selectionner une ligne et une seule!"); return; }
             //On récupère le numéro de la ligne du DataGridView
            int i = dtgFacture.CurrentCell.RowIndex;
            numFac = dtgFacture.Rows[i].Cells[0].Value.ToString();
            date = Convert.ToDateTime(dtgFacture.Rows[i].Cells[1].Value.ToString()); dateFac = date.ToString("dd-MM-yyyy");
            typeCde = dtgFacture.Rows[i].Cells[2].Value.ToString();
            mntFacture = dtgFacture.Rows[i].Cells[3].Value.ToString();
            numClient = int.Parse(dtgFacture.Rows[i].Cells[5].Value.ToString());
            nomClient = dtgFacture.Rows[i].Cells[6].Value.ToString();
            telClient = dtgFacture.Rows[i].Cells[7].Value.ToString();

            lbxDetailFacture.Items.Add("Facture n°: " + numFac + "\t\t" + dateFac);
            lbxDetailFacture.Items.Add("\n\n");
            lbxDetailFacture.Items.Add("\t" + "L'ARTISAN PIZZAIOLO");
            lbxDetailFacture.Items.Add("\t" + "18b, Boulevard Maginot");
            lbxDetailFacture.Items.Add("\t" + "03.87.17.05.31");
            lbxDetailFacture.Items.Add("\n\n");

            lbxDetailFacture.Items.Add("Nom du client: " + nomClient + "\t" + telClient);

            Regex rgTypeLivraison = new Regex("Livraison");
            if (rgTypeLivraison.IsMatch(typeCde))
            {
                try
                {
                    sqlAdresse = " SELECT AdresseClient, CPClient, VilleClient, PrecisionAdresse";
                    sqlAdresse += " FROM Client";
                    sqlAdresse += " WHERE NumClient = " + numClient;
                    fonctions.OuvrirConnection();
                    MySqlDataReader myReader = fonctions.Lire(sqlAdresse);
                    myReader.Read();
                    adrClient = myReader.GetValue(0).ToString();
                    cpClient = myReader.GetValue(1).ToString();
                    villeClient = myReader.GetValue(2).ToString();
                    commAdr = myReader.GetValue(3).ToString();
                    fonctions.FermerConnection();
                }
                catch (Exception ex)
                { lblMessage.Text = "Load_Adresse_Facture : " + ex.Message; fonctions.FermerConnection(); }
                lbxDetailFacture.Items.Add(adrClient);
                lbxDetailFacture.Items.Add(cpClient + "\t" + villeClient);
                lbxDetailFacture.Items.Add(commAdr);                
            }
            lbxDetailFacture.Items.Add("\n\n");
            lbxDetailFacture.Items.Add("Qté" + "\t" + "Article" + "\t\t" + "Prix" + "\t" + "Total");
            lbxDetailFacture.Items.Add("\n");
            //On recupère la quantité d'article, le prix unitaire, le prix total par quantité d'article commandée
            string select = "SELECT lc.QuantiteCde, a.LibArticle, a.PrixTTC_Article, round(lc.QuantiteCde * a.PrixTTC_Article, 2) as total";
            string from = " FROM Ligne_commande lc, Article a";
            string where = " WHERE lc.CodeArticle = a.CodeArticle";
            where += " AND lc.NumCommande = " + numFac.ToString();

            string requete = select + from + where;
            fonctions.OuvrirConnection();
            MySqlDataReader myReaderArt = fonctions.Lire(requete);
            while (myReaderArt.Read())
            {
                string quantite = myReaderArt.GetValue(0).ToString();
                string libArt = myReaderArt.GetValue(1).ToString();
                string pUnit = myReaderArt.GetValue(2).ToString();
                string total = myReaderArt.GetValue(3).ToString();

                if (libArt.Length < 10)
                { lbxDetailFacture.Items.Add(quantite + "\t" + libArt + "\t\t" + pUnit + "\t" + total); }
                else if (libArt.Length > 16)
                { lbxDetailFacture.Items.Add(quantite + "\t" + libArt  + pUnit + "\t" + total); }
                else
                { lbxDetailFacture.Items.Add(quantite + "\t" + libArt + "\t" + pUnit + "\t" + total); }
            }
            //On récupère le montant des diffèrentes TVA
            totalPremiereTva();
            totalDeuxiemeTva();

            lbxDetailFacture.Items.Add("\n\n");
            lbxDetailFacture.Items.Add("Dont TVA à 7% : " + "\t\t" + mntPremTva.ToString("0.00"));
            lbxDetailFacture.Items.Add("Dont TVA à 19,6% : " + "\t" + mntDeuxTva.ToString("0.00"));
            lbxDetailFacture.Items.Add("\n");
            lbxDetailFacture.Items.Add("Pour un montant total de : " + "\t" + mntFacture);
        }
    }
}
