namespace pizzeria
{
    partial class GestionClient
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRetour = new System.Windows.Forms.Button();
            this.dtgClient = new System.Windows.Forms.DataGridView();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblRechNom = new System.Windows.Forms.Label();
            this.tbxRecherNom = new System.Windows.Forms.TextBox();
            this.btnAjouClient = new System.Windows.Forms.Button();
            this.btnModifClient = new System.Windows.Forms.Button();
            this.btnSuppClient = new System.Windows.Forms.Button();
            this.btnAffichPlan = new System.Windows.Forms.Button();
            this.btnCommande = new System.Windows.Forms.Button();
            this.lblRechTel = new System.Windows.Forms.Label();
            this.tbxRecherTel = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgClient)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRetour
            // 
            this.btnRetour.Location = new System.Drawing.Point(969, 475);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(75, 23);
            this.btnRetour.TabIndex = 0;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = true;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // dtgClient
            // 
            this.dtgClient.AllowUserToAddRows = false;
            this.dtgClient.AllowUserToDeleteRows = false;
            this.dtgClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgClient.Location = new System.Drawing.Point(12, 74);
            this.dtgClient.Name = "dtgClient";
            this.dtgClient.Size = new System.Drawing.Size(1000, 300);
            this.dtgClient.TabIndex = 1;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(12, 480);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(53, 13);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = "Message!";
            // 
            // lblRechNom
            // 
            this.lblRechNom.AutoSize = true;
            this.lblRechNom.Location = new System.Drawing.Point(12, 49);
            this.lblRechNom.Name = "lblRechNom";
            this.lblRechNom.Size = new System.Drawing.Size(104, 13);
            this.lblRechNom.TabIndex = 7;
            this.lblRechNom.Text = "Recherche par nom:";
            // 
            // tbxRecherNom
            // 
            this.tbxRecherNom.Location = new System.Drawing.Point(122, 46);
            this.tbxRecherNom.Name = "tbxRecherNom";
            this.tbxRecherNom.Size = new System.Drawing.Size(158, 20);
            this.tbxRecherNom.TabIndex = 8;
            this.tbxRecherNom.TextChanged += new System.EventHandler(this.tbxRecherNom_TextChanged);
            // 
            // btnAjouClient
            // 
            this.btnAjouClient.Location = new System.Drawing.Point(12, 419);
            this.btnAjouClient.Name = "btnAjouClient";
            this.btnAjouClient.Size = new System.Drawing.Size(75, 23);
            this.btnAjouClient.TabIndex = 9;
            this.btnAjouClient.Text = "Ajouter";
            this.btnAjouClient.UseVisualStyleBackColor = true;
            this.btnAjouClient.Click += new System.EventHandler(this.btnAjouClient_Click);
            // 
            // btnModifClient
            // 
            this.btnModifClient.Location = new System.Drawing.Point(106, 419);
            this.btnModifClient.Name = "btnModifClient";
            this.btnModifClient.Size = new System.Drawing.Size(75, 23);
            this.btnModifClient.TabIndex = 10;
            this.btnModifClient.Text = "Modifier";
            this.btnModifClient.UseVisualStyleBackColor = true;
            this.btnModifClient.Click += new System.EventHandler(this.btnModifClient_Click);
            // 
            // btnSuppClient
            // 
            this.btnSuppClient.Location = new System.Drawing.Point(196, 419);
            this.btnSuppClient.Name = "btnSuppClient";
            this.btnSuppClient.Size = new System.Drawing.Size(75, 23);
            this.btnSuppClient.TabIndex = 11;
            this.btnSuppClient.Text = "Supprimer";
            this.btnSuppClient.UseVisualStyleBackColor = true;
            this.btnSuppClient.Click += new System.EventHandler(this.btnSuppClient_Click);
            // 
            // btnAffichPlan
            // 
            this.btnAffichPlan.Location = new System.Drawing.Point(334, 419);
            this.btnAffichPlan.Name = "btnAffichPlan";
            this.btnAffichPlan.Size = new System.Drawing.Size(75, 23);
            this.btnAffichPlan.TabIndex = 12;
            this.btnAffichPlan.Text = "Afficher plan";
            this.btnAffichPlan.UseVisualStyleBackColor = true;
            this.btnAffichPlan.Click += new System.EventHandler(this.btnAffichPlan_Click);
            // 
            // btnCommande
            // 
            this.btnCommande.Location = new System.Drawing.Point(454, 419);
            this.btnCommande.Name = "btnCommande";
            this.btnCommande.Size = new System.Drawing.Size(142, 23);
            this.btnCommande.TabIndex = 13;
            this.btnCommande.Text = "Passer une commande";
            this.btnCommande.UseVisualStyleBackColor = true;
            this.btnCommande.Click += new System.EventHandler(this.btnCommande_Click);
            // 
            // lblRechTel
            // 
            this.lblRechTel.AutoSize = true;
            this.lblRechTel.Location = new System.Drawing.Point(360, 49);
            this.lblRechTel.Name = "lblRechTel";
            this.lblRechTel.Size = new System.Drawing.Size(184, 13);
            this.lblRechTel.TabIndex = 14;
            this.lblRechTel.Text = "Recherche par numéro de téléphone:";
            // 
            // tbxRecherTel
            // 
            this.tbxRecherTel.Location = new System.Drawing.Point(550, 46);
            this.tbxRecherTel.Name = "tbxRecherTel";
            this.tbxRecherTel.Size = new System.Drawing.Size(153, 20);
            this.tbxRecherTel.TabIndex = 15;
            this.tbxRecherTel.TextChanged += new System.EventHandler(this.tbxRecherTel_TextChanged);
            // 
            // GestionClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 510);
            this.Controls.Add(this.tbxRecherTel);
            this.Controls.Add(this.lblRechTel);
            this.Controls.Add(this.btnCommande);
            this.Controls.Add(this.btnAffichPlan);
            this.Controls.Add(this.btnSuppClient);
            this.Controls.Add(this.btnModifClient);
            this.Controls.Add(this.btnAjouClient);
            this.Controls.Add(this.tbxRecherNom);
            this.Controls.Add(this.lblRechNom);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.dtgClient);
            this.Controls.Add(this.btnRetour);
            this.Name = "GestionClient";
            this.Text = "Gestion de la liste des clients";
            this.Load += new System.EventHandler(this.GestionClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRetour;
        private System.Windows.Forms.DataGridView dtgClient;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblRechNom;
        private System.Windows.Forms.TextBox tbxRecherNom;
        private System.Windows.Forms.Button btnAjouClient;
        private System.Windows.Forms.Button btnModifClient;
        private System.Windows.Forms.Button btnSuppClient;
        private System.Windows.Forms.Button btnAffichPlan;
        private System.Windows.Forms.Button btnCommande;
        private System.Windows.Forms.Label lblRechTel;
        private System.Windows.Forms.TextBox tbxRecherTel;
    }
}

