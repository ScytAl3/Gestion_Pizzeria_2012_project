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

namespace pizzeria
{
    public partial class GestionClient : Form
    {       
        public GestionClient()
        {
            InitializeComponent();
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Traitement de la requête pour selectionner les colonnes à afficher, au chargement de la forme
        private void GestionClient_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            dtgClientLoad();
        }

        //Chargement du DataGridView
        private void dtgClientLoad()
        {
            string requete = "SELECT * FROM client ORDER BY numClient";
            try
            { formeDtgClient(requete); }
            catch (MySqlException ex)
            { lblMessage.Text = ex.Message; }
        }

        //Fonction commune de chargement du DataGridView
        private void chargeDtg(string requete, DataGridView dtg)
        {
            try
            {
                fonctions.OuvrirConnection();
                dtg.DataSource = fonctions.Adapt(requete);
                fonctions.FermerConnection();
            }
            catch (MySqlException ex)
            { MessageBox.Show("Erreur de chargement du DataGridView! " + ex.Message); }
        }

        //Mise en forme du DataGridView en indiquant la largeur des colonnes que l'on désir afficher
        private void formeDtgClient(string requete)
        {
            chargeDtg(requete, dtgClient);
            dtgClient.Columns[0].Width = 40;
            dtgClient.Columns[1].Width = 100;
            dtgClient.Columns[2].Width = 100;
            dtgClient.Columns[3].Width = 150;
            dtgClient.Columns[4].Width = 50;
            dtgClient.Columns[5].Width = 100;
            dtgClient.Columns[6].Width = 100;
            dtgClient.Columns[7].Width = 100;
            dtgClient.Columns[8].Width = 100;
            dtgClient.Columns[8].Width = 100;
            dtgClient.Width = 940 + 60;
        }

        //Modification dynamique du DataGridView en fonction des lettres saisies dans la textbox nom du client
        private void tbxRecherNom_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            try
            {
                string masque = "'" + tbxRecherNom.Text.ToUpper() + "%'";
                string sql = "SELECT * FROM client ";
                if (tbxRecherNom.Text.Length > 0)
                { sql += "WHERE nomclient LIKE " + masque; }
                sql += " ORDER BY nomclient";
                formeDtgClient(sql);
            }
            catch (MySqlException ex)
            { lblMessage.Text = ex.Message; }
        }

        //Modification dynamique du DataGridView en fonction des chiffres saisis dans la textbox numéro de téléphone
        private void tbxRecherTel_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            try
            {
                string masque = "'" + tbxRecherTel.Text + "%'";
                string sql = "SELECT * FROM client ";
                if (tbxRecherTel.Text.Length > 0)
                { sql += "WHERE telclient LIKE " + masque; }
                sql += " ORDER BY telclient";
                formeDtgClient(sql);
            }
            catch (MySqlException ex)
            { lblMessage.Text = ex.Message; }
        }

        //Modification dynamique du DataGrid en fonction des champs de recherche
        private void modifDynamique()
        {
            try
            {
                string masqueNom = "'" + tbxRecherNom.Text.ToUpper() + "%'";
                string masqueTel = "'" + tbxRecherTel.Text + "%'";
                string requete = "SELECT * FROM client ";
                if ((tbxRecherNom.Text.Length > 0) || (tbxRecherTel.Text.Length > 0))
                {
                    requete += " WHERE nomclient LIKE " + masqueNom;
                    requete += " AND telclient LIKE " + masqueTel;
                }
                requete += " ORDER BY numClient";
                formeDtgClient(requete);
            }
            catch (MySqlException ex)
            { lblMessage.Text = "Retour Création Client " + ex.Message; }
        }

        //Traitement pour ajouter un nouveau client par l'apppel d'une nouvelle forme
        private void btnAjouClient_Click(object sender, EventArgs e)
        {
            AjouterClient ecranAjout = new AjouterClient();
            ecranAjout.ShowDialog();           
            modifDynamique();            
        }

        //Traitement pour modifier la fiche d'un client après selection de la ligne dans le DataGrid
        private void btnModifClient_Click(object sender, EventArgs e)
        {
            if (dtgClient.SelectedRows.Count != 1)
            { lblMessage.Text = "Veuillez selectionner une ligne et une seule!"; return; }
            lblMessage.Text = "";
            // On récupère le numéro de la ligne et le numéro client (numClient) dans la première cellule
            int i = dtgClient.CurrentCell.RowIndex;
            ModifierClient ecranModif = new ModifierClient();
            ecranModif.V_numClient = Decimal.Parse(dtgClient.Rows[i].Cells[0].Value.ToString());
            ecranModif.ShowDialog();
            modifDynamique();
        }

        //Traitement pour la suppression de la fiche d'un client après selection de la ligne dans le DataGrid
        private void btnSuppClient_Click(object sender, EventArgs e)
        {
            if (dtgClient.SelectedRows.Count != 1)
            { lblMessage.Text = "Veuillez selectionner une ligne et une seule!"; return; }
            lblMessage.Text = "";
            // On récupère le numéro de la ligne et le numéro client (numClient) dans la première cellule
            int i = dtgClient.CurrentCell.RowIndex;
            Decimal numClient = decimal.Parse(dtgClient.Rows[i].Cells[0].Value.ToString());
            DialogResult resultat = MessageBox.Show("Êtes-vous sûr de voulior supprimer ce client définitivement?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultat == DialogResult.Yes)
            {
                try
                {
                    string table = "client";
                    string where = " numClient = " + numClient.ToString();
                    fonctions.Supprimer(table, where);
                    modifDynamique();
                }
                catch (Exception ex)
                { lblMessage.Text = "Validation Suppréssion Client " + ex.Message; }
            }
        }

        //Traitement pour afficher le plan de localisation d'un client après sélection d'une ligne
        private void btnAffichPlan_Click(object sender, EventArgs e)
        {
            if (dtgClient.SelectedRows.Count != 1)
            { lblMessage.Text = "Veuillez selectionner une ligne et une seule!"; return; }
            lblMessage.Text = "";
            // On récupère le numéro de la ligne et le numéro client (numClient) dans la première cellule
            int i = dtgClient.CurrentCell.RowIndex;
            PlanClient ecranPlan = new PlanClient();
            ecranPlan.planClient = dtgClient.Rows[i].Cells[9].Value.ToString();
            ecranPlan.ShowDialog();
        }

        //Traitement pour passer une commande à partir d'un client (livraison) ou sans client (emporter)
        private void btnCommande_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (dtgClient.SelectedRows.Count == 1)
            {
                int i = dtgClient.CurrentCell.RowIndex;
                PasserCommande ecranCommande = new PasserCommande();
                ecranCommande.V_numClient = Int32.Parse(dtgClient.Rows[i].Cells[0].Value.ToString());
                ecranCommande.V_btnVerifTel = false;
                ecranCommande.ShowDialog();
                modifDynamique();
            }
            else
            {
                PasserCommande ecranCommande = new PasserCommande();
                ecranCommande.V_btnVerifTel = true;
                ecranCommande.ShowDialog();
                dtgClientLoad();
            }
        }
    }
}
