namespace pizzeria
{
    partial class EcranAccueil
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGestionFichierCient = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.btnGestionCommande = new System.Windows.Forms.Button();
            this.btnGestionProduit = new System.Windows.Forms.Button();
            this.btnGestionFacture = new System.Windows.Forms.Button();
            this.btnGestionReglement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGestionFichierCient
            // 
            this.btnGestionFichierCient.Location = new System.Drawing.Point(30, 43);
            this.btnGestionFichierCient.Name = "btnGestionFichierCient";
            this.btnGestionFichierCient.Size = new System.Drawing.Size(350, 50);
            this.btnGestionFichierCient.TabIndex = 0;
            this.btnGestionFichierCient.Text = "Gestion du fichier clientèle";
            this.btnGestionFichierCient.UseVisualStyleBackColor = true;
            this.btnGestionFichierCient.Click += new System.EventHandler(this.btnGestionFichierCient_Click);
            // 
            // btnQuitter
            // 
            this.btnQuitter.Location = new System.Drawing.Point(530, 460);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(75, 23);
            this.btnQuitter.TabIndex = 1;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.UseVisualStyleBackColor = true;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // btnGestionCommande
            // 
            this.btnGestionCommande.Location = new System.Drawing.Point(30, 125);
            this.btnGestionCommande.Name = "btnGestionCommande";
            this.btnGestionCommande.Size = new System.Drawing.Size(350, 50);
            this.btnGestionCommande.TabIndex = 2;
            this.btnGestionCommande.Text = "Gestion du fichier commande";
            this.btnGestionCommande.UseVisualStyleBackColor = true;
            this.btnGestionCommande.Click += new System.EventHandler(this.btnGestionCommande_Click);
            // 
            // btnGestionProduit
            // 
            this.btnGestionProduit.Location = new System.Drawing.Point(30, 396);
            this.btnGestionProduit.Name = "btnGestionProduit";
            this.btnGestionProduit.Size = new System.Drawing.Size(350, 50);
            this.btnGestionProduit.TabIndex = 3;
            this.btnGestionProduit.Text = "Gestion du fichier produit et fomule";
            this.btnGestionProduit.UseVisualStyleBackColor = true;
            this.btnGestionProduit.Click += new System.EventHandler(this.btnGestionProduit_Click);
            // 
            // btnGestionFacture
            // 
            this.btnGestionFacture.Location = new System.Drawing.Point(30, 217);
            this.btnGestionFacture.Name = "btnGestionFacture";
            this.btnGestionFacture.Size = new System.Drawing.Size(350, 50);
            this.btnGestionFacture.TabIndex = 4;
            this.btnGestionFacture.Text = "Gestion du fichier facture";
            this.btnGestionFacture.UseVisualStyleBackColor = true;
            this.btnGestionFacture.Click += new System.EventHandler(this.btnGestionFacture_Click);
            // 
            // btnGestionReglement
            // 
            this.btnGestionReglement.Location = new System.Drawing.Point(30, 305);
            this.btnGestionReglement.Name = "btnGestionReglement";
            this.btnGestionReglement.Size = new System.Drawing.Size(350, 50);
            this.btnGestionReglement.TabIndex = 5;
            this.btnGestionReglement.Text = "Gestion des réglements";
            this.btnGestionReglement.UseVisualStyleBackColor = true;
            this.btnGestionReglement.Click += new System.EventHandler(this.btnGestionReglement_Click);
            // 
            // EcranAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 495);
            this.Controls.Add(this.btnGestionReglement);
            this.Controls.Add(this.btnGestionFacture);
            this.Controls.Add(this.btnGestionProduit);
            this.Controls.Add(this.btnGestionCommande);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.btnGestionFichierCient);
            this.Name = "EcranAccueil";
            this.Text = "Ecran d\'accueil";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGestionFichierCient;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Button btnGestionCommande;
        private System.Windows.Forms.Button btnGestionProduit;
        private System.Windows.Forms.Button btnGestionFacture;
        private System.Windows.Forms.Button btnGestionReglement;
    }
}