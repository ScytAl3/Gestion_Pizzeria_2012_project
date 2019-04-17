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
    public partial class PlanClient : Form
    {
        //Déclaration variable
        string planclient;

        public string planClient
        { set { planclient = value; } get { return planClient; } }

        public PlanClient()
        {
            InitializeComponent();
        }

        private void PlanClient_Load(object sender, EventArgs e)
        {
            webBrowserPlan.Navigate(planclient);
        }
    }
}
