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
    public partial class AjouterCommande : Form
    {
        #region "Déclaration des variables"
        //Déclaration des variables    
        string requete;//Pour passer les requetes Sql
        string sqlDtg;//Pour charger le DataGridView Ligne de commande
        //Concerne le numéro de la ligne pour le traitement sur le DataGridView
        int numLigneDtg;
        //Concerne le calcul du montant de la commande
        string mntTotal;
        //Concerne la récupération des données concernant la commande d'un article
        string codeArticle;
        int quantiteArticle;
        string commArticle;
        //Concerne la recupération de la ligne de commande et de la ligne de commande temporaire
        int numLigneCde;
        //Concerne la récupération du code de la ligne du détail menu 
        int numLigneMenu;
        //On stocke la valeur du numéro de ligne de commande qui correspond au menu validé        
        int numLigneCdeMenu;
        //Concerne le nombre de personne d'une formule
        int nbr;
        //Concerne la vérification du nombre d'article d'une formule
        bool checkMenu = true;

        #endregion

        #region "Déclaration des variables de transfert entre les Form"
        int v_numCde;
        //On récupère la valeur du code de la commande (= code de la facture) de la commande sélectionnée à l'écran de gestion des commandes
        public int V_numCde
        { set { v_numCde = value; } get { return v_numCde; } }

        string v_nomClient;
        //On récupère le nom du client  de la commande sélectionnée à l'écran de gestion des commandes
        public string V_nomClient
        { set { v_nomClient = value; } get { return v_nomClient; } }
        #endregion

        public AjouterCommande()
        {
            InitializeComponent();
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            //Mise à jour de la ligne facture si il y a eu modification
            string tableModif = "Facture";
            string setModif = " MntFacture = " + mntTotal;
            string whereModif = " NumFacture = " + v_numCde.ToString();
            try
            {
                fonctions.MiseAjour(tableModif, setModif, whereModif);
                dtgLoad();
            }
            catch (Exception ex)
            { lblMessage.Text = "Validation_Modif_Facture " + ex.Message; }
            this.Close();
        }

        private void AjouterCommande_Load(object sender, EventArgs e)
        {
            tbxNumCde.Text = v_numCde.ToString();
            tbxNomClient.Text = v_nomClient.ToString();
            dtgLoad();

            codeLigneCde();
            codeLigneMenu();

            comboTypePizza();
            comboSupplement();
            comboPlat();
            combBoisson();
            combMenu();
            combChoixMenu();
            
        }

        #region "Traitement pour l'affichage du DataGridView des lignes de commande"
        //Chargement du DataGridView de la table ligne_commande qui se met à jour dynamiquement à chaque article ajouté
        private void dtgLoad()
        {
            //On affiche dans le DataGridView une colonne en plus pour le prix total par quantité d'article commandée
            string select = "SELECT l.IdLigneCde, l.QuantiteCde, a.LibArticle, l.Commentaire, round(l.QuantiteCde * a.PrixTTC_Article, 2) as total";
            string from = " FROM Ligne_Commande l, Article a";
            string where = " WHERE l.CodeArticle = a.CodeArticle";
            where += " AND NumCommande = " + v_numCde.ToString();
            sqlDtg = select + from + where;
            fonctions.OuvrirConnection();
            if (fonctions.Existe(sqlDtg))
            {
                fonctions.FermerConnection();
                try
                { formedtgCommandeDetail(sqlDtg); }
                catch (MySqlException ex)
                { lblMessage.Text = ex.Message; }
            }
            
            //On recupère le montant total de la facture dans une TextBox sous le DataGridViaew
            string total = "SELECT l.IdLigneCde, l.QuantiteCde, a.LibArticle, l.Commentaire, SUM(round(l.QuantiteCde * a.PrixTTC_Article, 2)) as total";
            total += " FROM Ligne_Commande l, Article a";
            total += " WHERE l.CodeArticle = a.CodeArticle";
            total += " AND NumCommande = " + v_numCde.ToString();
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
        private void formedtgCommandeDetail(string requete)
        {
            chargeDtg(sqlDtg, dtgCommandeDetail);
            //dtgRecapCommande.Columns[0].Width = 40;
            dtgCommandeDetail.Columns[0].Visible = false;
            dtgCommandeDetail.Columns[1].Width = 30;
            dtgCommandeDetail.Columns[2].Width = 100;
            dtgCommandeDetail.Columns[3].Width = 170;
            dtgCommandeDetail.Columns[4].Width = 40;
            dtgCommandeDetail.Width = 340 + 60;
        }
        #endregion

        //Traitement pour attribuer un numéro de ligne de commande         
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
            { lblMessage.Text = "Chargement_Num_LigneCommande: " + ex.Message; fonctions.FermerConnection(); }            
        }

        //Traitement pour attribuer un numéro de ligne pour le détail du menu         
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
        }

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
        private void cboxTypePizza_SelectedValueChanged_1(object sender, EventArgs e)
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
        private void cboxTypePlat_SelectedValueChanged_1(object sender, EventArgs e)
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
        private void cboxTypeBoisson_SelectedValueChanged_1(object sender, EventArgs e)
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
        private void btnAjoutPizza_Click_1(object sender, EventArgs e)
        {
            //Récupération des champs saisis
            codeArticle = cboxPizza.SelectedValue.ToString();
            quantiteArticle = int.Parse(nudQuantitePizza.Value.ToString());
            commArticle = tbxCommPizza.Text;

            try
            {
                string table = "Ligne_commande";
                string valeur = numLigneCde.ToString();
                valeur += ", " + quantiteArticle;
                valeur += ", '" + commArticle + "'";
                valeur += ", " + v_numCde.ToString();
                valeur += ", " + codeArticle;

                fonctions.Inserer(table, valeur);
                dtgLoad();
            }
            catch (Exception ex)
            { lblMessage.Text = "Validation_Ajout_Pizza " + ex.Message; }
            //Remise à vide du champ commentaire et remise à 1 du compteur de quantité
            nudQuantitePizza.Value = 1; tbxCommPizza.Text = ""; numLigneCde = numLigneCde + 1;
        }

        //Traitement pour ajouter un supplément dans la table temporaire de commande
        private void btnSuppAjout_Click_1(object sender, EventArgs e)
        {
            codeArticle = cboxSupplement.SelectedValue.ToString();
            quantiteArticle = int.Parse(nudQuantiteSupp.Value.ToString());

            try
            {
                string table = "Ligne_commande";
                string valeur = numLigneCde.ToString();
                valeur += ", " + quantiteArticle;
                valeur += ", ''";
                valeur += ", " + v_numCde.ToString();
                valeur += ", " + codeArticle;

                fonctions.Inserer(table, valeur);
                dtgLoad();
            }
            catch (Exception ex)
            { lblMessage.Text = "Validation_Ajout_Supp " + ex.Message; }
            //Remise à vide du champ commentaire et remise à 1 du compteur de quantité
            nudQuantiteSupp.Value = 1; numLigneCde = numLigneCde + 1;
        }

        //Traitement pour ajouter un plat dans la table temporaire de commande
        private void btnAjoutPlat_Click_1(object sender, EventArgs e)
        {
            codeArticle = cboxPlat.SelectedValue.ToString();
            quantiteArticle = int.Parse(nudQuantitePlat.Value.ToString());
            commArticle = tbxCommPlat.Text;

            try
            {
                string table = "Ligne_commande";
                string valeur = numLigneCde.ToString();
                valeur += ", " + quantiteArticle;
                valeur += ", '" + commArticle + "'";
                valeur += ", " + v_numCde.ToString();
                valeur += ", " + codeArticle;

                fonctions.Inserer(table, valeur);
                dtgLoad();
            }
            catch (Exception ex)
            { lblMessage.Text = "Validation_Ajout_Plat " + ex.Message; }
            //Remise à vide du champ commentaire et remise à 1 du compteur de quantité
            nudQuantitePlat.Value = 1; tbxCommPlat.Text = ""; numLigneCde = numLigneCde + 1;
        }

        //Traitement pour ajouter une boisson dans la table temporaire de commande
        private void btnAjoutBoisson_Click_1(object sender, EventArgs e)
        {
            codeArticle = cboxBoisson.SelectedValue.ToString();
            quantiteArticle = int.Parse(nudQuantiteBoisson.Value.ToString());

            try
            {
                string table = "Ligne_commande";
                string valeur = numLigneCde.ToString();
                valeur += ", " + quantiteArticle;
                valeur += ", ''";
                valeur += ", " + v_numCde.ToString();
                valeur += ", " + codeArticle;

                fonctions.Inserer(table, valeur);
                dtgLoad();
            }
            catch (Exception ex)
            { lblMessage.Text = "Validation_Ajout_Supp " + ex.Message; }
            //Remise à vide du champ commentaire et remise à 1 du compteur de quantité
            nudQuantiteSupp.Value = 1; numLigneCde = numLigneCde + 1;
        }
        #endregion

        #region "Traitement pour l'ajout du détail d'un menu"
        //Remise à vide des ListBox lorsque l'on change de formule
        private void cboxTypeMenu_SelectedValueChanged_1(object sender, EventArgs e)
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
        private void btnAjoutPmenu_Click_1(object sender, EventArgs e)
        {
            nbreListBox();

            if (lboxPizzaMenu.Items.Count <= (nbr - 1))
            { lboxPizzaMenu.Items.Add(cboxPizzaMenu.SelectedValue.ToString()); }
        }
        //Traitement pour ajouter les boissons du menu
        private void btnAjoutBmenu_Click_1(object sender, EventArgs e)
        {
            nbreListBox();

            if (lboxBoissonMenu.Items.Count <= (nbr - 1))
            { lboxBoissonMenu.Items.Add(cboxBoissonMenu.SelectedValue.ToString()); }
        }
        //Traitement pour supprimer une pizza de la ListBox
        private void lboxPizzaMenu_DoubleClick_1(object sender, EventArgs e)
        {
            string dropPizza = lboxPizzaMenu.SelectedItem.ToString();
            lboxPizzaMenu.Items.Remove(dropPizza);
        }
        //Traitement pour supprimer une boisson de la ListBox
        private void lboxBoissonMenu_DoubleClick_1(object sender, EventArgs e)
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
        private void btnAjoutMenu_Click_1(object sender, EventArgs e)
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
                string table = "Ligne_commande";
                string valeur = numLigneCde.ToString();
                valeur += ", " + quantiteArticle;
                valeur += ", '" + commArticle + "'";
                valeur += ", " + v_numCde.ToString();
                valeur += ", " + codeArticle;

                fonctions.Inserer(table, valeur);
                dtgLoad();
            }
            catch (Exception ex)
            { lblMessage.Text = "Validation_Ajout_Supp " + ex.Message; }
            //Remise à vide du champ commentaire 
            tbxCommMenu.Text = "";
            numLigneCdeMenu = numLigneCde;//Les lignes de détail du menu se réfèrent au numéro de la ligne de commande où se situe le menu
            numLigneCde = numLigneCde + 1;//On incrémente de 1 pour la commande de l'article suivant

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
                    string tableMenu = "Ligne_menu";
                    string valeurMenu = numLigneMenu.ToString();
                    valeurMenu += ", " + codeArticleMenu;
                    valeurMenu += ", " + numLigneCdeMenu;
                    fonctions.Inserer(tableMenu, valeurMenu);
                    //On incrémente le numéro de ligne de 1
                    numLigneMenu = numLigneMenu + 1;
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
                    string tableMenu = "Ligne_menu";
                    string valeurMenu = numLigneMenu.ToString();
                    valeurMenu += ", " + codeArticleMenu;
                    valeurMenu += ", " + numLigneCdeMenu;
                    fonctions.Inserer(tableMenu, valeurMenu);
                    numLigneMenu = numLigneMenu + 1;
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
                    string tableMenu = "Ligne_menu";
                    string valeurMenu = numLigneMenu.ToString();
                    valeurMenu += ", " + codeArticleMenu;
                    valeurMenu += ", " + numLigneCdeMenu;
                    fonctions.Inserer(tableMenu, valeurMenu);
                    numLigneMenu = numLigneMenu + 1;
                }
                catch (Exception ex)
                { lblMessage.Text = "Erreur_Dessert_Menu " + ex.Message; }
            }
            lboxPizzaMenu.Items.Clear(); lboxBoissonMenu.Items.Clear();
            combMenu(); combChoixMenu();
        }
        #endregion

        //Traitement pour supprimer une ligne sélectionnée
        private void btnSuppModif_Click_1(object sender, EventArgs e)
        {
            if (dtgCommandeDetail.SelectedRows.Count != 1)
            { lblMessage.Text = "Veuillez selectionner une ligne et une seule!"; return; }
            lblMessage.Text = "";
            // On récupère le numéro de la ligne du DataGridView et le numéro de la ligne de commande temporaire dans la première cellule cachée
            int i = dtgCommandeDetail.CurrentCell.RowIndex;
            numLigneDtg = int.Parse(dtgCommandeDetail.Rows[i].Cells[0].Value.ToString());
            DialogResult resultat = MessageBox.Show("Êtes-vous sûr de voulior supprimer cette ligne définitivement?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultat == DialogResult.Yes)
            {
                try
                {
                    string tableMenuSupp = "Ligne_menu";
                    string whereMenuSupp = " IdLigneCde = " + numLigneDtg;
                    fonctions.Supprimer(tableMenuSupp, whereMenuSupp);
                    //dtgDetailLoad();
                    string tableSupp = "Ligne_commande";
                    string whereSupp = " IdLigneCde = " + numLigneDtg;
                    fonctions.Supprimer(tableSupp, whereSupp);
                    dtgLoad();
                }
                catch (Exception ex)
                { lblMessage.Text = "Validation_Suppression_Article " + ex.Message; }
            }
        }

        //Traitement pour valider l'ajout à la commande
        //On met à jour en même temps la ligne dans la table Facture avec le montant de la commande 
        private void btnValider_Click(object sender, EventArgs e)
        {
            //Mise à jour de la ligne modifiée
            string tableModif = "Facture";
            string setModif = " MntFacture = " + mntTotal;
            string whereModif = " NumFacture = " + v_numCde.ToString();
            try
            {
                fonctions.MiseAjour(tableModif, setModif, whereModif);
                dtgLoad();
            }
            catch (Exception ex)
            { lblMessage.Text = "Validation_Modif_Facture " + ex.Message; }
            this.Close();
        } 
    }
}
