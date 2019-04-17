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
    public partial class PasserCommande : Form
    {
        #region "Déclaration des variables"
        //Déclaration des variables    
        string requete;//Pour passer les requetes Sql
        string sqlDtg;//Pour charger le DataGridView Ligne de commande temporaire
        string sqlDtg2;//Pour charger le DataGridView détail d'un menu
        int numCde;//Pour récupérer le numéro de la commande en cours
        string dateJour;//Pour récupérer la date de la commande en cours
        string heureClient;//Pour récupérer l'heure de livraison/à emportée 
        string modeRetrait = "";//Pour récupérer le choix du client pour la commande livraison/emporter
        int numClient;//Pour récupérer le code du client de plusieurs manières, aprés sélection à l'écran gestion client, aprés vérification numéro de téléphone ou par création
        //Concernent la récupération des coordonnées du client sur le même principe que le code du client
        string numTel;
        string nomClient;
        string adrClient;
        string cpostal;
        string ville;
        string commAdresse;
        string reglementCde = "Non payée";
        //Concerne la récupération des données concernant la commande d'un article
        string codeArticle;
        int quantiteArticle;
        string commArticle;
        //Concerne la recupération de la ligne de commande et de la ligne de commande temporaire
        int numLigneCde;
        int numLigneCdeTemp;
        //Concerne le numéro de la ligne pour le traitement sur le DataGridView
        int numLigneDtg;
        //Concerne le calcul du montant de la commande
        string mntTotal;
        //Concerne la vérification avant validation de la commande
        bool checkRetrait = true;
        //Concerne la vérification du nombre d'article d'une formule
        bool checkMenu = true;
        //Concerne le nombre de personne d'une formule
        int nbr;
        //Concerne la récupération du code de la ligne du détail menu et de la ligne du détail temporaire
        int numLigneMenu;
        int numLigneMenuTemp;
        //On stocke la valeur du numéro de ligne de commande qui correspond au menu validé        
        int numLigneCdeMenu;
        #endregion

        #region "Déclaration des variables de transfert entre les Form"
        bool v_btnVerifTel = true;
        //Récupère la valeur depuis l'écran gestion des client
        //False: permet de masquer le bouton de vérification du numéro de téléphone
        //True: garde le bouton de vérification du numéro de téléphone visible
        public bool V_btnVerifTel
        { set { v_btnVerifTel = value; } get { return v_btnVerifTel; } }

        int v_numClient;
        //Récupère la valeur trouvée(numClient) dans le datagrid de l'écran gestion client lors du traitement passer une commande
        public int V_numClient
        { set { v_numClient = value; } get { return v_numClient; } }
        #endregion

        public PasserCommande()
        {
            InitializeComponent();
        }

        //Traitement pour retourner à l'écran précédent 
        //Comme la commande d'un article créée une ligne dans une table temporaire (Ligne_Cde_Temp)
        //Si on annule la commande, en cours, on vide la table temporaire de toutes les références à cette commande
        private void btnRetour_Click(object sender, EventArgs e)
        {
            //Suppression des réferences à la commande dans la table ligne_menu_temp
            requete = "SELECT m.IdLigneMenuTmp FROM ligne_menu_temp m, ligne_cde_temp c";
            requete += " WHERE m.IdLigneCdeTmp = c.IdLigneCdeTmp";
            requete += " AND NumCommandetmp = " + numCde.ToString();
            fonctions.OuvrirConnection();
            try
            {
                if (fonctions.Existe(requete))
                {
                    fonctions.FermerConnection();
                    string sqlVide = "DELETE m FROM ligne_menu_temp m";
                    sqlVide += " LEFT JOIN ligne_cde_temp c ON m.IdLigneCdeTmp = c.IdLigneCdeTmp";
                    sqlVide += " WHERE c.NumCommandetmp = " + numCde.ToString();
                    fonctions.OuvrirConnection();
                    fonctions.ExecCmd(sqlVide);
                    fonctions.FermerConnection();
                }
            }
            catch (Exception ex)
            { lblMessage.Text = "Annulation_Ligne_Menu: " + ex.Message; fonctions.FermerConnection(); }

            //Suppression des réferences à la commande dans la table ligne_cde_temp
            requete = "SELECT IdLigneCdeTmp FROM ligne_cde_temp ";
            requete += "WHERE NumCommandetmp = " + numCde.ToString();
            fonctions.OuvrirConnection();
            try
            {
                if (fonctions.Existe(requete))
                {
                    fonctions.FermerConnection();
                    string table = "ligne_cde_temp";
                    string where = " NumCommandetmp = " + numCde.ToString();
                    fonctions.Supprimer(table, where);
                }
            }
            catch (Exception ex)
            { lblMessage.Text = "Annulation_Ligne_Cmd: " + ex.Message; fonctions.FermerConnection(); }

            this.Close();
        }

        //Traitement du chargement des données connues
        //Si sélection d'un client à partir du fichier client: récupération des coordonnées
        //Affichage de la date du jour et initialisation du DateTimePicker pour choisir l'heure du mode retrait
        //Création du numéro de la commande
        //Si aucun client n'a été sélectionné en arrivant sur cette page, création d'un numéro de client
        private void PasserCommande_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            tbxCodePostal.Text = "57000";
            tbxVille.Text = "Metz";

            //Si on a choisi un client à l'écran de gestion des client, le bouton sera masqué
            //Ce bouton sert à vérifier si un client correspond au numéro de téléphone saisi
            btnVerifTel.Visible = v_btnVerifTel;

            //Affichage de la date du jour au format ex: lundi 04 avril 2013
            tbxDateJour.Text = DateTime.Now.ToLongDateString();
            //Conversion au format MySql
            dateJour = DateTime.Now.ToString("yyyy-MM-dd");
            //Initialisation format DateTimePicker pour l'heure choisie par le client et date du jour
            dtpHeureDesire.CustomFormat = "HH:mm";
            dtpHeureDesire.Format = DateTimePickerFormat.Custom;

            creaNumCommande();
            creaNumClient();

            codeLigneCde();
            codeLigneMenu();

            comboTypePizza();
            comboSupplement();
            comboPlat();
            combBoisson();
            combMenu();
            combChoixMenu();
        }

        #region "Traitements pour attribuer les identifiants nécessaire à l'insertion des lignes"
        //Traitement pour attribuer un numéro de commande
        //L'attribution se fera sans que l'utilisateur intervient
        private void creaNumCommande()
        {
            requete = "SELECT * FROM commande";
            fonctions.OuvrirConnection();
            try
            {
                //Verification qu'il existe une ligne dans la table commande
                if (fonctions.Existe(requete))
                {
                    fonctions.FermerConnection();
                    //Si il existe des enregistrements on prend le numéro de commande max et on ajoute 1
                    requete = "SELECT MAX(NumCommande)+1 FROM commande";
                    fonctions.OuvrirConnection();
                    numCde = fonctions.Compte(requete);
                    fonctions.FermerConnection();
                }
                else
                {   //Sinon le numéro de commande commence à 1
                    numCde = 1; fonctions.FermerConnection();
                }
                tbxNumCde.Text = numCde.ToString(); //Affichage du numCommande
            }
            catch (Exception ex)
            { lblMessage.Text = "Chargement Num Commande: " + ex.Message; fonctions.FermerConnection(); }
        }
        //Traitement concernant un client
        //Si on a sélectionné une ligne à partir de l'écran de gestion client: affiche les information connues
        //Si on a sélectionné aucune ligne, ou si on arrive sur cet écran depuis la gestion des commandes: on lui attribue un numéro 
        private void creaNumClient()
        {
            //Si on a choisit un client dans la forme gestion client, on affiche toutes les informations connues le concernant
            if (v_numClient != 0)
            {
                try
                {
                    //On stocke le numéro du client
                    numClient = v_numClient;
                    // recherche de l'enregistrement du client connu par son numClient
                    requete = "SELECT * FROM client WHERE numClient = " + v_numClient;
                    fonctions.OuvrirConnection();
                    MySqlDataReader myReader = fonctions.Lire(requete);
                    myReader.Read();
                    tbxNomClient.Text = myReader.GetValue(1).ToString();
                    tbxAdresse.Text = myReader.GetValue(3).ToString();
                    tbxCodePostal.Text = myReader.GetValue(4).ToString();
                    tbxVille.Text = myReader.GetValue(5).ToString();
                    tbxNumTel.Text = myReader.GetValue(6).ToString();
                    fonctions.FermerConnection();
                }
                catch (Exception ex)
                { lblMessage.Text = "Chargement Client: " + ex.Message; fonctions.FermerConnection(); }
            }
            else
            {
                //Traitement pour attribuer un numéro de client
                requete = "SELECT numclient FROM client";
                fonctions.OuvrirConnection();
                try
                {
                    //Verification qu'il existe une ligne dans la table client
                    if (fonctions.Existe(requete))
                    {
                        fonctions.FermerConnection();
                        //Si il existe des enregistrements on prend le numéro de client max et on ajoute 1
                        requete = "SELECT MAX(NumClient)+1 FROM client";
                        fonctions.OuvrirConnection();
                        numClient = fonctions.Compte(requete);
                        fonctions.FermerConnection();
                    }
                    else
                    {   //Sinon le numéro de commande commence à 1
                        numClient = 1; fonctions.FermerConnection();
                    }
                }
                catch (Exception ex)
                { lblMessage.Text = "Chargement Num Client: " + ex.Message; fonctions.FermerConnection(); }

            }
        }
        //Traitement pour attribuer un numéro de ligne de commande dans la table temporaire
        //Le numéro de la ligne de commande temporaire commencera avec le numéro de la ligne de commande trouvé
        private void codeLigneCde()
        {
            string sqlCde = "SELECT * FROM Ligne_commande";
            fonctions.OuvrirConnection();
            try
            {
                //Verification qu'il existe une ligne dans la table Ligne_commande
                if (fonctions.Existe(sqlCde))
                {
                    fonctions.FermerConnection();
                    //Si il existe des enregistrements on prend le numéro de ligne max et on ajoute 1
                    requete = "SELECT MAX(IdLigneCde)+1 FROM Ligne_commande";
                    fonctions.OuvrirConnection();
                    numLigneCde = fonctions.Compte(requete);
                    fonctions.FermerConnection();
                }
                else
                {   //Sinon le numéro de ligne de commande commence à 1
                    numLigneCde = 1; fonctions.FermerConnection();
                }
            }
            catch (Exception ex)
            { lblMessage.Text = "Chargement Num LigneCdeTmp: " + ex.Message; fonctions.FermerConnection(); }
            numLigneCdeTemp = numLigneCde;
        }

        //Traitement pour attribuer un numéro de ligne pour le détail du menu dans la table Ligne_menu
        //Le numéro de la ligne de détail menu temporaire commencera avec le numéro de la ligne de détail menu trouvé
        private void codeLigneMenu()
        {
            string sqlCde = "SELECT * FROM Ligne_menu";
            fonctions.OuvrirConnection();
            try
            {
                //Verification qu'il existe une ligne dans la table Ligne_menu
                if (fonctions.Existe(sqlCde))
                {
                    fonctions.FermerConnection();
                    //Si il existe des enregistrements on prend le numéro de ligne max et on ajoute 1
                    requete = "SELECT MAX(IdLigneMenu)+1 FROM Ligne_menu";
                    fonctions.OuvrirConnection();
                    numLigneMenu = fonctions.Compte(requete);
                    fonctions.FermerConnection();
                }
                else
                {   //Sinon le numéro de ligne de menu commence à 1
                    numLigneMenu = 1; fonctions.FermerConnection();
                }
            }
            catch (Exception ex)
            { lblMessage.Text = "Chargement_Num_LigneMenu: " + ex.Message; fonctions.FermerConnection(); }
            numLigneMenuTemp = numLigneMenu;
        }
        #endregion

        #region "Traitement pour charger les ComboBox des choix des types d'article"
        //Chargement du ComboBox des types de pizzas
        //Les pizzas appartiennent à des types différents
        //Le choix d'un type de pizza, affichera les pizzas correspondantes dans une nouvelle ComboBox
        private void comboTypePizza()
        {
            string sql = "SELECT CodeTypeProduit, LibTypeProduit FROM type_produit";
            sql += " WHERE CodeTypeProduit >= 3 AND CodeTypeProduit <= 7";
            cboxTypePizza.DisplayMember = "LibTypeProduit";
            cboxTypePizza.ValueMember = "CodeTypeProduit";
            try
            {
                fonctions.OuvrirConnection();
                cboxTypePizza.DataSource = fonctions.Adapt(sql);
            }
            catch (Exception ex)
            { lblMessage.Text = "Erreur_Load_TypePizzas : " + ex.Message; fonctions.FermerConnection(); }
        }
        //Chargement du ComboBox des suppléments
        private void comboSupplement()
        {
            string sql = "SELECT a.CodeArticle, a.LibArticle FROM article a, produit p";
            sql += " WHERE a.CodeArticle = p.CodeArticleProduit";
            sql += " AND p.CodeTypeProduit = 12";
            cboxSupplement.DisplayMember = "LibArticle";
            cboxSupplement.ValueMember = "CodeArticle";
            try
            {
                fonctions.OuvrirConnection();
                cboxSupplement.DataSource = fonctions.Adapt(sql);
                fonctions.FermerConnection();
            }
            catch (Exception ex)
            { lblMessage.Text = "Erreur_Load_Suppléments : " + ex.Message; fonctions.FermerConnection(); }
        }
        //Chargement du ComboBox des autres types de plat (salades, pâtes, desserts)
        //Le choix d'un type de plat, affichera les plats correspondants dans une nouvelle ComboBox
        private void comboPlat()
        {
            string sql = "SELECT CodeTypeProduit, LibTypeProduit FROM type_produit";
            sql += " WHERE CodeTypeProduit IN (1, 2, 8)";
            cboxTypePlat.DisplayMember = "LibTypeProduit";
            cboxTypePlat.ValueMember = "CodeTypeProduit";
            try
            {
                fonctions.OuvrirConnection();
                cboxTypePlat.DataSource = fonctions.Adapt(sql);
            }
            catch (Exception ex)
            { lblMessage.Text = "Erreur_Load_TypePlats : " + ex.Message; fonctions.FermerConnection(); }
        }
        //Chargement ComboBox des types de boissons (softs, alcoolisées, vins)
        //Le choix d'un type de boisson, affichera les boissons correspondantes dans une nouvelle ComboBox
        private void combBoisson()
        {
            string sql = "SELECT CodeTypeProduit, LibTypeProduit FROM type_produit";
            sql += " WHERE CodeTypeProduit IN (9, 10, 11)";
            cboxTypeBoisson.DisplayMember = "LibTypeProduit";
            cboxTypeBoisson.ValueMember = "CodeTypeProduit";
            try
            {
                fonctions.OuvrirConnection();
                cboxTypeBoisson.DataSource = fonctions.Adapt(sql);
            }
            catch (Exception ex)
            { lblMessage.Text = "Erreur_Load_TypeBoissons : " + ex.Message; fonctions.FermerConnection(); }
        }
        //Chargement ComboBox des types de menu
        //Le choix d'un type de menu, affichera le choix des pizzas et le choix des boissons autorisées dans deux ComboBox 
        private void combMenu()
        {
            string sql = "SELECT a.CodeArticle , t.LibTypeMenu";
            sql += " FROM type_formule t, formule f, article a";
            sql += " WHERE a.CodeArticle = f.CodeArticleMenu";
            sql += " AND f.CodeTypeMenu = t.CodeTypeMenu";
            cboxTypeMenu.DisplayMember = "LibTypeMenu";
            cboxTypeMenu.ValueMember = "CodeArticle";
            try
            {
                fonctions.OuvrirConnection();
                cboxTypeMenu.DataSource = fonctions.Adapt(sql);
                fonctions.FermerConnection();
            }
            catch (Exception ex)
            { lblMessage.Text = "Erreur_Load_TypeMenu : " + ex.Message; fonctions.FermerConnection(); }
        }
        //Chargement des ComboBox pour le choix des pizzas et des boissons
        private void combChoixMenu()
        {
            string sqlPchoix = "SELECT a.CodeArticle, a.LibArticle FROM article a, produit p";
            sqlPchoix += " WHERE a.CodeArticle = p.CodeArticleProduit";
            sqlPchoix += " AND p.CodeTypeProduit = 7";
            cboxPizzaMenu.DisplayMember = "LibArticle";
            cboxPizzaMenu.ValueMember = "LibArticle";
            try
            {
                fonctions.OuvrirConnection();
                cboxPizzaMenu.DataSource = fonctions.Adapt(sqlPchoix);
                fonctions.FermerConnection();
            }
            catch (Exception ex)
            { lblMessage.Text = "Erreur_Load_PizzaMenu : " + ex.Message; fonctions.FermerConnection(); }

            string sqlBchoix = "SELECT a.CodeArticle, a.LibArticle FROM article a, produit p";
            sqlBchoix += " WHERE a.CodeArticle = p.CodeArticleProduit";
            sqlBchoix += " AND p.CodeTypeProduit = 9";
            cboxBoissonMenu.DisplayMember = "LibArticle";
            cboxBoissonMenu.ValueMember = "LibArticle";
            try
            {
                fonctions.OuvrirConnection();
                cboxBoissonMenu.DataSource = fonctions.Adapt(sqlBchoix);
                fonctions.FermerConnection();
            }
            catch (Exception ex)
            { lblMessage.Text = "Erreur_Load_BoissonMenu : " + ex.Message; fonctions.FermerConnection(); }
        }
        #endregion

        #region "Traitement pour charger les ComboBox des articles correspondants à un type d'article"
        //Après séléction d'un type de pizzas dans la ComboBox TypePizza, charge la ComboBox pizza avec les pizzas correspondantes
        private void cboxTypePizza_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboxTypePizza.SelectedIndex != -1)
            {
                //Récupère le code du type de pizza
                string codeTypePizza = cboxTypePizza.SelectedValue.ToString();
                //On recherche les pizzas qui appartiennent à ce type de pizza
                string sql = "SELECT a.CodeArticle, a.LibArticle FROM article a, produit p";
                sql += " WHERE a.CodeArticle = p.CodeArticleProduit";
                sql += " AND p.CodeTypeProduit = " + codeTypePizza;
                cboxPizza.DisplayMember = "LibArticle";
                cboxPizza.ValueMember = "CodeArticle";
                try
                {
                    fonctions.OuvrirConnection();
                    cboxPizza.DataSource = fonctions.Adapt(sql);
                    fonctions.FermerConnection();
                }
                catch (Exception ex)
                { lblMessage.Text = "Erreur_Load_Pizzas : " + ex.Message; fonctions.FermerConnection(); }
            }
        }
        //Après sélection d'un type de plat dans la ComboBox TypePlat, charge la ComboBox plat avec les plats correspondants
        private void cboxTypePlat_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboxTypePlat.SelectedIndex != -1)
            {
                //Récupère le code du type de plat
                string codeTypePlat = cboxTypePlat.SelectedValue.ToString();
                //On recherche les plats qui appartiennent à ce type de plat
                string sql = "SELECT a.CodeArticle, a.LibArticle FROM article a, produit p";
                sql += " WHERE a.CodeArticle = p.CodeArticleProduit";
                sql += " AND p.CodeTypeProduit = " + codeTypePlat;
                cboxPlat.DisplayMember = "LibArticle";
                cboxPlat.ValueMember = "CodeArticle";
                try
                {
                    fonctions.OuvrirConnection();
                    cboxPlat.DataSource = fonctions.Adapt(sql);
                    fonctions.FermerConnection();
                }
                catch (Exception ex)
                { lblMessage.Text = "Erreur_Load_Plats : " + ex.Message; fonctions.FermerConnection(); }
            }
        }
        //Après sélection d'un type de boisson dans la ComboBox TypeBoisson, charge la ComboBox boisson avec les boissons correspondantes
        private void cboxTypeBoisson_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboxTypeBoisson.SelectedIndex != -1)
            {
                string codeTypeBoisson = cboxTypeBoisson.SelectedValue.ToString();
                string sql = "SELECT a.CodeArticle, a.LibArticle FROM article a, produit p";
                sql += " WHERE a.CodeArticle = p.CodeArticleProduit";
                sql += " AND p.CodeTypeProduit = " + codeTypeBoisson;
                cboxBoisson.DisplayMember = "LibArticle";
                cboxBoisson.ValueMember = "CodeArticle";
                try
                {
                    fonctions.OuvrirConnection();
                    cboxBoisson.DataSource = fonctions.Adapt(sql);
                    fonctions.FermerConnection();
                }
                catch (Exception ex)
                { lblMessage.Text = "Erreur_Load_Boissons : " + ex.Message; fonctions.FermerConnection(); }
            }
        }
        #endregion

        #region "Traitements pour l'ajout des différents articles simple à la commande"
        //Traitement pour ajouter une pizza dans la table temporaire de commande        
        private void btnAjoutPizza_Click(object sender, EventArgs e)
        {
            //Récupération des champs saisis
            codeArticle = cboxPizza.SelectedValue.ToString();
            quantiteArticle = int.Parse(nudQuantitePizza.Value.ToString());
            commArticle = tbxCommPizza.Text;

            try
            {
                string table = "Ligne_cde_Temp";
                string valeur = numLigneCdeTemp.ToString();
                valeur += ", " + quantiteArticle;
                valeur += ", '" + commArticle + "'";
                valeur += ", " + numCde;
                valeur += ", " + codeArticle;

                fonctions.Inserer(table, valeur);
                dtgLoad();
            }
            catch (Exception ex)
            { lblMessage.Text = "Validation_Ajout_Pizza " + ex.Message; }
            //Remise à vide du champ commentaire et remise à 1 du compteur de quantité
            nudQuantitePizza.Value = 1; tbxCommPizza.Text = ""; numLigneCdeTemp = numLigneCdeTemp + 1;
        }

        //Traitement pour ajouter un supplément dans la table temporaire de commande
        private void btnSuppAjout_Click(object sender, EventArgs e)
        {
            codeArticle = cboxSupplement.SelectedValue.ToString();
            quantiteArticle = int.Parse(nudQuantiteSupp.Value.ToString());

            try
            {
                string table = "Ligne_cde_Temp";
                string valeur = numLigneCdeTemp.ToString();
                valeur += ", " + quantiteArticle;
                valeur += ", ''";
                valeur += ", " + numCde;
                valeur += ", " + codeArticle;

                fonctions.Inserer(table, valeur);
                dtgLoad();
            }
            catch (Exception ex)
            { lblMessage.Text = "Validation_Ajout_Supp " + ex.Message; }
            //Remise à vide du champ commentaire et remise à 1 du compteur de quantité
            nudQuantiteSupp.Value = 1; numLigneCdeTemp = numLigneCdeTemp + 1;
        }

        //Traitement pour ajouter un plat dans la table temporaire de commande
        private void btnAjoutPlat_Click(object sender, EventArgs e)
        {
            codeArticle = cboxPlat.SelectedValue.ToString();
            quantiteArticle = int.Parse(nudQuantitePlat.Value.ToString());
            commArticle = tbxCommPlat.Text;

            try
            {
                string table = "Ligne_cde_Temp";
                string valeur = numLigneCdeTemp.ToString();
                valeur += ", " + quantiteArticle;
                valeur += ", '" + commArticle + "'";
                valeur += ", " + numCde;
                valeur += ", " + codeArticle;

                fonctions.Inserer(table, valeur);
                dtgLoad();
            }
            catch (Exception ex)
            { lblMessage.Text = "Validation_Ajout_Plat " + ex.Message; }
            //Remise à vide du champ commentaire et remise à 1 du compteur de quantité
            nudQuantitePlat.Value = 1; tbxCommPlat.Text = ""; numLigneCdeTemp = numLigneCdeTemp + 1;
        }

        //Traitement pour ajouter une boisson dans la table temporaire de commande
        private void btnAjoutBoisson_Click(object sender, EventArgs e)
        {
            codeArticle = cboxBoisson.SelectedValue.ToString();
            quantiteArticle = int.Parse(nudQuantiteBoisson.Value.ToString());

            try
            {
                string table = "Ligne_cde_Temp";
                string valeur = numLigneCdeTemp.ToString();
                valeur += ", " + quantiteArticle;
                valeur += ", ''";
                valeur += ", " + numCde;
                valeur += ", " + codeArticle;

                fonctions.Inserer(table, valeur);
                dtgLoad();
            }
            catch (Exception ex)
            { lblMessage.Text = "Validation_Ajout_Supp " + ex.Message; }
            //Remise à vide du champ commentaire et remise à 1 du compteur de quantité
            nudQuantiteSupp.Value = 1; numLigneCdeTemp = numLigneCdeTemp + 1;
        }
        #endregion

        #region "Traitement pour l'ajout du détail d'un menu"
        //Remise à vide des ListBox lorsque l'on change de formule
        private void cboxTypeMenu_SelectedValueChanged(object sender, EventArgs e)
        {
            lboxPizzaMenu.Items.Clear(); lboxBoissonMenu.Items.Clear();
        }
        //Procédure pour récupérer le nombre de choix par formule
        //On pourra ainsi contrôler le nombre d'items autorisé par ListBox
        private void nbreListBox()
        {
            //On récupère le code de l'article qui appartient à cette formule
            string formule = cboxTypeMenu.SelectedValue.ToString();
            //On recherche le nombre de personne pour ce type de formule
            string sqlNbr = "SELECT t.NbrPersonne FROM Formule f, type_formule t";
            sqlNbr += " WHERE t.CodeTypeMenu = f.CodeTypeMenu";
            sqlNbr += " AND f.CodeArticleMenu = " + formule;
            try
            {
                fonctions.OuvrirConnection();
                MySqlDataReader myReader = fonctions.Lire(sqlNbr);
                myReader.Read();
                nbr = int.Parse(myReader.GetValue(0).ToString());
                fonctions.FermerConnection();
            }
            catch (MySqlException ex)
            { lblMessage.Text = ex.Message; }
        }
        //Traitement pour ajouter les pizzas du menu
        private void btnAjoutPmenu_Click(object sender, EventArgs e)
        {
            nbreListBox();

            if (lboxPizzaMenu.Items.Count <= (nbr - 1))
            { lboxPizzaMenu.Items.Add(cboxPizzaMenu.SelectedValue.ToString()); }
        }
        //Traitement pour ajouter les boissons du menu
        private void btnAjoutBmenu_Click(object sender, EventArgs e)
        {
            nbreListBox();

            if (lboxBoissonMenu.Items.Count <= (nbr - 1))
            { lboxBoissonMenu.Items.Add(cboxBoissonMenu.SelectedValue.ToString()); }
        }
        //Traitement pour supprimer une pizza de la ListBox
        private void lboxPizzaMenu_DoubleClick(object sender, EventArgs e)
        {
            string dropPizza = lboxPizzaMenu.SelectedItem.ToString();
            lboxPizzaMenu.Items.Remove(dropPizza);
        }
        //Traitement pour supprimer une boisson de la ListBox
        private void lboxBoissonMenu_DoubleClick(object sender, EventArgs e)
        {
            string dropBoisson = lboxBoissonMenu.SelectedItem.ToString();
            lboxBoissonMenu.Items.Remove(dropBoisson);
        }
        #endregion

        //Traitement pour vérifier qu'on a le nombre de produit d'un menu"
        private void checkValidationMenu()
        {
            //Vérification du nombre d'article et ajout des lignes dans la table Ligne_menu
            if ((lboxPizzaMenu.Items.Count < nbr) || (lboxPizzaMenu.Items.Count == 0))
            { MessageBox.Show("Il manque des pizzas!"); checkMenu = false; return; }
            if ((lboxBoissonMenu.Items.Count < nbr) || (lboxBoissonMenu.Items.Count == 0))
            { MessageBox.Show("Il manque des boissons!"); checkMenu = false; return; }
            checkMenu = true;
        }

        #region "Traitement pour l'ajout d'un menu à la commande"
        //Traitement pour ajouter un menu dans la table temporaire de commande
        private void btnAjoutMenu_Click(object sender, EventArgs e)
        {
            checkValidationMenu();
            if (checkMenu == false)
            { return; }

            string libArt;
            codeArticle = cboxTypeMenu.SelectedValue.ToString();
            quantiteArticle = 1;
            commArticle = tbxCommMenu.Text;

            try
            {
                string table = "Ligne_cde_Temp";
                string valeur = numLigneCdeTemp.ToString();
                valeur += ", " + quantiteArticle;
                valeur += ", '" + commArticle + "'";
                valeur += ", " + numCde;
                valeur += ", " + codeArticle;

                fonctions.Inserer(table, valeur);
                dtgLoad();
            }
            catch (Exception ex)
            { lblMessage.Text = "Validation_Ajout_LigneMenu " + ex.Message; }
            //Remise à vide du champ commentaire 
            tbxCommMenu.Text = "";
            numLigneCdeMenu = numLigneCdeTemp;//Les lignes de détail du menu se réfèrent au numéro de la ligne de commande où se situe le menu
            numLigneCdeTemp = numLigneCdeTemp + 1;//On incrémente de 1 pour la commande de l'article suivant
            
            //On parcours la liste des pizzas sélectionnées
            for (int i = 0; i < lboxPizzaMenu.Items.Count; i++)
            {
                //On récupère le libelé de la pizza
                libArt = lboxPizzaMenu.Items[i].ToString();
                //On recherche le CodeArticle associé 
                string sqlCodArtP = "SELECT CodeArticle FROM Article";
                sqlCodArtP += " WHERE LibArticle = '" + libArt + "'";
                try
                {
                    fonctions.OuvrirConnection();
                    MySqlDataReader myReader = fonctions.Lire(sqlCodArtP);
                    myReader.Read();
                    string codeArticleMenu = myReader.GetValue(0).ToString();
                    fonctions.FermerConnection();
                    //On insère la ligne dans la table Ligne de menu temporaire
                    string tableMenu = "Ligne_menu_Temp";
                    string valeurMenu = numLigneMenuTemp.ToString();
                    valeurMenu += ", " + codeArticleMenu;
                    valeurMenu += ", " + numLigneCdeMenu;
                    fonctions.Inserer(tableMenu, valeurMenu);
                    //On incrémente le numéro de ligne de 1
                    numLigneMenuTemp = numLigneMenuTemp + 1;
                }
                catch (Exception ex)
                { lblMessage.Text = "Erreur_ListBoxPizza " + ex.Message; }
            }
            //On parcours la liste des boissons sélectionnées
            for (int j = 0; j < lboxBoissonMenu.Items.Count; j++)
            {
                libArt = lboxBoissonMenu.Items[j].ToString().Replace("'", "''");
                string sqlCodArtB = "SELECT CodeArticle FROM Article";
                sqlCodArtB += " WHERE LibArticle = '" + libArt + "'";
                try
                {
                    fonctions.OuvrirConnection();
                    MySqlDataReader myReader = fonctions.Lire(sqlCodArtB);
                    myReader.Read();
                    string codeArticleMenu = myReader.GetValue(0).ToString();
                    fonctions.FermerConnection();
                    //On insère la ligne dans la table Ligne de menu temporaire
                    string tableMenu = "Ligne_menu_Temp";
                    string valeurMenu = numLigneMenuTemp.ToString();
                    valeurMenu += ", " + codeArticleMenu;
                    valeurMenu += ", " + numLigneCdeMenu;
                    fonctions.Inserer(tableMenu, valeurMenu);
                    numLigneMenuTemp = numLigneMenuTemp + 1;
                }
                catch (Exception ex)
                { lblMessage.Text = "Erreur_ListBoxBoisson " + ex.Message; }
            }

            //On ajoute également les lignes pour le dessert, qui est fixe
            for (int k = 0; k < nbr; k++)
            {
                try
                {
                    string codeArticleMenu = "30";
                    //On insère la ligne dans la table Ligne de menu temporaire
                    string tableMenu = "Ligne_menu_Temp";
                    string valeurMenu = numLigneMenuTemp.ToString();
                    valeurMenu += ", " + codeArticleMenu;
                    valeurMenu += ", " + numLigneCdeMenu;
                    fonctions.Inserer(tableMenu, valeurMenu);
                    numLigneMenuTemp = numLigneMenuTemp + 1;
                }
                catch (Exception ex)
                { lblMessage.Text = "Erreur_Dessert_Menu " + ex.Message; }
            }
            lboxPizzaMenu.Items.Clear(); lboxBoissonMenu.Items.Clear();
            combMenu(); combChoixMenu();
        }
        #endregion

        #region "Traitement pour l'affichage du DataGridView des lignes de commande (temporaire) et celui du détail menu (temporaire)"
        //Chargement du DataGridView de la table ligne_commande temporaire qui se met à jour dynamiquement à chaque article ajouté
        private void dtgLoad()
        {
            //On affiche dans le DataGridView une colonne en plus pour le prix total par quantité d'article commandée
            string select = "SELECT l.IdLigneCdeTmp, l.QuantiteCdeTmp, a.LibArticle, l.CommentaireTmp, round(l.QuantiteCdeTmp * a.PrixTTC_Article, 2) as total";
            string from = " FROM Ligne_Cde_Temp l, Article a";
            string where = " WHERE l.CodeArticleTmp = a.CodeArticle";
            where += " AND NumCommandeTmp = " + numCde.ToString();
            sqlDtg = select + from + where;
            fonctions.OuvrirConnection();
            if (fonctions.Existe(sqlDtg))
            {
                fonctions.FermerConnection();
                try
                { formeDtgRecapCommande(sqlDtg); }
                catch (MySqlException ex)
                { lblMessage.Text = ex.Message; }
            }
            else
            { dtgRecapCommande.DataSource = null; dtgRecapCommande.Refresh(); }
            //On recupère le montant total de la facture dans une TextBox sous le DataGridViaew
            string total = "SELECT l.IdLigneCdeTmp, l.QuantiteCdeTmp, a.LibArticle, l.CommentaireTmp, SUM(round(l.QuantiteCdeTmp * a.PrixTTC_Article, 2)) as total";
            total += " FROM Ligne_Cde_Temp l, Article a";
            total += " WHERE l.CodeArticleTmp = a.CodeArticle";
            total += " AND NumCommandeTmp = " + numCde.ToString();
            try
            {
                fonctions.OuvrirConnection();
                MySqlDataReader myReader = fonctions.Lire(total);
                myReader.Read();
                tbxTotal.Text = myReader.GetValue(4).ToString();
                mntTotal = tbxTotal.Text.Replace(",", ".");
                fonctions.FermerConnection();
            }
            catch (MySqlException ex)
            { MessageBox.Show("Erreur_Total_Facture! " + ex.Message); }
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

        //Mise en forme du DataGridView ligne_commande en indiquant la largeur des colonnes que l'on désir afficher
        private void formeDtgRecapCommande(string requete)
        {
            chargeDtg(sqlDtg, dtgRecapCommande);
            //dtgRecapCommande.Columns[0].Width = 40;
            dtgRecapCommande.Columns[0].Visible = false;
            dtgRecapCommande.Columns[1].Width = 30;
            dtgRecapCommande.Columns[2].Width = 100;
            dtgRecapCommande.Columns[3].Width = 170;
            dtgRecapCommande.Columns[4].Width = 40;
            dtgRecapCommande.Width = 340 + 60;
        }

        //Chargement du DataGridView pour afficher le détail d'un menu sélectionner
        private void dtgDetailLoad()
        {
            string select = "SELECT COUNT(*), a.LibArticle";
            string from = " FROM Ligne_menu_Temp m, Ligne_Cde_Temp c, Article a";
            string where = " WHERE m.IdLigneCdeTmp = c.IdLigneCdeTmp";
            where += " AND m.CodeArticleChoixTmp = a.CodeArticle";
            where += " AND c.IdLigneCdeTmp = " + numLigneDtg.ToString();
            string group = " GROUP BY a.LibArticle";
            sqlDtg2 = select + from + where + group;
            fonctions.OuvrirConnection();
            if (fonctions.Existe(sqlDtg2))
            {
                fonctions.FermerConnection();
                try
                { formeDtgDetailMenu(sqlDtg2); }
                catch (MySqlException ex)
                { lblMessage.Text = ex.Message; }
            }
            else
            { dtgDetailMenu.DataSource = null; dtgDetailMenu.Refresh(); }
        }
        //Fonction commune de chargement du DataGridView
        private void chargeDtgMenu(string requete, DataGridView dtg)
        {
            try
            {
                fonctions.OuvrirConnection();
                dtg.DataSource = fonctions.Adapt(sqlDtg2);
                fonctions.FermerConnection();
            }
            catch (MySqlException ex)
            { MessageBox.Show("Erreur de chargement du DataGridView! " + ex.Message); }
        }
        //Mise en forme du DataGridView détail menu en indiquant la largeur de la colonne que l'on désir afficher
        private void formeDtgDetailMenu(string requete)
        {
            chargeDtgMenu(sqlDtg2, dtgDetailMenu);
            dtgDetailMenu.Columns[0].Width = 40;
            dtgDetailMenu.Columns[1].Width = 114;
            dtgRecapCommande.Width = 154;
        }
        #endregion

        #region "Traitements pour la modification d'une ligne de commande"
        //Traitement pour modifier la quantité d'une ligne sélectionnée
        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dtgRecapCommande.SelectedRows.Count != 1)
            { lblMessage.Text = "Veuillez selectionner une ligne et une seule!"; return; }
            lblMessage.Text = "";
            //On récupère le numéro de la ligne du DataGridView et le numéro de la ligne de commande temporaire dans la première cellule cachée
            int i = dtgRecapCommande.CurrentCell.RowIndex;
            numLigneDtg = int.Parse(dtgRecapCommande.Rows[i].Cells[0].Value.ToString());
            //On vérifie que la ligne sélectionnée n'est pas un menu
            string verifMenu = "SELECT * FROM ligne_menu_temp";
            verifMenu += " WHERE IdLigneCdeTmp = " + numLigneDtg;
            fonctions.OuvrirConnection();
            try
            {
                if (fonctions.Existe(verifMenu))
                { MessageBox.Show("Pas de modification du nombre de menu!"); fonctions.FermerConnection(); return; }
            }
            catch (Exception ex)
            { lblMessage.Text = "Erreur_Verif_ModifMenu: " + ex.Message; fonctions.FermerConnection(); }
            //On récupère la quantité que l'on veut changer
            nudModifQuantite.Value = int.Parse(dtgRecapCommande.Rows[i].Cells[1].Value.ToString());
        }

        //Traitement pour valider la modification de la quantité de la ligne
        private void btnValidModif_Click(object sender, EventArgs e)
        {
            quantiteArticle = int.Parse(nudModifQuantite.Value.ToString());
            //Mise à jour de la ligne modifiée
            string tableModif = "Ligne_cde_Temp";
            string setModif = " QuantiteCdeTmp = " + quantiteArticle;
            string whereModif = " IdLigneCdeTmp = " + numLigneDtg;
            try
            {
                fonctions.MiseAjour(tableModif, setModif, whereModif);
                dtgLoad();
            }
            catch (Exception ex)
            { lblMessage.Text = "Validation_Modif_Quantité " + ex.Message; }
            nudModifQuantite.Value = 1;
        }

        //Traitement pour supprimer une ligne sélectionnée
        private void btnSuppModif_Click(object sender, EventArgs e)
        {
            if (dtgRecapCommande.SelectedRows.Count != 1)
            { lblMessage.Text = "Veuillez selectionner une ligne et une seule!"; return; }
            lblMessage.Text = "";
            // On récupère le numéro de la ligne du DataGridView et le numéro de la ligne de commande temporaire dans la première cellule cachée
            int i = dtgRecapCommande.CurrentCell.RowIndex;
            numLigneDtg = int.Parse(dtgRecapCommande.Rows[i].Cells[0].Value.ToString());
            DialogResult resultat = MessageBox.Show("Êtes-vous sûr de voulior supprimer cette ligne définitivement?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultat == DialogResult.Yes)
            {
                try
                {
                    string tableMenuSupp = "Ligne_menu_temp";
                    string whereMenuSupp = " IdLigneCdeTmp = " + numLigneDtg;
                    fonctions.Supprimer(tableMenuSupp, whereMenuSupp);
                    dtgDetailLoad();
                    string tableSupp = "Ligne_cde_Temp";
                    string whereSupp = " IdLigneCdeTmp = " + numLigneDtg;
                    fonctions.Supprimer(tableSupp, whereSupp);
                    dtgLoad();
                }
                catch (Exception ex)
                { lblMessage.Text = "Validation_Suppression_Article " + ex.Message; }
            }
        }

        //Traitement pour afficher le détail d'un menu sélectionné
        private void btnDetailMenu_Click(object sender, EventArgs e)
        {
            if (dtgRecapCommande.SelectedRows.Count != 1)
            { lblMessage.Text = "Veuillez selectionner une ligne et une seule!"; return; }
            lblMessage.Text = "";
            // On récupère le numéro de la ligne du DataGridView et le numéro de la ligne de commande temporaire dans la première cellule cachée
            int i = dtgRecapCommande.CurrentCell.RowIndex;
            numLigneDtg = int.Parse(dtgRecapCommande.Rows[i].Cells[0].Value.ToString());
            dtgDetailLoad(); //dtgLoad();
        }
        #endregion

        //Traitement pour vérifier si le numéro de téléphone à une correspondance dans la table Client
        //Si correspondance récupération des données
        private void btnVerifTel_Click(object sender, EventArgs e)
        {
            tbxNomClient.Text = ""; tbxAdresse.Text = ""; tbxCommentaire.Text = "";
            //On vérifie la présence d'un numéro de téléphone
            if (string.IsNullOrEmpty(tbxNumTel.Text))
            { MessageBox.Show("Saisissez un numéro de téléphone!"); return; }
            //On stocke le numéro de téléphone
            numTel = tbxNumTel.Text.ToString();
            //On recherche si il existe une ligne, dans la table client, qui correspond au numéro recherché
            string requete = "SELECT * FROM client WHERE telClient = '" + numTel + "'";
            fonctions.OuvrirConnection();
            try
            {
                if (fonctions.Existe(requete))
                {
                    //Si correspondance on recupère les informationsnde la ligne
                    fonctions.FermerConnection();
                    fonctions.OuvrirConnection();
                    MySqlDataReader myReader = fonctions.Lire(requete);
                    myReader.Read();
                    numClient = Int32.Parse(myReader.GetValue(0).ToString());
                    tbxNomClient.Text = myReader.GetValue(1).ToString();
                    tbxAdresse.Text = myReader.GetValue(3).ToString();
                    tbxCodePostal.Text = myReader.GetValue(4).ToString();
                    tbxVille.Text = myReader.GetValue(5).ToString();
                    fonctions.FermerConnection();
                }
                else//Sinon on informe que le client est nouveau et sera créé en même temps que la validation de la commande
                { MessageBox.Show("Ce client sera créé en même temps que la commande!"); fonctions.FermerConnection(); }
            }
            catch (Exception ex)
            { lblMessage.Text = "Chargement Client Existant: " + ex.Message; fonctions.FermerConnection(); }
        }

        #region "Contrôle TextBox"
        private void tbxNumTel_Validating(object sender, CancelEventArgs e)
        {
            Regex rgTel = new Regex("^[0-9]{10}$");
            if (rgTel.IsMatch(tbxNumTel.Text))
            {
                errorProvider1.SetError(tbxNumTel, String.Empty);
                tbxNumTel.BackColor = Color.LightGreen;
            }
            else
            {
                errorProvider1.SetError(tbxNumTel, "Numéro de téléphone à 10 chiffres, sans espaces!");
                tbxNumTel.BackColor = Color.Red;
            }
        }

        private void tbxNomClient_Validating(object sender, CancelEventArgs e)
        {
            Regex rgNom = new Regex("^[A-ZÉÈÀÙÂÊÎÔÛÄËÏÖÜÇ]{1}[A-ZÉÈÀÙÂÊÎÔÛÄËÏÖÜÇ \\-']{0,24}$");
            if (rgNom.IsMatch(tbxNomClient.Text))
            {
                errorProvider1.SetError(tbxNomClient, String.Empty);
                tbxNomClient.BackColor = Color.LightGreen;
            }
            else
            {
                errorProvider1.SetError(tbxNomClient, "Majuscules, espaces et tirets autorisés!");
                tbxNomClient.BackColor = Color.Red;
            }
        }

        private void tbxAdresse_Validating(object sender, CancelEventArgs e)
        {
            Regex rgAdresse = new Regex("^([0-9a-zA-Zàâäéèêëïîôöùûüç \\-,']{1,50}){0,1}$");
            if (rgAdresse.IsMatch(tbxAdresse.Text))
            {
                errorProvider1.SetError(tbxAdresse, String.Empty);
                tbxAdresse.BackColor = Color.LightGreen;
            }
            else
            {
                errorProvider1.SetError(tbxAdresse, "Adresse non conforme, pas de caractères spéciaux!");
                tbxAdresse.BackColor = Color.Red;
            }
        }

        private void tbxCodePostal_Validating(object sender, CancelEventArgs e)
        {
            Regex rgCpostal = new Regex("^([0-9]{5}){0,1}$");
            if (rgCpostal.IsMatch(tbxCodePostal.Text))
            {
                errorProvider1.SetError(tbxCodePostal, String.Empty);
                tbxCodePostal.BackColor = Color.LightGreen;
            }
            else
            {
                errorProvider1.SetError(tbxCodePostal, "Code postal français!");
                tbxCodePostal.BackColor = Color.Red;
            }
        }

        private void tbxVille_Validating(object sender, CancelEventArgs e)
        {
            Regex rgVille = new Regex("^([A-ZÉÈÀÙÂÊÎÔÛÄËÏÖÜÇ]{1}[a-zéèàùâêîôûäëïöüç \\-]{0,24}){0,1}$");
            if (rgVille.IsMatch(tbxVille.Text))
            {
                errorProvider1.SetError(tbxVille, String.Empty);
                tbxVille.BackColor = Color.LightGreen;
            }
            else
            {
                errorProvider1.SetError(tbxVille, "Le nom de la ville commence par une majuscule, espaces et tirets autorisés!");
                tbxVille.BackColor = Color.Red;
            }
        }
        #endregion

        #region "Traitement pour choisir un mode de retrait"
        private void cbxLivraison_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxLivraison.Checked == true)
            {
                cbxEmporter.Checked = false; cbxSurPlace.Checked = false; modeRetrait = "Livraison";
                lblTel.Visible = true; tbxNumTel.Visible = true; btnVerifTel.Visible = true; gbxClient.Visible = true;
                tbxNumTel.BackColor = Color.LightGreen;
                tbxNomClient.BackColor = Color.LightGreen;
                tbxAdresse.BackColor = Color.LightGreen;
                tbxCodePostal.BackColor = Color.LightGreen;
                tbxVille.BackColor = Color.LightGreen;
            }
        }

        private void cbxEmporter_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxEmporter.Checked == true)
            {
                cbxLivraison.Checked = false; cbxSurPlace.Checked = false; modeRetrait = "Emporter";
                lblTel.Visible = true; tbxNumTel.Visible = true; btnVerifTel.Visible = true; gbxClient.Visible = true;
                tbxNumTel.BackColor = Color.LightGreen;
                tbxNomClient.BackColor = Color.LightGreen;
                tbxAdresse.BackColor = Color.White;
                tbxCodePostal.BackColor = Color.White;
                tbxVille.BackColor = Color.White;
            }
        }

        private void cbxSurPlace_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSurPlace.Checked == true)
            {
                cbxLivraison.Checked = false; cbxEmporter.Checked = false; modeRetrait = "Sur place";
                lblTel.Visible = false; tbxNumTel.Visible = false; btnVerifTel.Visible = false;
                gbxClient.Visible = false;
            }
        }
        #endregion

        #region "Traitement pour vérifier que l'on dispose de toutes les informations pour valider la commande"
        //Pour chaque mode de retrait, on contrôle que l'on dispose bien des informations nécessaires        
        private void checkValidation()
        {
            if (modeRetrait == "")
            { MessageBox.Show("Livraison, Emporter, ou Sur place!"); checkRetrait = false; return; }
            //Contrôle que les champs nécessaires pour la commande à emporter sont remplis
            if (modeRetrait == "Emporter")
            {
                if ((tbxNumTel.Text.Length == 0) || (tbxNomClient.Text.Length == 0))
                { MessageBox.Show("Remplir les champs en verts!"); checkRetrait = false; return; }
            }
            //Contrôle que les champs nécessaires pour la commande à livrer sont remplis
            if (modeRetrait == "Livraison")
            {
                if ((tbxAdresse.Text.Length == 0) || (tbxCodePostal.Text.Length == 0) || (tbxVille.Text.Length == 0))
                { MessageBox.Show("Remplir les champs en verts!"); checkRetrait = false; return; }
            }
            //Si le client mange sur place, le numClient sera celui de la pizzeria définit en premier dans la table Client
            //On récupère les informations connues
            if (modeRetrait == "Sur place")
            {
                numClient = 1;
                string surPlace = "SELECT * FROM client WHERE NumClient = 1";
                fonctions.OuvrirConnection();
                try
                {
                    if (fonctions.Existe(surPlace))
                    {
                        fonctions.FermerConnection();
                        fonctions.OuvrirConnection();
                        MySqlDataReader myReader = fonctions.Lire(surPlace);
                        myReader.Read();
                        tbxNomClient.Text = myReader.GetValue(1).ToString();
                        tbxAdresse.Text = myReader.GetValue(3).ToString();
                        tbxCodePostal.Text = myReader.GetValue(4).ToString();
                        tbxVille.Text = myReader.GetValue(5).ToString();
                        fonctions.FermerConnection();
                    }
                }
                catch (Exception ex)
                { lblMessage.Text = "Erreur_Load_Surplace: " + ex.Message; fonctions.FermerConnection(); }
            }
            //Au cas ou par étourderie, on aurait effacé un chiffre au numéro de téléphone
            if ((tbxNumTel.Text.Length > 0) && (tbxNumTel.Text.Length < 10))
            { checkRetrait = false; return; }
            //Contrôle qu'il y au moins une ligne de commande
            if (tbxTotal.Text.Length < 1)
            { MessageBox.Show("Il n'y a aucune commande de passée!"); checkRetrait = false; return; }
            checkRetrait = true;
        }
        #endregion

        //Traitement pour valider la commande
        //Contrôle du mode de retrait de la commande
        //Vérification des champs nécessaires en fonction du mode de retrait choisi
        //Création ou modification des coordonnées du client
        //Création de la ligne dans la table Commande et des différentes lignes dans la table Ligne_Commande
        //On créér en même temps une ligne dans la table Facture avec le montant de la commande ATTENTION si on modifie la commande il faudra modifier la facture
        private void btnValider_Click(object sender, EventArgs e)
        {
            checkValidation();
            if (checkRetrait == false)
            { return; }
            //Recupération des variables concernant la table clientele
            numTel = tbxNumTel.Text;
            nomClient = tbxNomClient.Text.Replace("'", "''");
            adrClient = tbxAdresse.Text.Replace("'", "''");
            cpostal = tbxCodePostal.Text;
            ville = tbxVille.Text;
            commAdresse = tbxCommentaire.Text.Replace("'", "''");
            //Recupération des variables concernant la table commande
            heureClient = dtpHeureDesire.Value.ToString("HH:mm");          
            
            //Vérification de l'existence du client avant création ou mise à jour
            string requete = "SELECT * FROM client WHERE numClient = " + numClient.ToString();
            fonctions.OuvrirConnection();
            try
            {
                if (fonctions.Existe(requete))
                {
                    //Si le client existe, on le met à jour
                    //Il peut s'agir d'un client qui avait déjà passer une commande à emporter et qui cet fois veut se faire livrer
                    //On mettra donc à jour l'adresse 
                    fonctions.FermerConnection();
                    string table = "client";
                    string set = " nomClient = '" + nomClient + "'";
                    set += ", adresseClient = '" + adrClient + "'";
                    set += ", cpClient = '" + cpostal + "'";
                    set += ", villeClient = '" + ville + "'";
                    set += ", PrecisionAdresse = '" + commAdresse + "'";
                    string where = " numClient = " + numClient.ToString();
                    fonctions.MiseAjour(table, set, where);
                }
                else
                {
                    //Si le client n'existe pas, on le creer
                    //Si commande emporter: on ajoute au minimum le numéro de téléphone et le nom                    
                    string table = "client";
                    string valeurs = numClient.ToString();
                    valeurs += ", '" + nomClient + "'";
                    valeurs += ", ''";
                    valeurs += ", '" + adrClient + "'";
                    valeurs += ", '" + cpostal + "'";
                    valeurs += ", '" + ville + "'";
                    valeurs += ", '" + numTel + "'";
                    valeurs += ", '', '', ''";
                    fonctions.Inserer(table, valeurs);
                }
            }
            catch (Exception ex)
            { lblMessage.Text = "Validation Modif Client : " + ex.Message; }

            //Création de la ligne de cette commande dans la table commande
            string tableCde = "commande";
            string valeursCde = numCde.ToString();
            valeursCde += ", '" + dateJour + "'";
            valeursCde += ", '" + modeRetrait + "'";
            valeursCde += ", '" + heureClient + "'";
            valeursCde += ", '" + reglementCde + "'";
            valeursCde += ", " + numClient.ToString();
            fonctions.Inserer(tableCde, valeursCde);

            //Récupération des lignes de commande temporaire pour les insérer dans la table ligne de commande définitive
            string sqlTransf = "INSERT INTO Ligne_commande SELECT IdLigneCdeTmp, QuantiteCdeTmp, CommentaireTmp, NumCommandeTmp, CodeArticleTmp";
            sqlTransf += " FROM Ligne_Cde_Temp";
            //sqlTransf += " WHERE NumCommandeTmp = " + numCde;
            try
            {
                fonctions.OuvrirConnection();
                fonctions.ExecCmd(sqlTransf);
                fonctions.FermerConnection();
            }
            catch (MySqlException ex)
            { MessageBox.Show("Erreur de transfert table Ligne_cde_Temp! " + ex.Message); }

            //Récupération des lignes du détail d'un menu temporaire pour les insérer dans la table ligne menu définitive
            string sqlTransMenu = "INSERT INTO ligne_menu SELECT IdLigneMenuTmp, CodeArticleChoixTmp, IdLigneCdeTmp";
            sqlTransMenu += " FROM ligne_menu_temp";
            try
            {
                fonctions.OuvrirConnection();
                fonctions.ExecCmd(sqlTransMenu);
                fonctions.FermerConnection();
            }
            catch (MySqlException ex)
            { MessageBox.Show("Erreur de transfert table Ligne_menu_Temp! " + ex.Message); }

            //Traitement pour vider la table temporaire ligne_cde_temp
            string sqlVide = "TRUNCATE Ligne_cde_Temp";
            try
            {
                fonctions.OuvrirConnection();
                fonctions.ExecCmd(sqlVide);
                fonctions.FermerConnection();
            }
            catch (MySqlException ex)
            { MessageBox.Show("Erreur vidage table Ligne_cde_Temp! " + ex.Message); }

            //Traitement pour vider la table temporaire ligne_menu_temp
            string sqlVideMenu = "TRUNCATE Ligne_menu_Temp";
            try
            {
                fonctions.OuvrirConnection();
                fonctions.ExecCmd(sqlVideMenu);
                fonctions.FermerConnection();
            }
            catch (MySqlException ex)
            { MessageBox.Show("Erreur vidage table Ligne_menu_Temp! " + ex.Message); }

            //Traitement pour créér une ligne correspondante dans la table Facture
            string tableFact = "Facture";
            string valeursFact = numCde.ToString();
            valeursFact += ", '" + dateJour + "'";
            valeursFact += ", '" + mntTotal + "'";
            valeursFact += ", '" + reglementCde + "'";
            valeursFact += ", " + numClient.ToString();
            fonctions.Inserer(tableFact, valeursFact);
            this.Close();
        }
    }
}
