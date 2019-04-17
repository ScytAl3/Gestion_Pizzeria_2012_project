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
    public partial class GestionReglement : Form
    {
        #region "Déclaration des variables"
        //Déclaration des variables
        string sqlDtg;
        string sqlEtat;
        string sqlRetait;
        string dateJour;
        //Variables utilisées pour le calcul total des différents types de réglement
        string sqlEspece;
        string sqlCb;
        string sqlCheque;
        string sqlCtr;
        string sqlSimply;
        //Variables utilisées pour le calcul total des diffèrents types de réglement pour la livraison
        string sqlEspLivr;
        string sqlCheqLivr;
        string sqlCtrLivr;
        string sqlSimplyLivr;
        //Variables utilisées pour le calcul total des différents types de réglement pour la vente sur place
        string sqlEspEmp;
        string sqlCbEmp;
        string sqlCheqEmp;
        string sqlCtrEmp;
        string sqlSimplyEmp;
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

        public GestionReglement()
        {
            InitializeComponent();
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Traitement lors du chargement de la page
        //Chargement du DataGridView à la date du jour,avec les colonnes que l'on désire afficher
        private void GestionReglement_Load(object sender, EventArgs e)
        {
            dateJour = DateTime.Now.ToString("yyyy-MM-dd");
            dtgTypeReglementLoad();
            etatCommande();
            etatRetrait();
            totalTypeEspece();
            totalTypeCb();
            totalTypeCheque();
            totalTypeCtr();
            totalTypeSimply();
            totalEspeceLivr();
            totalChequeLivr();
            totalCtrLivr();
            totalSimplyLivr();
            totalEspeceEmpor();
            totalCbEmpor();
            totalCheqEmpor();
            totalCtrEmpor();
            totalSimplyEmpor();
            totalPremiereTva();
            totalDeuxiemeTva();
        }

        #region "Traitement pour l'affichage du DataGridView gestion des réglements des factures"
        //Chargement du DataGridView
        private void dtgTypeReglementLoad()
        {
            sqlDtg = "SELECT f.NumFacture, cd.TypeCommande,f.DateFacture, f.MntFacture, f.EtatFacure, r.NumReglement, r.MntReglement, tr.LibTypeReglement";
            sqlDtg += " FROM facture f, commande cd, client c, ligne_reglement lr, reglement r, type_reglement tr";
            sqlDtg += " WHERE f.NumClient = c.NumClient";
            sqlDtg += " AND f.NumFacture = cd.NumCommande";
            sqlDtg += " AND f.NumFacture = lr.NumFacture";
            sqlDtg += " AND lr.NumReglement = r.NumReglement";
            sqlDtg += " AND r.IdType_Reglement = tr.IdType_Reglement";
            sqlDtg += " AND f.DateFacture LIKE '" + dateJour + "'";
            sqlDtg += " ORDER BY f.Numfacture";

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
            { dtgTypeReglement.DataSource = null; dtgTypeReglement.Refresh(); }
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
            chargeDtg(sqlDtg, dtgTypeReglement);
            dtgTypeReglement.Columns[0].Width = 60;
            dtgTypeReglement.Columns[1].Width = 130;
            dtgTypeReglement.Columns[2].Width = 100;
            dtgTypeReglement.Columns[3].Width = 100;
            dtgTypeReglement.Columns[4].Width = 100;
            dtgTypeReglement.Columns[5].Visible = false;
            dtgTypeReglement.Columns[6].Width = 100;
            dtgTypeReglement.Columns[7].Width = 100;
            dtgTypeReglement.Width = 690 + 60;
        }
        #endregion

        //Traitement pour afficher les factures à une date donnée, ou un mois donné
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (cbxRechMois.Checked == true)
            {
                dateJour = dtpDate.Value.ToString("yyyy-MM") + "%"; 
                dtgTypeReglementLoad();
                etatCommande();
                etatRetrait();
                totalTypeEspece();
                totalTypeCb();
                totalTypeCheque();
                totalTypeCtr();
                totalTypeSimply();
                totalEspeceLivr();
                totalChequeLivr();
                totalCtrLivr();
                totalSimplyLivr();
                totalEspeceEmpor();
                totalCbEmpor();
                totalCheqEmpor();
                totalCtrEmpor();
                totalSimplyEmpor();
                totalPremiereTva();
                totalDeuxiemeTva();
            }
            else if (cbxRechMois.Checked == false)
            {
                dateJour = dtpDate.Value.ToString("yyyy-MM-dd");
                dtgTypeReglementLoad();
                etatCommande();
                etatRetrait();
                totalTypeEspece();
                totalTypeCb();
                totalTypeCheque();
                totalTypeCtr();
                totalTypeSimply();
                totalEspeceLivr();
                totalChequeLivr();
                totalCtrLivr();
                totalSimplyLivr();
                totalEspeceEmpor();
                totalCbEmpor();
                totalCheqEmpor();
                totalCtrEmpor();
                totalSimplyEmpor();
                totalPremiereTva();
                totalDeuxiemeTva();
            }
        }

        //Traitement pour afficher l'état des commandes
        private void etatCommande()
        {
            lbxEtat.Items.Clear();
            sqlEtat = "SELECT count(EtatCommande), EtatCommande FROM commande";
            sqlEtat += " WHERE DateCommande LIKE '" + dateJour + "'";
            sqlEtat += " GROUP BY EtatCommande";

            fonctions.OuvrirConnection();
            if (fonctions.Existe(sqlEtat))
            {
                fonctions.FermerConnection();
                try
                {
                    fonctions.OuvrirConnection();
                    MySqlDataReader myReader = fonctions.Lire(sqlEtat);
                    while (myReader.Read())
                    {
                        lbxEtat.Items.Add(myReader[0].ToString() + " commande(s) " + myReader[1].ToString() + "(s)");
                    }
                    fonctions.FermerConnection();
                }
                catch (Exception ex)
                { lblMessage.Text = "Load_Compte_EtatCde : " + ex.Message; fonctions.FermerConnection(); }
            }
        }

        //Traitement pour afficher les modes de retrait qui ne sont pas encore soldés
        private void etatRetrait()
        {
            lbxRetrait.Items.Clear();
            sqlRetait = "SELECT COUNT(TypeCommande), TypeCommande FROM commande";
            sqlRetait += " WHERE EtatCommande = 'Non payée'";
            sqlRetait += " AND DateCommande LIKE '" + dateJour + "'";
            sqlRetait += " GROUP BY TypeCommande";

            fonctions.OuvrirConnection();
            if (fonctions.Existe(sqlEtat))
            {
                fonctions.FermerConnection();
                try
                {
                    fonctions.OuvrirConnection();
                    MySqlDataReader myReader = fonctions.Lire(sqlRetait);
                    while (myReader.Read())
                    {
                        lbxRetrait.Items.Add(myReader[0].ToString() + " commande(s) " + myReader[1].ToString());
                    }
                    fonctions.FermerConnection();
                }
                catch (Exception ex)
                { lblMessage.Text = "Load_Compte_EtatRetrait : " + ex.Message; fonctions.FermerConnection(); }
            }
        }

        #region "Traitement pour afficher le total des différents types de réglement"
        //Traitement pour afficher le total des réglements en espèces pour une journée
        private void totalTypeEspece()
        {
            sqlEspece = "SELECT SUM(ROUND( r.MntReglement, 2)) as TotalEspece";
            sqlEspece += " FROM facture f, commande cd, client c, ligne_reglement lr, reglement r, type_reglement tr";
            sqlEspece += " WHERE f.NumClient = c.NumClient";
            sqlEspece += " AND f.NumFacture = cd.NumCommande";
            sqlEspece += " AND f.NumFacture = lr.NumFacture";
            sqlEspece += " AND lr.NumReglement = r.NumReglement";
            sqlEspece += " AND r.IdType_Reglement = tr.IdType_Reglement";
            sqlEspece += " AND tr.IdType_Reglement = 1";
            sqlEspece += " AND f.DateFacture LIKE '" + dateJour + "'";

            fonctions.OuvrirConnection();
            if (fonctions.Existe(sqlEspece))
            {
                fonctions.FermerConnection();
                try
                {
                    fonctions.OuvrirConnection();
                    MySqlDataReader myReader = fonctions.Lire(sqlEspece);
                    myReader.Read();
                    tbxTotalEspèces.Text = myReader.GetValue(0).ToString();
                    fonctions.FermerConnection();
                }
                catch (Exception ex)
                { lblMessage.Text = "Load_TotalEspeces : " + ex.Message; fonctions.FermerConnection(); }
            }
        }

        //Traitement pour afficher le total des réglements en Cartes bancaire pour une journée
        private void totalTypeCb()
        {
            sqlCb = "SELECT SUM(ROUND( r.MntReglement, 2)) as TotalCB";
            sqlCb += " FROM facture f, commande cd, client c, ligne_reglement lr, reglement r, type_reglement tr";
            sqlCb += " WHERE f.NumClient = c.NumClient";
            sqlCb += " AND f.NumFacture = cd.NumCommande";
            sqlCb += " AND f.NumFacture = lr.NumFacture";
            sqlCb += " AND lr.NumReglement = r.NumReglement";
            sqlCb += " AND r.IdType_Reglement = tr.IdType_Reglement";
            sqlCb += " AND tr.IdType_Reglement = 2";
            sqlCb += " AND f.DateFacture LIKE '" + dateJour + "'";

            fonctions.OuvrirConnection();
            if (fonctions.Existe(sqlCb))
            {
                fonctions.FermerConnection();
                try
                {
                    fonctions.OuvrirConnection();
                    MySqlDataReader myReader = fonctions.Lire(sqlCb);
                    myReader.Read();
                    tbxTotalCb.Text = myReader.GetValue(0).ToString();
                    fonctions.FermerConnection();
                }
                catch (Exception ex)
                { lblMessage.Text = "Load_TotalCb : " + ex.Message; fonctions.FermerConnection(); }
            }
        }

        //Traitement pour afficher le total des réglements en chèques pour une journée
        private void totalTypeCheque()
        {
            sqlCheque = "SELECT SUM(ROUND( r.MntReglement, 2)) as TotalCheque";
            sqlCheque += " FROM facture f, commande cd, client c, ligne_reglement lr, reglement r, type_reglement tr";
            sqlCheque += " WHERE f.NumClient = c.NumClient";
            sqlCheque += " AND f.NumFacture = cd.NumCommande";
            sqlCheque += " AND f.NumFacture = lr.NumFacture";
            sqlCheque += " AND lr.NumReglement = r.NumReglement";
            sqlCheque += " AND r.IdType_Reglement = tr.IdType_Reglement";
            sqlCheque += " AND tr.IdType_Reglement = 3";
            sqlCheque += " AND f.DateFacture LIKE '" + dateJour + "'";

            fonctions.OuvrirConnection();
            if (fonctions.Existe(sqlCheque))
            {
                fonctions.FermerConnection();
                try
                {
                    fonctions.OuvrirConnection();
                    MySqlDataReader myReader = fonctions.Lire(sqlCheque);
                    myReader.Read();
                    tbxTotalCheque.Text = myReader.GetValue(0).ToString();
                    fonctions.FermerConnection();
                }
                catch (Exception ex)
                { lblMessage.Text = "Load_TotalCheque : " + ex.Message; fonctions.FermerConnection(); }
            }
        }

        //Traitement pour afficher le total des réglements en Tickets restaurant pour une journée
        private void totalTypeCtr()
        {
            sqlCtr = "SELECT SUM(ROUND( r.MntReglement, 2)) as TotalCTR";
            sqlCtr += " FROM facture f, commande cd, client c, ligne_reglement lr, reglement r, type_reglement tr";
            sqlCtr += " WHERE f.NumClient = c.NumClient";
            sqlCtr += " AND f.NumFacture = cd.NumCommande";
            sqlCtr += " AND f.NumFacture = lr.NumFacture";
            sqlCtr += " AND lr.NumReglement = r.NumReglement";
            sqlCtr += " AND r.IdType_Reglement = tr.IdType_Reglement";
            sqlCtr += " AND tr.IdType_Reglement = 4";
            sqlCtr += " AND f.DateFacture LIKE '" + dateJour + "'";

            fonctions.OuvrirConnection();
            if (fonctions.Existe(sqlCtr))
            {
                fonctions.FermerConnection();
                try
                {
                    fonctions.OuvrirConnection();
                    MySqlDataReader myReader = fonctions.Lire(sqlCtr);
                    myReader.Read();
                    tbxTotalCtr.Text = myReader.GetValue(0).ToString();
                    fonctions.FermerConnection();
                }
                catch (Exception ex)
                { lblMessage.Text = "Load_TotalCTR : " + ex.Message; fonctions.FermerConnection(); }
            }
        }

        //Traitement pour afficher le total des réglements Simply Order pour une journée
        private void totalTypeSimply()
        {
            sqlSimply = "SELECT SUM(ROUND( r.MntReglement, 2)) as TotalSimply";
            sqlSimply += " FROM facture f, commande cd, client c, ligne_reglement lr, reglement r, type_reglement tr";
            sqlSimply += " WHERE f.NumClient = c.NumClient";
            sqlSimply += " AND f.NumFacture = cd.NumCommande";
            sqlSimply += " AND f.NumFacture = lr.NumFacture";
            sqlSimply += " AND lr.NumReglement = r.NumReglement";
            sqlSimply += " AND r.IdType_Reglement = tr.IdType_Reglement";
            sqlSimply += " AND tr.IdType_Reglement = 5";
            sqlSimply += " AND f.DateFacture LIKE '" + dateJour + "'";

            fonctions.OuvrirConnection();
            if (fonctions.Existe(sqlSimply))
            {
                fonctions.FermerConnection();
                try
                {
                    fonctions.OuvrirConnection();
                    MySqlDataReader myReader = fonctions.Lire(sqlSimply);
                    myReader.Read();
                    tbxSimply.Text = myReader.GetValue(0).ToString();
                    fonctions.FermerConnection();
                }
                catch (Exception ex)
                { lblMessage.Text = "Load_TotalSimply : " + ex.Message; fonctions.FermerConnection(); }
            }
        }
        #endregion

        #region "Traitement pour afficher le total des différents types de réglement en Livraison"
        //Traitement pour afficher le total des réglements en espèces pour la livraison
        private void totalEspeceLivr()
        {
            sqlEspLivr = "SELECT SUM(ROUND( r.MntReglement, 2)) as TotalEspece";
            sqlEspLivr += " FROM facture f, commande cd, client c, ligne_reglement lr, reglement r, type_reglement tr";
            sqlEspLivr += " WHERE f.NumClient = c.NumClient";
            sqlEspLivr += " AND f.NumFacture = cd.NumCommande";
            sqlEspLivr += " AND f.NumFacture = lr.NumFacture";
            sqlEspLivr += " AND lr.NumReglement = r.NumReglement";
            sqlEspLivr += " AND r.IdType_Reglement = tr.IdType_Reglement";
            sqlEspLivr += " AND cd.TypeCommande = 'Livraison'";
            sqlEspLivr += " AND tr.IdType_Reglement = 1";
            sqlEspLivr += " AND f.DateFacture LIKE '" + dateJour + "'";

            fonctions.OuvrirConnection();
            if (fonctions.Existe(sqlEspLivr))
            {
                fonctions.FermerConnection();
                try
                {
                    fonctions.OuvrirConnection();
                    MySqlDataReader myReader = fonctions.Lire(sqlEspLivr);
                    myReader.Read();
                    tbxEspeceLivraison.Text = myReader.GetValue(0).ToString();
                    fonctions.FermerConnection();
                }
                catch (Exception ex)
                { lblMessage.Text = "Load_TotalEspeces_Livraison : " + ex.Message; fonctions.FermerConnection(); }
            }
        }

        //Traitement pour afficher le total des réglements en chéques pour la livraison
        private void totalChequeLivr()
        {
            sqlCheqLivr = "SELECT SUM(ROUND( r.MntReglement, 2)) as TotalCheq";
            sqlCheqLivr += " FROM facture f, commande cd, client c, ligne_reglement lr, reglement r, type_reglement tr";
            sqlCheqLivr += " WHERE f.NumClient = c.NumClient";
            sqlCheqLivr += " AND f.NumFacture = cd.NumCommande";
            sqlCheqLivr += " AND f.NumFacture = lr.NumFacture";
            sqlCheqLivr += " AND lr.NumReglement = r.NumReglement";
            sqlCheqLivr += " AND r.IdType_Reglement = tr.IdType_Reglement";
            sqlCheqLivr += " AND cd.TypeCommande = 'Livraison'";
            sqlCheqLivr += " AND tr.IdType_Reglement = 3";
            sqlCheqLivr += " AND f.DateFacture LIKE '" + dateJour + "'";

            fonctions.OuvrirConnection();
            if (fonctions.Existe(sqlCheqLivr))
            {
                fonctions.FermerConnection();
                try
                {
                    fonctions.OuvrirConnection();
                    MySqlDataReader myReader = fonctions.Lire(sqlCheqLivr);
                    myReader.Read();
                    tbxChequeLivraison.Text = myReader.GetValue(0).ToString();
                    fonctions.FermerConnection();
                }
                catch (Exception ex)
                { lblMessage.Text = "Load_TotalCheque_Livraison : " + ex.Message; fonctions.FermerConnection(); }
            }
        }

        //Traitement pour afficher le total des réglements en tickets restaurant pour la livraison
        private void totalCtrLivr()
        {
            sqlCtrLivr = "SELECT SUM(ROUND( r.MntReglement, 2)) as TotalCtr";
            sqlCtrLivr += " FROM facture f, commande cd, client c, ligne_reglement lr, reglement r, type_reglement tr";
            sqlCtrLivr += " WHERE f.NumClient = c.NumClient";
            sqlCtrLivr += " AND f.NumFacture = cd.NumCommande";
            sqlCtrLivr += " AND f.NumFacture = lr.NumFacture";
            sqlCtrLivr += " AND lr.NumReglement = r.NumReglement";
            sqlCtrLivr += " AND r.IdType_Reglement = tr.IdType_Reglement";
            sqlCtrLivr += " AND cd.TypeCommande = 'Livraison'";
            sqlCtrLivr += " AND tr.IdType_Reglement = 4";
            sqlCtrLivr += " AND f.DateFacture LIKE '" + dateJour + "'";

            fonctions.OuvrirConnection();
            if (fonctions.Existe(sqlCtrLivr))
            {
                fonctions.FermerConnection();
                try
                {
                    fonctions.OuvrirConnection();
                    MySqlDataReader myReader = fonctions.Lire(sqlCtrLivr);
                    myReader.Read();
                    tbxCtrLivraison.Text = myReader.GetValue(0).ToString();
                    fonctions.FermerConnection();
                }
                catch (Exception ex)
                { lblMessage.Text = "Load_TotalCTR_Livraison : " + ex.Message; fonctions.FermerConnection(); }
            }
        }

        //Traitement pour afficher le total des réglements Simply Order pour la livraison
        private void totalSimplyLivr()
        {
            sqlSimplyLivr = "SELECT SUM(ROUND( r.MntReglement, 2)) as TotalCtr";
            sqlSimplyLivr += " FROM facture f, commande cd, client c, ligne_reglement lr, reglement r, type_reglement tr";
            sqlSimplyLivr += " WHERE f.NumClient = c.NumClient";
            sqlSimplyLivr += " AND f.NumFacture = cd.NumCommande";
            sqlSimplyLivr += " AND f.NumFacture = lr.NumFacture";
            sqlSimplyLivr += " AND lr.NumReglement = r.NumReglement";
            sqlSimplyLivr += " AND r.IdType_Reglement = tr.IdType_Reglement";
            sqlSimplyLivr += " AND cd.TypeCommande = 'Livraison'";
            sqlSimplyLivr += " AND tr.IdType_Reglement = 5";
            sqlSimplyLivr += " AND f.DateFacture LIKE '" + dateJour + "'";

            fonctions.OuvrirConnection();
            if (fonctions.Existe(sqlSimplyLivr))
            {
                fonctions.FermerConnection();
                try
                {
                    fonctions.OuvrirConnection();
                    MySqlDataReader myReader = fonctions.Lire(sqlSimplyLivr);
                    myReader.Read();
                    tbxSimplyLivraison.Text = myReader.GetValue(0).ToString();
                    fonctions.FermerConnection();
                }
                catch (Exception ex)
                { lblMessage.Text = "Load_TotalSimply_Livraison : " + ex.Message; fonctions.FermerConnection(); }
            }
        }
        #endregion

        #region "Traitement pour afficher le total des différents types de réglement sur place/emporter"
        //Traitement pour afficher le total des réglements en epèces sur place/emporter
        private void totalEspeceEmpor()
        {
            sqlEspEmp = "SELECT SUM(ROUND( r.MntReglement, 2)) as TotalCtr";
            sqlEspEmp += " FROM facture f, commande cd, client c, ligne_reglement lr, reglement r, type_reglement tr";
            sqlEspEmp += " WHERE f.NumClient = c.NumClient";
            sqlEspEmp += " AND f.NumFacture = cd.NumCommande";
            sqlEspEmp += " AND f.NumFacture = lr.NumFacture";
            sqlEspEmp += " AND lr.NumReglement = r.NumReglement";
            sqlEspEmp += " AND r.IdType_Reglement = tr.IdType_Reglement";
            sqlEspEmp += " AND cd.TypeCommande != 'Livraison'";
            sqlEspEmp += " AND tr.IdType_Reglement = 1";
            sqlEspEmp += " AND f.DateFacture LIKE '" + dateJour + "'";

            fonctions.OuvrirConnection();
            if (fonctions.Existe(sqlEspEmp))
            {
                fonctions.FermerConnection();
                try
                {
                    fonctions.OuvrirConnection();
                    MySqlDataReader myReader = fonctions.Lire(sqlEspEmp);
                    myReader.Read();
                    tbxEspeceSP.Text = myReader.GetValue(0).ToString();
                    fonctions.FermerConnection();
                }
                catch (Exception ex)
                { lblMessage.Text = "Load_TotalEspece_Emporter : " + ex.Message; fonctions.FermerConnection(); }
            }
        }

        //Traitement pour afficher le total des réglements en Cartes bancaire sur place/emporter
        private void totalCbEmpor()
        {
            sqlCbEmp = "SELECT SUM(ROUND( r.MntReglement, 2)) as TotalCtr";
            sqlCbEmp += " FROM facture f, commande cd, client c, ligne_reglement lr, reglement r, type_reglement tr";
            sqlCbEmp += " WHERE f.NumClient = c.NumClient";
            sqlCbEmp += " AND f.NumFacture = cd.NumCommande";
            sqlCbEmp += " AND f.NumFacture = lr.NumFacture";
            sqlCbEmp += " AND lr.NumReglement = r.NumReglement";
            sqlCbEmp += " AND r.IdType_Reglement = tr.IdType_Reglement";
            sqlCbEmp += " AND cd.TypeCommande != 'Livraison'";
            sqlCbEmp += " AND tr.IdType_Reglement = 2";
            sqlCbEmp += " AND f.DateFacture LIKE '" + dateJour + "'";

            fonctions.OuvrirConnection();
            if (fonctions.Existe(sqlCbEmp))
            {
                fonctions.FermerConnection();
                try
                {
                    fonctions.OuvrirConnection();
                    MySqlDataReader myReader = fonctions.Lire(sqlCbEmp);
                    myReader.Read();
                    tbxCbSP.Text = myReader.GetValue(0).ToString();
                    fonctions.FermerConnection();
                }
                catch (Exception ex)
                { lblMessage.Text = "Load_TotalCB_Emporter : " + ex.Message; fonctions.FermerConnection(); }
            }
        }

        //Traitement pour afficher le total des réglements en Chéques sur place/emporter
        private void totalCheqEmpor()
        {
            sqlCheqEmp = "SELECT SUM(ROUND( r.MntReglement, 2)) as TotalCtr";
            sqlCheqEmp += " FROM facture f, commande cd, client c, ligne_reglement lr, reglement r, type_reglement tr";
            sqlCheqEmp += " WHERE f.NumClient = c.NumClient";
            sqlCheqEmp += " AND f.NumFacture = cd.NumCommande";
            sqlCheqEmp += " AND f.NumFacture = lr.NumFacture";
            sqlCheqEmp += " AND lr.NumReglement = r.NumReglement";
            sqlCheqEmp += " AND r.IdType_Reglement = tr.IdType_Reglement";
            sqlCheqEmp += " AND cd.TypeCommande != 'Livraison'";
            sqlCheqEmp += " AND tr.IdType_Reglement = 3";
            sqlCheqEmp += " AND f.DateFacture LIKE '" + dateJour + "'";

            fonctions.OuvrirConnection();
            if (fonctions.Existe(sqlCheqEmp))
            {
                fonctions.FermerConnection();
                try
                {
                    fonctions.OuvrirConnection();
                    MySqlDataReader myReader = fonctions.Lire(sqlCheqEmp);
                    myReader.Read();
                    tbxChequeSP.Text = myReader.GetValue(0).ToString();
                    fonctions.FermerConnection();
                }
                catch (Exception ex)
                { lblMessage.Text = "Load_TotalChéque_Emporter : " + ex.Message; fonctions.FermerConnection(); }
            }
        }

        //Traitement pour afficher le total des réglements en Tickets restaurant sur place/emporter
        private void totalCtrEmpor()
        {
            sqlCtrEmp = "SELECT SUM(ROUND( r.MntReglement, 2)) as TotalCtr";
            sqlCtrEmp += " FROM facture f, commande cd, client c, ligne_reglement lr, reglement r, type_reglement tr";
            sqlCtrEmp += " WHERE f.NumClient = c.NumClient";
            sqlCtrEmp += " AND f.NumFacture = cd.NumCommande";
            sqlCtrEmp += " AND f.NumFacture = lr.NumFacture";
            sqlCtrEmp += " AND lr.NumReglement = r.NumReglement";
            sqlCtrEmp += " AND r.IdType_Reglement = tr.IdType_Reglement";
            sqlCtrEmp += " AND cd.TypeCommande != 'Livraison'";
            sqlCtrEmp += " AND tr.IdType_Reglement = 4";
            sqlCtrEmp += " AND f.DateFacture LIKE '" + dateJour + "'";

            fonctions.OuvrirConnection();
            if (fonctions.Existe(sqlCtrEmp))
            {
                fonctions.FermerConnection();
                try
                {
                    fonctions.OuvrirConnection();
                    MySqlDataReader myReader = fonctions.Lire(sqlCtrEmp);
                    myReader.Read();
                    tbxCtrSp.Text = myReader.GetValue(0).ToString();
                    fonctions.FermerConnection();
                }
                catch (Exception ex)
                { lblMessage.Text = "Load_TotalCTR_Emporter : " + ex.Message; fonctions.FermerConnection(); }
            }
        }

        //Traitement pour afficher le total des réglements Simply Order sur place/emporter
        private void totalSimplyEmpor()
        {
            sqlSimplyEmp = "SELECT SUM(ROUND( r.MntReglement, 2)) as TotalCtr";
            sqlSimplyEmp += " FROM facture f, commande cd, client c, ligne_reglement lr, reglement r, type_reglement tr";
            sqlSimplyEmp += " WHERE f.NumClient = c.NumClient";
            sqlSimplyEmp += " AND f.NumFacture = cd.NumCommande";
            sqlSimplyEmp += " AND f.NumFacture = lr.NumFacture";
            sqlSimplyEmp += " AND lr.NumReglement = r.NumReglement";
            sqlSimplyEmp += " AND r.IdType_Reglement = tr.IdType_Reglement";
            sqlSimplyEmp += " AND cd.TypeCommande != 'Livraison'";
            sqlSimplyEmp += " AND tr.IdType_Reglement = 5";
            sqlSimplyEmp += " AND f.DateFacture LIKE '" + dateJour + "'";

            fonctions.OuvrirConnection();
            if (fonctions.Existe(sqlSimplyEmp))
            {
                fonctions.FermerConnection();
                try
                {
                    fonctions.OuvrirConnection();
                    MySqlDataReader myReader = fonctions.Lire(sqlSimplyEmp);
                    myReader.Read();
                    tbxSimplySP.Text = myReader.GetValue(0).ToString();
                    fonctions.FermerConnection();
                }
                catch (Exception ex)
                { lblMessage.Text = "Load_TotalSimply_Emporter : " + ex.Message; fonctions.FermerConnection(); }
            }
        }
        #endregion

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
            sqlPremTva += " AND cd.DateCommande LIKE '" + dateJour + "'";

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
                tbxPremTva.Text = mntPremTva.ToString("0.00");
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
            sqlDeuxTva += " AND cd.DateCommande LIKE '" + dateJour + "'";

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
                tbxDeuxTva.Text = mntDeuxTva.ToString("0.00");
            }
        }
        #endregion
    }
}
