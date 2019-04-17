namespace pizzeria
{
    partial class GestionFacture
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnRetour = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dtgFacture = new System.Windows.Forms.DataGridView();
            this.lblRechDate = new System.Windows.Forms.Label();
            this.btnEditerFacture = new System.Windows.Forms.Button();
            this.gbxDetailFacture = new System.Windows.Forms.GroupBox();
            this.lbxDetailFacture = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgFacture)).BeginInit();
            this.gbxDetailFacture.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(12, 507);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(53, 13);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Message!";
            // 
            // btnRetour
            // 
            this.btnRetour.Location = new System.Drawing.Point(1118, 497);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(75, 23);
            this.btnRetour.TabIndex = 1;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = true;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(126, 55);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 14;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // dtgFacture
            // 
            this.dtgFacture.AllowUserToAddRows = false;
            this.dtgFacture.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dtgFacture.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgFacture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgFacture.Location = new System.Drawing.Point(15, 94);
            this.dtgFacture.Name = "dtgFacture";
            this.dtgFacture.RowHeadersWidth = 50;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtgFacture.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgFacture.Size = new System.Drawing.Size(680, 285);
            this.dtgFacture.TabIndex = 13;
            // 
            // lblRechDate
            // 
            this.lblRechDate.AutoSize = true;
            this.lblRechDate.Location = new System.Drawing.Point(12, 61);
            this.lblRechDate.Name = "lblRechDate";
            this.lblRechDate.Size = new System.Drawing.Size(108, 13);
            this.lblRechDate.TabIndex = 12;
            this.lblRechDate.Text = "Rechercher par date:";
            // 
            // btnEditerFacture
            // 
            this.btnEditerFacture.Location = new System.Drawing.Point(15, 402);
            this.btnEditerFacture.Name = "btnEditerFacture";
            this.btnEditerFacture.Size = new System.Drawing.Size(105, 23);
            this.btnEditerFacture.TabIndex = 15;
            this.btnEditerFacture.Text = "Editer facture";
            this.btnEditerFacture.UseVisualStyleBackColor = true;
            this.btnEditerFacture.Click += new System.EventHandler(this.btnEditerFacture_Click);
            // 
            // gbxDetailFacture
            // 
            this.gbxDetailFacture.Controls.Add(this.lbxDetailFacture);
            this.gbxDetailFacture.Location = new System.Drawing.Point(853, 94);
            this.gbxDetailFacture.Name = "gbxDetailFacture";
            this.gbxDetailFacture.Size = new System.Drawing.Size(289, 342);
            this.gbxDetailFacture.TabIndex = 16;
            this.gbxDetailFacture.TabStop = false;
            this.gbxDetailFacture.Text = "Détail facture";
            // 
            // lbxDetailFacture
            // 
            this.lbxDetailFacture.FormattingEnabled = true;
            this.lbxDetailFacture.Location = new System.Drawing.Point(16, 28);
            this.lbxDetailFacture.Name = "lbxDetailFacture";
            this.lbxDetailFacture.Size = new System.Drawing.Size(256, 303);
            this.lbxDetailFacture.TabIndex = 0;
            // 
            // GestionFacture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 551);
            this.Controls.Add(this.gbxDetailFacture);
            this.Controls.Add(this.btnEditerFacture);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.dtgFacture);
            this.Controls.Add(this.lblRechDate);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.lblMessage);
            this.Name = "GestionFacture";
            this.Text = "GestionFacture";
            this.Load += new System.EventHandler(this.GestionFacture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgFacture)).EndInit();
            this.gbxDetailFacture.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnRetour;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DataGridView dtgFacture;
        private System.Windows.Forms.Label lblRechDate;
        private System.Windows.Forms.Button btnEditerFacture;
        private System.Windows.Forms.GroupBox gbxDetailFacture;
        private System.Windows.Forms.ListBox lbxDetailFacture;
    }
}