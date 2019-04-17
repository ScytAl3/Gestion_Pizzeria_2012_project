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
    public partial class ReglementCommande : Form
    {
        #region "Déclaration des variables utilisées dans cette Form"
        //Déclaration des variables
        float mntEspece;
        float mntCb;
        float mntSimplyOrder;
        float mntCheque;
        float mntCtr;
        float mntSaisi;
        float mntReste;
        int numRegl;
        string etatReglement = "Payée";
        #endregion

        #region "Déclaration des variables de transfert entre les Form"
        float v_total;
        //Récupère la valeur du montant de la commande sélectionnée à l'écran de gestion des commandes
        public float V_total
        { set { v_total = value; } get { return v_total; } }

        int v_numCde;
        //On récupère la valeur du code de la commande (= code de la facture) de la commande sélectionnée à l'écran de gestion des commandes
        public int V_numCde
        { set { v_numCde = value; } get { return v_numCde; } }

        string v_nomClient;
        //On récupère le nom du client  de la commande sélectionnée à l'écran de gestion des commandes
        public string V_nomClient
        { set { v_nomClient = value; } get { return v_nomClient; } }
        #endregion

        public ReglementCommande()
        {
            InitializeComponent();
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReglementCommande_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            tbxTotalCommande.Text = v_total.ToString();
            mntReste = v_total;
            tbxSaisieMnt.Clear();
            tbxNumFacture.Text = v_numCde.ToString();
            tbxNomClient.Text = v_nomClient.ToString();

            creaNumReglement();
        }

        #region "Traitement des boutons numériques, clear et la virgule"
        private void btnUn_Click(object sender, EventArgs e)
        {
            tbxSaisieMnt.Text = tbxSaisieMnt.Text + btnUn.Text;
        }

        private void btnDeux_Click(object sender, EventArgs e)
        {
            tbxSaisieMnt.Text = tbxSaisieMnt.Text + btnDeux.Text;
        }

        private void btnTrois_Click(object sender, EventArgs e)
        {
            tbxSaisieMnt.Text = tbxSaisieMnt.Text + btnTrois.Text;
        }

        private void btnQuattre_Click(object sender, EventArgs e)
        {
            tbxSaisieMnt.Text = tbxSaisieMnt.Text + btnQuattre.Text;
        }

        private void btnCinq_Click(object sender, EventArgs e)
        {
            tbxSaisieMnt.Text = tbxSaisieMnt.Text + btnCinq.Text;
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            tbxSaisieMnt.Text = tbxSaisieMnt.Text + btnSix.Text;
        }

        private void btnSept_Click(object sender, EventArgs e)
        {
            tbxSaisieMnt.Text = tbxSaisieMnt.Text + btnSept.Text;
        }

        private void btnHuit_Click(object sender, EventArgs e)
        {
            tbxSaisieMnt.Text = tbxSaisieMnt.Text + btnHuit.Text;
        }

        private void btnNeuf_Click(object sender, EventArgs e)
        {
            tbxSaisieMnt.Text = tbxSaisieMnt.Text + btnNeuf.Text;
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            tbxSaisieMnt.Text = tbxSaisieMnt.Text + btnZero.Text;
        }

        private void btnVirgule_Click(object sender, EventArgs e)
        {
            //On vérifie qu'il n'y a pas déjà une virgule
            if (tbxSaisieMnt.Text.ToString().IndexOf(",") != -1)
            { tbxSaisieMnt.Text = tbxSaisieMnt.Text; }
            //On ajoute un 0 si la virgule est le premier caractère saisi
            else if (string.IsNullOrEmpty(tbxSaisieMnt.Text))
            { tbxSaisieMnt.Text = "0" + btnVirgule.Text; }
            //Sinon on ajoute la vigule au nombre saisi
            else
            { tbxSaisieMnt.Text = tbxSaisieMnt.Text + btnVirgule.Text; }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxSaisieMnt.Clear();
        }
        #endregion

        #region "Traitement des boutons des types de reglement"
        //Reglement en especes
        //Si on appuie sur le bouton sans saisir de montant: le reglement est fait en totalité en espèces
        //Si non: on ajoute le montant saisi dans la TextBox espèce et on affiche ce qu'il reste à payer
        private void btnEspece_Click(object sender, EventArgs e)
        {
            //On vérifie si il y a saisie
            if (string.IsNullOrEmpty(tbxSaisieMnt.Text))
            {
                mntSaisi = mntReste; //On solde en espèces ce qu'il reste à payer
                mntReste = mntReste - mntSaisi; tbxResteEncore.Text = mntReste.ToString();//On calcul la diffèrence (normalement 0) et on l'affiche
                mntEspece = mntEspece + mntSaisi; tbxMntEspece.Text = mntEspece.ToString();//On ajoute le montant saisi dans la TextBox reglement espèce
            }
            else if ((mntReste >= 0) && (mntReste != 0))
            {
                mntSaisi = float.Parse(tbxSaisieMnt.Text);//On récupère le montant saisi
                mntReste = mntReste - mntSaisi;//On calcul ce qu'il reste à payer
                mntEspece = mntEspece + mntSaisi;//Si il y a d'autre réglement en espèces on les additionnent
                tbxSaisieMnt.Clear();//On efface la dernière saisie pour permettre d'en faire une autre
                tbxMntEspece.Text = mntEspece.ToString();//On affiche le montant total des espèces
                tbxResteEncore.Text = mntReste.ToString();//On affiche ce qu'il reste à payer
            }
            tbxSaisieMnt.Clear();
        }

        private void btnCarte_Click(object sender, EventArgs e)
        {
            //On vérifie si il y a saisie
            if (string.IsNullOrEmpty(tbxSaisieMnt.Text))
            {
                mntSaisi = mntReste;
                mntReste = mntReste - mntSaisi; tbxResteEncore.Text = mntReste.ToString();
                mntCb = mntCb + mntSaisi; tbxMntCb.Text = mntCb.ToString();
            }
            else if ((mntReste >= 0) && (mntReste != 0))
            {
                mntSaisi = float.Parse(tbxSaisieMnt.Text);
                mntReste = mntReste - mntSaisi;
                mntCb = mntCb + mntSaisi;
                tbxSaisieMnt.Clear();
                tbxMntCb.Text = mntCb.ToString();
                tbxResteEncore.Text = mntReste.ToString();
            }
            tbxSaisieMnt.Clear();
        }

        private void btnSimplyOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxSaisieMnt.Text))
            {
                mntSaisi = mntReste;
                mntReste = mntReste - mntSaisi; tbxResteEncore.Text = mntReste.ToString();
                mntSimplyOrder = mntSimplyOrder + mntSaisi; tbxMntSimply.Text = mntSimplyOrder.ToString();
            }
            else if ((mntReste >= 0) && (mntReste != 0))
            {
                mntSaisi = float.Parse(tbxSaisieMnt.Text);
                mntReste = mntReste - mntSaisi;
                tbxSaisieMnt.Clear();
                tbxMntSimply.Text = mntSimplyOrder.ToString();
                tbxResteEncore.Text = mntReste.ToString();
            }
            tbxSaisieMnt.Clear();
        }

        private void btnCheque_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxSaisieMnt.Text))
            {
                mntSaisi = mntReste;
                mntReste = mntReste - mntSaisi; tbxResteEncore.Text = mntReste.ToString();
                mntCheque = mntCheque + mntSaisi; tbxMntCheque.Text = mntCheque.ToString();
            }
            else if ((mntReste >= 0) && (mntReste != 0))
            {
                mntSaisi = float.Parse(tbxSaisieMnt.Text);
                mntReste = mntReste - mntSaisi;
                mntCheque = mntCheque + mntSaisi;
                tbxSaisieMnt.Clear();
                tbxMntCheque.Text = mntCheque.ToString();
                tbxResteEncore.Text = mntReste.ToString();
            }
            tbxSaisieMnt.Clear();
        }

        private void btnCtr_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxSaisieMnt.Text))
            {
                mntSaisi = mntReste;
                mntReste = mntReste - mntSaisi; tbxResteEncore.Text = mntReste.ToString();
                mntCtr = mntCtr + mntSaisi; tbxMntCtr.Text = mntCtr.ToString();
            }
            else if ((mntReste >= 0) && (mntReste != 0))
            {
                mntSaisi = float.Parse(tbxSaisieMnt.Text);
                mntReste = mntReste - mntSaisi;
                mntCtr = mntCtr + mntSaisi;
                tbxSaisieMnt.Clear();
                tbxMntCtr.Text = mntCtr.ToString();
                tbxResteEncore.Text = mntReste.ToString();
            }
            tbxSaisieMnt.Clear();
        }
        #endregion

        //Traitement pour attribuer un numéro de commande
        //L'attribution se fera sans que l'utilisateur intervient
        private void creaNumReglement()
        {
            string requete = "SELECT * FROM reglement";
            try
            {
                fonctions.OuvrirConnection();
                //Verification qu'il existe une ligne dans la table reglement
                if (fonctions.Existe(requete))
                {
                    fonctions.FermerConnection();
                    //Si il existe des enregistrements on prend le numéro de reglemnent max et on ajoute 1
                    requete = "SELECT MAX(NumReglement)+1 FROM reglement";
                    fonctions.OuvrirConnection();
                    numRegl = fonctions.Compte(requete);
                    fonctions.FermerConnection();
                }
                else
                { numRegl = 1; fonctions.FermerConnection(); }
            }
            catch (Exception ex)
            { lblMessage.Text = "Erreur_Num_Commande: " + ex.Message; fonctions.FermerConnection(); }
        }

        //Traitement qui permet de réinitialiser la procédure (en cas d'erreur)
        private void btnCorrection_Click(object sender, EventArgs e)
        {
            tbxMntEspece.Clear();
            tbxMntCb.Clear();
            tbxMntCheque.Clear();
            tbxMntCtr.Clear();
            tbxMntSimply.Clear();
            mntReste = v_total;
            tbxResteEncore.Clear();
            mntEspece = 0;
            mntCb = 0;
            mntCheque = 0;
            mntCtr = 0;
            mntSimplyOrder = 0;
        }

        //Traitement pour valider les différents mode de paiement de la commande
        private void btnValider_Click(object sender, EventArgs e)
        {
            List<float> modeReglement = new List<float>();
            List<int> typeReglement = new List<int>();
            //On vérifie qu'il éxiste un montant avant de l'ajouter avec son type correspondant
            if (mntEspece > 0)
            { modeReglement.Add(mntEspece); typeReglement.Add(1); }
            if (mntCb > 0)
            { modeReglement.Add(mntCb); typeReglement.Add(2); }            
            if (mntCheque > 0)
            { modeReglement.Add(mntCheque); typeReglement.Add(3); }
            if (mntCtr > 0)
            { modeReglement.Add(mntCtr); typeReglement.Add(4); }
            if (mntSimplyOrder > 0)
            { modeReglement.Add(mntSimplyOrder); typeReglement.Add(5); }
                                   
            if (mntReste <= 0)
            {
                for (int i = 0; i < modeReglement.Count; i++) 
                {
                    try
                    {
                        //Insertion ligne(s) dans la table reglement
                        string tableReg = "reglement";
                        string valeurReg = numRegl.ToString();
                        valeurReg += ", '" + modeReglement[i].ToString().Replace(",",".") + "'";
                        valeurReg += ", " + typeReglement[i]; 
                        fonctions.Inserer(tableReg, valeurReg);
                        //Insertion ligne(s) dans la table ligne_reglement
                        string tableLigne = "ligne_reglement";
                        string valeurLigne = numRegl.ToString();
                        valeurLigne += ", " + v_numCde;
                        fonctions.Inserer(tableLigne, valeurLigne);

                        numRegl = numRegl + 1;
                    }
                    catch (Exception ex)
                    { lblMessage.Text = "Validation_Ajout_ModeReglement " + ex.Message; }
                }
                //On met à jour dans les tables commande et facture les états "non payée" par "payée"
                try
                {
                    string tableCde = "commande";
                    string setCde = " EtatCommande = '" + etatReglement + "'";
                    string whereCde = " NumCommande = " + v_numCde;
                    fonctions.MiseAjour(tableCde, setCde, whereCde);

                    string tableFac = "facture";
                    string setFac = " EtatFacure = '" + etatReglement + "'";
                    string whereFac = " NumFacture = " + v_numCde;
                    fonctions.MiseAjour(tableFac, setFac, whereFac);
                }
                catch (Exception ex)
                { lblMessage.Text = "Validation_Maj_Etat " + ex.Message; }
            }
            else
            { MessageBox.Show("La facture n'est pas soldée!"); return; }
            this.Close();
        }        
    }
}
