using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pizzeria
{
    public partial class EcranAccueil : Form
    {
        public EcranAccueil()
        {
            InitializeComponent();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGestionFichierCient_Click(object sender, EventArgs e)
        {
            GestionClient ecranGestionClient = new GestionClient();
            ecranGestionClient.ShowDialog();
        }

        private void btnGestionCommande_Click(object sender, EventArgs e)
        {
            GestionCommande ecranGestionCommande = new GestionCommande();
            ecranGestionCommande.ShowDialog();
        }

        private void btnGestionFacture_Click(object sender, EventArgs e)
        {
            GestionFacture ecranGestionFacture = new GestionFacture();
            ecranGestionFacture.ShowDialog();
        }

        private void btnGestionReglement_Click(object sender, EventArgs e)
        {
            GestionReglement ecranGestionReglement = new GestionReglement();
            ecranGestionReglement.ShowDialog();
        }    

        private void btnGestionProduit_Click(object sender, EventArgs e)
        {
            GestionProduit ecranGestionProduit = new GestionProduit();
            ecranGestionProduit.ShowDialog();
        }         
    }
}
