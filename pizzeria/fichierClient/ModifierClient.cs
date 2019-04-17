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
    public partial class ModifierClient : Form
    {
        //Déclaration des variables
        decimal v_numClient;
        string nomClient;
        string prenClient;
        string adrClient;
        string cpostal;
        string ville;
        string telClient;
        string mailClient;
        string CommAdresse;
        string planClient;

        //Récupère la valeur trouvée(numClient) dans le datagrid de l'écran gestion client lors du traitement demande de modification
        public decimal V_numClient
        { set { v_numClient = value; } get { return v_numClient; } }

        //Initialization des composants
        public ModifierClient()
        {
            InitializeComponent();
        }

        //Traitement pour fermer la fenêtre en cours
        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Traitement de chargement de la forme, indication des champs obligatoires
        private void ModifierClient_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            tbxNomClient.BackColor = Color.LightGreen;
            tbxAdresse.BackColor = Color.LightGreen;
            tbxCodepostal.BackColor = Color.LightGreen;
            tbxVille.BackColor = Color.LightGreen;
            tbxTel.BackColor = Color.LightGreen;

            try
            {
                // recherche de l'enregistrement du client connu par son numClient
                string requete = "SELECT * FROM client WHERE numClient = " + v_numClient;
                fonctions.OuvrirConnection();
                MySqlDataReader myReader = fonctions.Lire(requete);
                myReader.Read();
                tbxNomClient.Text = myReader.GetValue(1).ToString();
                tbxPrenClient.Text = myReader.GetValue(2).ToString();
                tbxAdresse.Text = myReader.GetValue(3).ToString();
                tbxCodepostal.Text = myReader.GetValue(4).ToString();
                tbxVille.Text = myReader.GetValue(5).ToString();
                tbxTel.Text = myReader.GetValue(6).ToString();
                tbxMail.Text = myReader.GetValue(7).ToString();
                tbxPlanMappy.Text = myReader.GetValue(8).ToString();
                fonctions.FermerConnection();
            }
            catch (Exception ex)
            { lblMessage.Text = "Load_Modif_Client : " + ex.Message; fonctions.FermerConnection(); }
            //Le prenom et l'adresse mail ne sont pas obligatoires lors de la création d'un client
            //Pour éviter d'avoir une erreur avec l'errorProvider, on vide les TextBox
            if (String.IsNullOrWhiteSpace(tbxPrenClient.Text))
            { tbxPrenClient.Text = ""; }
            if (String.IsNullOrWhiteSpace(tbxMail.Text))
            { tbxMail.Text = "";}
        }//Fin traitement de chargement de la forme

        #region "Contrôle TextBox"
        //Traitement du contrôle de la saisie du nom du client
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

        //Traitement du contrôle de la saisie du prénom
        private void tbxPrenClient_Validating(object sender, CancelEventArgs e)
        {
            //La saisie du prénom n'est pas obligatoire
            Regex rgPrenom = new Regex("^([A-ZÉÈÀÙÂÊÎÔÛÄËÏÖÜÇ]{1}[a-zéèàùâêîôûäëïöüç \\-]{0,24}){0,1}$");
            if (rgPrenom.IsMatch(tbxPrenClient.Text))
            {
                errorProvider1.SetError(tbxPrenClient, String.Empty);
                tbxPrenClient.BackColor = Color.White;
            }
            else
            {
                errorProvider1.SetError(tbxPrenClient, "Commence par une majuscule, espaces et tirets autorisés!");
                tbxPrenClient.BackColor = Color.Red;
            }
        }

        //Traitement du contrôle de la saisie de l'adresse
        private void tbxAdresse_Validating(object sender, CancelEventArgs e)
        {
            Regex rgAdresse = new Regex("^[0-9a-zA-Zàâäéèêëïîôöùûüç \\-,']{1,50}$");
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

        //Traitement du contrôle de la saisie du code postal
        private void tbxCodepostal_Validating(object sender, CancelEventArgs e)
        {
            Regex rgCpostal = new Regex("^[0-9]{5}$");
            if (rgCpostal.IsMatch(tbxCodepostal.Text))
            {
                errorProvider1.SetError(tbxCodepostal, String.Empty);
                tbxCodepostal.BackColor = Color.LightGreen;
            }
            else
            {
                errorProvider1.SetError(tbxCodepostal, "Code postal français!");
                tbxCodepostal.BackColor = Color.Red;
            }
        }

        //Traitement du contrôle de la saisie de la ville
        private void tbxVille_Validating(object sender, CancelEventArgs e)
        {
            Regex rgVille = new Regex("^[A-ZÉÈÀÙÂÊÎÔÛÄËÏÖÜÇ]{1}[a-zéèàùâêîôûäëïöüç \\-]{0,24}$");
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

        //Traitement du contrôle de la saisie du numéro de téléphone
        private void tbxTel_Validating(object sender, CancelEventArgs e)
        {
            Regex rgTel = new Regex("^[0-9]{10}$");
            if (rgTel.IsMatch(tbxTel.Text))
            {
                errorProvider1.SetError(tbxTel, String.Empty);
                tbxTel.BackColor = Color.LightGreen;
            }
            else
            {
                errorProvider1.SetError(tbxTel, "Numéro de téléphone à 10 chiffres, sans espaces!");
                tbxTel.BackColor = Color.Red;
            }
        }

        //Traitement du contrôle de la saisie de l'adresse mail
        private void tbxMail_Validating(object sender, CancelEventArgs e)
        {
            //La saisie de l'adresse mail est facultative
            Regex rgMail = new Regex("^([a-zA-Z0-9._-]+@[a-zA-Z0-9.-]{2,}[.][a-zA-Z]{2,4}){0,1}$");
            if (rgMail.IsMatch(tbxMail.Text))
            {
                errorProvider1.SetError(tbxMail, String.Empty);
                tbxMail.BackColor = Color.White;
            }
            else
            {
                errorProvider1.SetError(tbxMail, "Adresse mail normalisée!");
                tbxMail.BackColor = Color.Red;
            }
        }
        #endregion

        //Traitement pour afficher l'adresse d'un client sur une carte Mappy et/ou enregistrement du lien dans une textBox
        private void btnMappyClient_Click(object sender, EventArgs e)
        {
            planClient = tbxPlanMappy.Text;
            //Verification qu'il existe déjà un lien Mappy
            if (tbxPlanMappy.Text.Length != 0)
            { webBrowserPlan.Navigate(planClient); }
            //Verification que les champs pour créer l'adresse ne sont pas vides
            adrClient = tbxAdresse.Text;
            cpostal = tbxCodepostal.Text;
            ville = tbxVille.Text;
            if ((tbxAdresse.Text.Length == 0) || (tbxCodepostal.Text.Length == 0) || (tbxVille.Text.Length == 0))
            { MessageBox.Show("Remplissez les champs adresse, code postal et ville pour afficher la carte!"); return; }
            //Conversion de l'adresse de départ
            string adresseDepart = "18b, Boulevard André Maginot";
            string departMappy = adresseDepart.Replace(" ", "+");
            //Conversion de l'adresse d'arrivée, celle du client
            string adressComplete = adrClient + ", " + cpostal + ", " + ville;
            string arriveMappy = adressComplete.Replace(" ", "+");
            //Création du lien Mappy
            planClient = "http://fr.mappy.com/itinerary#d[]=" + arriveMappy;
            planClient += ",+Lorraine,+France" + "&d[]=" + departMappy;
            planClient += ",+57000,+Metz,+Lorraine,+France";
            //Recupération du lien créé dans la textbox PlanMappy
            tbxPlanMappy.Text = planClient;
            //Affichage de la carte dans le webBrowser
            webBrowserPlan.Navigate(planClient);
        }//Fin traitement carte Mappt      

        //Traitement de la modification de la fiche client
        private void btnValider_Click(object sender, EventArgs e)
        {
            //Vérification que tous les champs obligatoires sont bien remplis
            if ((tbxNomClient.Text.Length == 0) || (tbxAdresse.Text.Length == 0)
                || (tbxCodepostal.Text.Length == 0) || (tbxVille.Text.Length == 0) || (tbxTel.Text.Length == 0))
            {
                MessageBox.Show("Tous les champs demandés ne sont pas remplis!");
                return;
            }
            //Verification qu'il n'éxiste pas un nom de client avec le même numéro de téléphone
            string verif = "SELECT * FROM client WHERE ";
            verif += "nomclient = '" + nomClient + "'";
            verif += " AND telclient = '" + telClient + "'";
            fonctions.OuvrirConnection();
            if (fonctions.Existe(verif))
            {
                MessageBox.Show("Ce client associé à ce numéro de téléphone existe déjà!");
                fonctions.FermerConnection();
                return;
            }
            //Contrôle que le lien Mappy a bien été changé si l'adresse a été modifiée
            DialogResult Resultat = MessageBox.Show("Si l'adresse a été changée, avez-vous pensé à générer un nouveau lien Mappy?\nCliquez sur 'non' pour le générer maintenant", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Resultat == DialogResult.No)
            {
                //Conversion de l'adresse de départ
                string adresseDepart = "18b, Boulevard André Maginot";
                string departMappy = adresseDepart.Replace(" ", "+");
                //Conversion de l'adresse d'arrivée, celle du client
                string adressComplete = adrClient + ", " + cpostal + ", " + ville;
                string arriveMappy = adressComplete.Replace(" ", "+");
                //Création du lien Mappy
                planClient = "http://fr.mappy.com/itinerary#d[]=" + arriveMappy;
                planClient += ",+Lorraine,+France" + "&d[]=" + departMappy;
                planClient += ",+57000,+Metz,+Lorraine,+France";
                //Recupération du lien créé dans la textbox PlanMappy
                tbxPlanMappy.Text = planClient;
            }
            //Recupération des saisies valides
            nomClient = tbxNomClient.Text.Replace("'", "''");
            prenClient = tbxPrenClient.Text;
            adrClient = tbxAdresse.Text.Replace("'", "''");
            cpostal = tbxCodepostal.Text;
            ville = tbxVille.Text;
            telClient = tbxTel.Text;
            mailClient = tbxMail.Text;
            CommAdresse = tbxCommAdresse.Text.Replace("'", "''");
            //Mise à jour de la ligne dans la table client
            try
            {
                string table = "client";
                string set = " nomClient = '" + nomClient + "'";
                set += ", prenomClient = '" + prenClient + "'";
                set += ", adresseClient = '" + adrClient + "'";
                set += ", cpClient = '" + cpostal + "'";
                set += ", villeClient = '" + ville + "'";
                set += ", telClient = '" + telClient + "'";
                set += ", mailClient = '" + mailClient + "'";
                set += ", PrecisionAdresse = '" + CommAdresse + "'";
                set += ", planClient = '" + planClient + "'";
                string where = " numClient = " + v_numClient.ToString();
                fonctions.MiseAjour(table, set, where);
                //Retour sur la forme gestion des clients                
                this.Close();
            }
            catch (Exception ex)
            { lblMessage.Text = "Validation Modif Client : " + ex.Message; }
        }//Fin traitement de la mise à jour d'un client          
    }
}
