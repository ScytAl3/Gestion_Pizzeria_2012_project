namespace pizzeria
{
    partial class GestionCommande
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnRetour = new System.Windows.Forms.Button();
            this.lblRechDate = new System.Windows.Forms.Label();
            this.dtgCommande = new System.Windows.Forms.DataGridView();
            this.btnPasserCmd = new System.Windows.Forms.Button();
            this.btnEditerCmd = new System.Windows.Forms.Button();
            this.btnSuppCmd = new System.Windows.Forms.Button();
            this.btnReglerCmd = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lbxBonProd = new System.Windows.Forms.ListBox();
            this.gbxBonProd = new System.Windows.Forms.GroupBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCommande)).BeginInit();
            this.gbxBonProd.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRetour
            // 
            this.btnRetour.Location = new System.Drawing.Point(1102, 602);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(75, 23);
            this.btnRetour.TabIndex = 0;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = true;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // lblRechDate
            // 
            this.lblRechDate.AutoSize = true;
            this.lblRechDate.Location = new System.Drawing.Point(12, 61);
            this.lblRechDate.Name = "lblRechDate";
            this.lblRechDate.Size = new System.Drawing.Size(108, 13);
            this.lblRechDate.TabIndex = 3;
            this.lblRechDate.Text = "Rechercher par date:";
            // 
            // dtgCommande
            // 
            this.dtgCommande.AllowUserToAddRows = false;
            this.dtgCommande.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dtgCommande.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgCommande.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCommande.Location = new System.Drawing.Point(15, 94);
            this.dtgCommande.Name = "dtgCommande";
            this.dtgCommande.RowHeadersWidth = 50;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtgCommande.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dtgCommande.Size = new System.Drawing.Size(800, 285);
            this.dtgCommande.TabIndex = 5;
            // 
            // btnPasserCmd
            // 
            this.btnPasserCmd.Location = new System.Drawing.Point(15, 408);
            this.btnPasserCmd.Name = "btnPasserCmd";
            this.btnPasserCmd.Size = new System.Drawing.Size(141, 23);
            this.btnPasserCmd.TabIndex = 6;
            this.btnPasserCmd.Text = "Passer une commande";
            this.btnPasserCmd.UseVisualStyleBackColor = true;
            this.btnPasserCmd.Click += new System.EventHandler(this.btnPasserCmd_Click);
            // 
            // btnEditerCmd
            // 
            this.btnEditerCmd.Location = new System.Drawing.Point(174, 408);
            this.btnEditerCmd.Name = "btnEditerCmd";
            this.btnEditerCmd.Size = new System.Drawing.Size(131, 23);
            this.btnEditerCmd.TabIndex = 7;
            this.btnEditerCmd.Text = "Editer une commande";
            this.btnEditerCmd.UseVisualStyleBackColor = true;
            this.btnEditerCmd.Click += new System.EventHandler(this.btnEditerCmd_Click);
            // 
            // btnSuppCmd
            // 
            this.btnSuppCmd.Location = new System.Drawing.Point(477, 408);
            this.btnSuppCmd.Name = "btnSuppCmd";
            this.btnSuppCmd.Size = new System.Drawing.Size(154, 23);
            this.btnSuppCmd.TabIndex = 8;
            this.btnSuppCmd.Text = "Supprimer une commande";
            this.btnSuppCmd.UseVisualStyleBackColor = true;
            // 
            // btnReglerCmd
            // 
            this.btnReglerCmd.Location = new System.Drawing.Point(661, 408);
            this.btnReglerCmd.Name = "btnReglerCmd";
            this.btnReglerCmd.Size = new System.Drawing.Size(154, 23);
            this.btnReglerCmd.TabIndex = 9;
            this.btnReglerCmd.Text = "Regler une commande";
            this.btnReglerCmd.UseVisualStyleBackColor = true;
            this.btnReglerCmd.Click += new System.EventHandler(this.btnReglerCmd_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(12, 639);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(53, 13);
            this.lblMessage.TabIndex = 10;
            this.lblMessage.Text = "Message!";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(126, 55);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 11;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // lbxBonProd
            // 
            this.lbxBonProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxBonProd.FormattingEnabled = true;
            this.lbxBonProd.Location = new System.Drawing.Point(16, 19);
            this.lbxBonProd.Name = "lbxBonProd";
            this.lbxBonProd.Size = new System.Drawing.Size(288, 407);
            this.lbxBonProd.TabIndex = 12;
            // 
            // gbxBonProd
            // 
            this.gbxBonProd.Controls.Add(this.lbxBonProd);
            this.gbxBonProd.Location = new System.Drawing.Point(844, 94);
            this.gbxBonProd.Name = "gbxBonProd";
            this.gbxBonProd.Size = new System.Drawing.Size(321, 436);
            this.gbxBonProd.TabIndex = 13;
            this.gbxBonProd.TabStop = false;
            this.gbxBonProd.Text = "Détail bon de production";
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(341, 408);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(98, 23);
            this.btnAjouter.TabIndex = 14;
            this.btnAjouter.Text = "Ajouter article";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // GestionCommande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 661);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.gbxBonProd);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnReglerCmd);
            this.Controls.Add(this.btnSuppCmd);
            this.Controls.Add(this.btnEditerCmd);
            this.Controls.Add(this.btnPasserCmd);
            this.Controls.Add(this.dtgCommande);
            this.Controls.Add(this.lblRechDate);
            this.Controls.Add(this.btnRetour);
            this.Name = "GestionCommande";
            this.Text = "GestionCommande";
            this.Load += new System.EventHandler(this.GestionCommande_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCommande)).EndInit();
            this.gbxBonProd.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRetour;
        private System.Windows.Forms.Label lblRechDate;
        private System.Windows.Forms.DataGridView dtgCommande;
        private System.Windows.Forms.Button btnPasserCmd;
        private System.Windows.Forms.Button btnEditerCmd;
        private System.Windows.Forms.Button btnSuppCmd;
        private System.Windows.Forms.Button btnReglerCmd;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ListBox lbxBonProd;
        private System.Windows.Forms.GroupBox gbxBonProd;
        private System.Windows.Forms.Button btnAjouter;
    }
}