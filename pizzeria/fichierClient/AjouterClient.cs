using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace pizzeria
{
    public partial class AjouterClient : Form
    {
        //Déclaration des variables
        int numclient;
        string nomClient;
        string prenClient;
        string adrClient;
        string cpostal;
        string ville;
        string telClient;
        string mailClient;
        string CommAdresse;
        string planClient;

        //Initialization des composants
        public AjouterClient()
        {
            InitializeComponent();
        }

        //Traitement pour fermer la fenêtre en cours
        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Traitement de chargement de la forme, indication des champs obligatoires
        private void AjouterClient_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            tbxCodepostal.Text = "57000";
            tbxVille.Text = "Metz";
            tbxNomClient.BackColor = Color.LightGreen;
            tbxAdresse.BackColor = Color.LightGreen;
            tbxCodepostal.BackColor = Color.LightGreen;
            tbxVille.BackColor = Color.LightGreen;
            tbxTel.BackColor = Color.LightGreen;

            //Traitement pour attribuer un numéro de client
            string requete = "SELECT * FROM Client";
            fonctions.OuvrirConnection();
            try
            {
                //Verification qu'il existe une ligne dans la table Client
                if (fonctions.Existe(requete))
                {
                    fonctions.FermerConnection();
                    //Si il existe des enregistrements on prend le numéro de client max et on ajoute 1
                    requete = "SELECT MAX(NumClient)+1 FROM Client";
                    fonctions.OuvrirConnection();
                    numclient = fonctions.Compte(requete);
                    fonctions.FermerConnection();
                }
                else
                {   //Sinon le numéro de commande commence à 1
                    numclient = 1; fonctions.FermerConnection();
                }                
            }
            catch (Exception ex)
            { lblMessage.Text = "Chargement Num Client: " + ex.Message; fonctions.FermerConnection(); }
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

        //Traitement pour afficher l'adresse d'un client sur une carte Mappy et enregistrement du lien dans une textBox
        private void btnMappyClient_Click(object sender, EventArgs e)
        {
            //Verification que les champs pour créer l'adresse ne sont pas vides
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
        }
        
        //Traitement de l'enregistrement d'un nouveau client
        private void btnValider_Click(object sender, EventArgs e)
        {
            nomClient = tbxNomClient.Text.Replace("'", "''");
            prenClient = tbxPrenClient.Text;
            adrClient = tbxAdresse.Text.Replace("'", "''");
            cpostal = tbxCodepostal.Text;
            ville = tbxVille.Text;
            telClient = tbxTel.Text;
            mailClient = tbxMail.Text;
            CommAdresse = tbxCommAdresse.Text.Replace("'", "''");
            //Vérification que tous les champs obligatoires sont bien remplis
            if ((tbxNomClient.Text.Length == 0) || (tbxAdresse.Text.Length == 0)
                || (tbxCodepostal.Text.Length == 0) || (tbxVille.Text.Length == 0) || (tbxTel.Text.Length == 0))
            {
                MessageBox.Show("Tous les champs demandés ne sont pas remplis!");
                return;
            }
            //Verification qu'il n'éxiste pas un client avec le même numéro de téléphone
            string verif = "SELECT * FROM client WHERE ";
            verif += "nomclient = '" + nomClient + "'";
            verif += " AND telclient = '" + telClient + "'";
            fonctions.OuvrirConnection();
            if (fonctions.Existe(verif))
            { MessageBox.Show("Ce client associé à ce numéro de téléphone existe déjà!");
            fonctions.FermerConnection();
            return;
            }
            //Enregistrement de la ligne dans la table client
            try
            {
                string table = "client";
                string valeurs = numclient.ToString();
                valeurs += ", '" + nomClient + "'";
                valeurs += ", '" + prenClient + "'";
                valeurs += ", '" + adrClient + "'";
                valeurs += ", '" + cpostal + "'";
                valeurs += ", '" + ville + "'";
                valeurs += ", '" + telClient + "'";
                valeurs += ", '" + mailClient + "'";
                valeurs += ", '" + CommAdresse + "'";
                valeurs += ", '" + planClient + "'";

                fonctions.Inserer(table, valeurs);
                //Retour sur la form gestion des clients                
                this.Close();
            }
            catch (Exception ex)
            { lblMessage.Text = "Validation Création Client " + ex.Message; }
        }//Fin traitement de l'enregistrement d'un nouveau client               
    }
}
