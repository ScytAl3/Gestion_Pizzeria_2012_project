namespace pizzeria
{
    partial class ModifierClient
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
            this.components = new System.ComponentModel.Container();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnRetour = new System.Windows.Forms.Button();
            this.btnValider = new System.Windows.Forms.Button();
            this.gbxModifierClient = new System.Windows.Forms.GroupBox();
            this.tbxCommAdresse = new System.Windows.Forms.TextBox();
            this.lblCommentaire = new System.Windows.Forms.Label();
            this.tbxPlanMappy = new System.Windows.Forms.TextBox();
            this.lblPlanClient = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tbxMail = new System.Windows.Forms.TextBox();
            this.tbxTel = new System.Windows.Forms.TextBox();
            this.tbxVille = new System.Windows.Forms.TextBox();
            this.tbxCodepostal = new System.Windows.Forms.TextBox();
            this.tbxAdresse = new System.Windows.Forms.TextBox();
            this.tbxPrenClient = new System.Windows.Forms.TextBox();
            this.tbxNomClient = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblNomClient = new System.Windows.Forms.Label();
            this.lblPrenClient = new System.Windows.Forms.Label();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.lblAdrClient = new System.Windows.Forms.Label();
            this.lblCpostal = new System.Windows.Forms.Label();
            this.lblVille = new System.Windows.Forms.Label();
            this.gbxPlanClient = new System.Windows.Forms.GroupBox();
            this.webBrowserPlan = new System.Windows.Forms.WebBrowser();
            this.btnMappyClient = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbxModifierClient.SuspendLayout();
            this.gbxPlanClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(12, 539);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(53, 13);
            this.lblMessage.TabIndex = 33;
            this.lblMessage.Text = "Message!";
            // 
            // btnRetour
            // 
            this.btnRetour.Location = new System.Drawing.Point(457, 513);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(75, 23);
            this.btnRetour.TabIndex = 32;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = true;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(214, 513);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(75, 23);
            this.btnValider.TabIndex = 31;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // gbxModifierClient
            // 
            this.gbxModifierClient.Controls.Add(this.tbxCommAdresse);
            this.gbxModifierClient.Controls.Add(this.lblCommentaire);
            this.gbxModifierClient.Controls.Add(this.tbxPlanMappy);
            this.gbxModifierClient.Controls.Add(this.lblPlanClient);
            this.gbxModifierClient.Controls.Add(this.lblInfo);
            this.gbxModifierClient.Controls.Add(this.tbxMail);
            this.gbxModifierClient.Controls.Add(this.tbxTel);
            this.gbxModifierClient.Controls.Add(this.tbxVille);
            this.gbxModifierClient.Controls.Add(this.tbxCodepostal);
            this.gbxModifierClient.Controls.Add(this.tbxAdresse);
            this.gbxModifierClient.Controls.Add(this.tbxPrenClient);
            this.gbxModifierClient.Controls.Add(this.tbxNomClient);
            this.gbxModifierClient.Controls.Add(this.lblMail);
            this.gbxModifierClient.Controls.Add(this.lblNomClient);
            this.gbxModifierClient.Controls.Add(this.lblPrenClient);
            this.gbxModifierClient.Controls.Add(this.lblTelephone);
            this.gbxModifierClient.Controls.Add(this.lblAdrClient);
            this.gbxModifierClient.Controls.Add(this.lblCpostal);
            this.gbxModifierClient.Controls.Add(this.lblVille);
            this.gbxModifierClient.Location = new System.Drawing.Point(15, 25);
            this.gbxModifierClient.Name = "gbxModifierClient";
            this.gbxModifierClient.Size = new System.Drawing.Size(517, 482);
            this.gbxModifierClient.TabIndex = 34;
            this.gbxModifierClient.TabStop = false;
            this.gbxModifierClient.Text = "Modifier  client";
            // 
            // tbxCommAdresse
            // 
            this.tbxCommAdresse.Location = new System.Drawing.Point(127, 400);
            this.tbxCommAdresse.MaxLength = 50;
            this.tbxCommAdresse.Name = "tbxCommAdresse";
            this.tbxCommAdresse.Size = new System.Drawing.Size(363, 20);
            this.tbxCommAdresse.TabIndex = 20;
            // 
            // lblCommentaire
            // 
            this.lblCommentaire.AutoSize = true;
            this.lblCommentaire.Location = new System.Drawing.Point(32, 403);
            this.lblCommentaire.Name = "lblCommentaire";
            this.lblCommentaire.Size = new System.Drawing.Size(71, 13);
            this.lblCommentaire.TabIndex = 25;
            this.lblCommentaire.Text = "Commentaire:";
            // 
            // tbxPlanMappy
            // 
            this.tbxPlanMappy.Location = new System.Drawing.Point(127, 443);
            this.tbxPlanMappy.Name = "tbxPlanMappy";
            this.tbxPlanMappy.ReadOnly = true;
            this.tbxPlanMappy.Size = new System.Drawing.Size(363, 20);
            this.tbxPlanMappy.TabIndex = 24;
            // 
            // lblPlanClient
            // 
            this.lblPlanClient.AutoSize = true;
            this.lblPlanClient.Location = new System.Drawing.Point(18, 446);
            this.lblPlanClient.Name = "lblPlanClient";
            this.lblPlanClient.Size = new System.Drawing.Size(85, 13);
            this.lblPlanClient.TabIndex = 23;
            this.lblPlanClient.Text = "Lien localisation:";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(124, 32);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(205, 13);
            this.lblInfo.TabIndex = 20;
            this.lblInfo.Text = "Tous les champs en vert sont obligatoires!";
            // 
            // tbxMail
            // 
            this.tbxMail.Location = new System.Drawing.Point(127, 356);
            this.tbxMail.MaxLength = 50;
            this.tbxMail.Name = "tbxMail";
            this.tbxMail.Size = new System.Drawing.Size(363, 20);
            this.tbxMail.TabIndex = 19;
            this.tbxMail.Validating += new System.ComponentModel.CancelEventHandler(this.tbxMail_Validating);
            // 
            // tbxTel
            // 
            this.tbxTel.Location = new System.Drawing.Point(127, 306);
            this.tbxTel.MaxLength = 10;
            this.tbxTel.Name = "tbxTel";
            this.tbxTel.Size = new System.Drawing.Size(100, 20);
            this.tbxTel.TabIndex = 18;
            this.tbxTel.Validating += new System.ComponentModel.CancelEventHandler(this.tbxTel_Validating);
            // 
            // tbxVille
            // 
            this.tbxVille.Location = new System.Drawing.Point(127, 260);
            this.tbxVille.MaxLength = 25;
            this.tbxVille.Name = "tbxVille";
            this.tbxVille.Size = new System.Drawing.Size(147, 20);
            this.tbxVille.TabIndex = 17;
            this.tbxVille.Validating += new System.ComponentModel.CancelEventHandler(this.tbxVille_Validating);
            // 
            // tbxCodepostal
            // 
            this.tbxCodepostal.Location = new System.Drawing.Point(127, 214);
            this.tbxCodepostal.MaxLength = 5;
            this.tbxCodepostal.Name = "tbxCodepostal";
            this.tbxCodepostal.Size = new System.Drawing.Size(64, 20);
            this.tbxCodepostal.TabIndex = 16;
            this.tbxCodepostal.Validating += new System.ComponentModel.CancelEventHandler(this.tbxCodepostal_Validating);
            // 
            // tbxAdresse
            // 
            this.tbxAdresse.Location = new System.Drawing.Point(127, 168);
            this.tbxAdresse.MaxLength = 50;
            this.tbxAdresse.Name = "tbxAdresse";
            this.tbxAdresse.Size = new System.Drawing.Size(363, 20);
            this.tbxAdresse.TabIndex = 15;
            this.tbxAdresse.Validating += new System.ComponentModel.CancelEventHandler(this.tbxAdresse_Validating);
            // 
            // tbxPrenClient
            // 
            this.tbxPrenClient.Location = new System.Drawing.Point(127, 121);
            this.tbxPrenClient.MaxLength = 20;
            this.tbxPrenClient.Name = "tbxPrenClient";
            this.tbxPrenClient.Size = new System.Drawing.Size(160, 20);
            this.tbxPrenClient.TabIndex = 14;
            this.tbxPrenClient.Validating += new System.ComponentModel.CancelEventHandler(this.tbxPrenClient_Validating);
            // 
            // tbxNomClient
            // 
            this.tbxNomClient.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxNomClient.Location = new System.Drawing.Point(127, 75);
            this.tbxNomClient.MaxLength = 20;
            this.tbxNomClient.Name = "tbxNomClient";
            this.tbxNomClient.Size = new System.Drawing.Size(160, 20);
            this.tbxNomClient.TabIndex = 13;
            this.tbxNomClient.Validating += new System.ComponentModel.CancelEventHandler(this.tbxNomClient_Validating);
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(30, 359);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(75, 13);
            this.lblMail.TabIndex = 12;
            this.lblMail.Text = "Adesse e-mail:";
            // 
            // lblNomClient
            // 
            this.lblNomClient.AutoSize = true;
            this.lblNomClient.Location = new System.Drawing.Point(28, 78);
            this.lblNomClient.Name = "lblNomClient";
            this.lblNomClient.Size = new System.Drawing.Size(75, 13);
            this.lblNomClient.TabIndex = 0;
            this.lblNomClient.Text = "Nom du client:";
            // 
            // lblPrenClient
            // 
            this.lblPrenClient.AutoSize = true;
            this.lblPrenClient.Location = new System.Drawing.Point(14, 124);
            this.lblPrenClient.Name = "lblPrenClient";
            this.lblPrenClient.Size = new System.Drawing.Size(89, 13);
            this.lblPrenClient.TabIndex = 2;
            this.lblPrenClient.Text = "Prénom du client:";
            // 
            // lblTelephone
            // 
            this.lblTelephone.AutoSize = true;
            this.lblTelephone.Location = new System.Drawing.Point(16, 309);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(87, 13);
            this.lblTelephone.TabIndex = 10;
            this.lblTelephone.Text = "N° de téléphone:";
            // 
            // lblAdrClient
            // 
            this.lblAdrClient.AutoSize = true;
            this.lblAdrClient.Location = new System.Drawing.Point(12, 171);
            this.lblAdrClient.Name = "lblAdrClient";
            this.lblAdrClient.Size = new System.Drawing.Size(91, 13);
            this.lblAdrClient.TabIndex = 4;
            this.lblAdrClient.Text = "Adresse du client:";
            // 
            // lblCpostal
            // 
            this.lblCpostal.AutoSize = true;
            this.lblCpostal.Location = new System.Drawing.Point(37, 217);
            this.lblCpostal.Name = "lblCpostal";
            this.lblCpostal.Size = new System.Drawing.Size(66, 13);
            this.lblCpostal.TabIndex = 6;
            this.lblCpostal.Text = "Code postal:";
            // 
            // lblVille
            // 
            this.lblVille.AutoSize = true;
            this.lblVille.Location = new System.Drawing.Point(74, 263);
            this.lblVille.Name = "lblVille";
            this.lblVille.Size = new System.Drawing.Size(29, 13);
            this.lblVille.TabIndex = 8;
            this.lblVille.Text = "Ville:";
            // 
            // gbxPlanClient
            // 
            this.gbxPlanClient.Controls.Add(this.webBrowserPlan);
            this.gbxPlanClient.Location = new System.Drawing.Point(546, 25);
            this.gbxPlanClient.Name = "gbxPlanClient";
            this.gbxPlanClient.Size = new System.Drawing.Size(626, 482);
            this.gbxPlanClient.TabIndex = 35;
            this.gbxPlanClient.TabStop = false;
            this.gbxPlanClient.Text = "Localisation du client";
            // 
            // webBrowserPlan
            // 
            this.webBrowserPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserPlan.Location = new System.Drawing.Point(3, 16);
            this.webBrowserPlan.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserPlan.Name = "webBrowserPlan";
            this.webBrowserPlan.Size = new System.Drawing.Size(620, 463);
            this.webBrowserPlan.TabIndex = 0;
            // 
            // btnMappyClient
            // 
            this.btnMappyClient.Location = new System.Drawing.Point(15, 513);
            this.btnMappyClient.Name = "btnMappyClient";
            this.btnMappyClient.Size = new System.Drawing.Size(75, 23);
            this.btnMappyClient.TabIndex = 36;
            this.btnMappyClient.Text = "Mappy";
            this.btnMappyClient.UseVisualStyleBackColor = true;
            this.btnMappyClient.Click += new System.EventHandler(this.btnMappyClient_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ModifierClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.btnMappyClient);
            this.Controls.Add(this.gbxPlanClient);
            this.Controls.Add(this.gbxModifierClient);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.btnValider);
            this.Name = "ModifierClient";
            this.Text = "Modifier une fiche client";
            this.Load += new System.EventHandler(this.ModifierClient_Load);
            this.gbxModifierClient.ResumeLayout(false);
            this.gbxModifierClient.PerformLayout();
            this.gbxPlanClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnRetour;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.GroupBox gbxModifierClient;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TextBox tbxMail;
        private System.Windows.Forms.TextBox tbxTel;
        private System.Windows.Forms.TextBox tbxVille;
        private System.Windows.Forms.TextBox tbxCodepostal;
        private System.Windows.Forms.TextBox tbxAdresse;
        private System.Windows.Forms.TextBox tbxPrenClient;
        private System.Windows.Forms.TextBox tbxNomClient;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblNomClient;
        private System.Windows.Forms.Label lblPrenClient;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.Label lblAdrClient;
        private System.Windows.Forms.Label lblCpostal;
        private System.Windows.Forms.Label lblVille;
        private System.Windows.Forms.TextBox tbxPlanMappy;
        private System.Windows.Forms.Label lblPlanClient;
        private System.Windows.Forms.GroupBox gbxPlanClient;
        private System.Windows.Forms.WebBrowser webBrowserPlan;
        private System.Windows.Forms.Button btnMappyClient;
        private System.Windows.Forms.TextBox tbxCommAdresse;
        private System.Windows.Forms.Label lblCommentaire;
        private System.Windows.Forms.ErrorProvider errorProvider1;

    }
}