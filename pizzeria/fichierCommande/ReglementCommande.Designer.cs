namespace pizzeria
{
    partial class ReglementCommande
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnRetour = new System.Windows.Forms.Button();
            this.tbxTotalCommande = new System.Windows.Forms.TextBox();
            this.lblTotalCde = new System.Windows.Forms.Label();
            this.lblMntEspece = new System.Windows.Forms.Label();
            this.tbxMntEspece = new System.Windows.Forms.TextBox();
            this.lblMntCb = new System.Windows.Forms.Label();
            this.tbxMntCb = new System.Windows.Forms.TextBox();
            this.lblMntCheque = new System.Windows.Forms.Label();
            this.lblMntCtr = new System.Windows.Forms.Label();
            this.tbxMntCheque = new System.Windows.Forms.TextBox();
            this.tbxMntCtr = new System.Windows.Forms.TextBox();
            this.tbxSaisieMnt = new System.Windows.Forms.TextBox();
            this.btnZero = new System.Windows.Forms.Button();
            this.btnDeux = new System.Windows.Forms.Button();
            this.btnUn = new System.Windows.Forms.Button();
            this.btnTrois = new System.Windows.Forms.Button();
            this.btnQuattre = new System.Windows.Forms.Button();
            this.btnCinq = new System.Windows.Forms.Button();
            this.btnSix = new System.Windows.Forms.Button();
            this.btnSept = new System.Windows.Forms.Button();
            this.btnHuit = new System.Windows.Forms.Button();
            this.btnNeuf = new System.Windows.Forms.Button();
            this.btnVirgule = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnEspece = new System.Windows.Forms.Button();
            this.btnCarte = new System.Windows.Forms.Button();
            this.btnCheque = new System.Windows.Forms.Button();
            this.btnCtr = new System.Windows.Forms.Button();
            this.lblResteEncore = new System.Windows.Forms.Label();
            this.tbxResteEncore = new System.Windows.Forms.TextBox();
            this.btnValider = new System.Windows.Forms.Button();
            this.btnCorrection = new System.Windows.Forms.Button();
            this.lblNumFacture = new System.Windows.Forms.Label();
            this.tbxNumFacture = new System.Windows.Forms.TextBox();
            this.lblNomClient = new System.Windows.Forms.Label();
            this.tbxNomClient = new System.Windows.Forms.TextBox();
            this.btnSimplyOrder = new System.Windows.Forms.Button();
            this.lblTotalSimply = new System.Windows.Forms.Label();
            this.tbxMntSimply = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(12, 505);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(53, 13);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Message!";
            // 
            // btnRetour
            // 
            this.btnRetour.Location = new System.Drawing.Point(481, 470);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(75, 23);
            this.btnRetour.TabIndex = 1;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = true;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // tbxTotalCommande
            // 
            this.tbxTotalCommande.Location = new System.Drawing.Point(207, 54);
            this.tbxTotalCommande.Name = "tbxTotalCommande";
            this.tbxTotalCommande.ReadOnly = true;
            this.tbxTotalCommande.Size = new System.Drawing.Size(100, 20);
            this.tbxTotalCommande.TabIndex = 2;
            this.tbxTotalCommande.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalCde
            // 
            this.lblTotalCde.AutoSize = true;
            this.lblTotalCde.Location = new System.Drawing.Point(75, 57);
            this.lblTotalCde.Name = "lblTotalCde";
            this.lblTotalCde.Size = new System.Drawing.Size(126, 13);
            this.lblTotalCde.TabIndex = 3;
            this.lblTotalCde.Text = "TOTAL de la commande:";
            // 
            // lblMntEspece
            // 
            this.lblMntEspece.AutoSize = true;
            this.lblMntEspece.Location = new System.Drawing.Point(117, 83);
            this.lblMntEspece.Name = "lblMntEspece";
            this.lblMntEspece.Size = new System.Drawing.Size(77, 13);
            this.lblMntEspece.TabIndex = 4;
            this.lblMntEspece.Text = "Total espèces:";
            // 
            // tbxMntEspece
            // 
            this.tbxMntEspece.Location = new System.Drawing.Point(207, 80);
            this.tbxMntEspece.Name = "tbxMntEspece";
            this.tbxMntEspece.ReadOnly = true;
            this.tbxMntEspece.Size = new System.Drawing.Size(100, 20);
            this.tbxMntEspece.TabIndex = 5;
            this.tbxMntEspece.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMntCb
            // 
            this.lblMntCb.AutoSize = true;
            this.lblMntCb.Location = new System.Drawing.Point(143, 109);
            this.lblMntCb.Name = "lblMntCb";
            this.lblMntCb.Size = new System.Drawing.Size(51, 13);
            this.lblMntCb.TabIndex = 6;
            this.lblMntCb.Text = "Total CB:";
            // 
            // tbxMntCb
            // 
            this.tbxMntCb.Location = new System.Drawing.Point(207, 106);
            this.tbxMntCb.Name = "tbxMntCb";
            this.tbxMntCb.ReadOnly = true;
            this.tbxMntCb.Size = new System.Drawing.Size(100, 20);
            this.tbxMntCb.TabIndex = 7;
            this.tbxMntCb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMntCheque
            // 
            this.lblMntCheque.AutoSize = true;
            this.lblMntCheque.Location = new System.Drawing.Point(120, 135);
            this.lblMntCheque.Name = "lblMntCheque";
            this.lblMntCheque.Size = new System.Drawing.Size(74, 13);
            this.lblMntCheque.TabIndex = 8;
            this.lblMntCheque.Text = "Total Chéque:";
            // 
            // lblMntCtr
            // 
            this.lblMntCtr.AutoSize = true;
            this.lblMntCtr.Location = new System.Drawing.Point(135, 161);
            this.lblMntCtr.Name = "lblMntCtr";
            this.lblMntCtr.Size = new System.Drawing.Size(59, 13);
            this.lblMntCtr.TabIndex = 9;
            this.lblMntCtr.Text = "Total CTR:";
            // 
            // tbxMntCheque
            // 
            this.tbxMntCheque.Location = new System.Drawing.Point(207, 132);
            this.tbxMntCheque.Name = "tbxMntCheque";
            this.tbxMntCheque.ReadOnly = true;
            this.tbxMntCheque.Size = new System.Drawing.Size(100, 20);
            this.tbxMntCheque.TabIndex = 10;
            this.tbxMntCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbxMntCtr
            // 
            this.tbxMntCtr.Location = new System.Drawing.Point(207, 158);
            this.tbxMntCtr.Name = "tbxMntCtr";
            this.tbxMntCtr.ReadOnly = true;
            this.tbxMntCtr.Size = new System.Drawing.Size(100, 20);
            this.tbxMntCtr.TabIndex = 11;
            this.tbxMntCtr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbxSaisieMnt
            // 
            this.tbxSaisieMnt.Location = new System.Drawing.Point(177, 231);
            this.tbxSaisieMnt.Name = "tbxSaisieMnt";
            this.tbxSaisieMnt.ReadOnly = true;
            this.tbxSaisieMnt.Size = new System.Drawing.Size(159, 20);
            this.tbxSaisieMnt.TabIndex = 12;
            this.tbxSaisieMnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnZero
            // 
            this.btnZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZero.Location = new System.Drawing.Point(232, 405);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(49, 40);
            this.btnZero.TabIndex = 13;
            this.btnZero.Text = "0";
            this.btnZero.UseVisualStyleBackColor = true;
            this.btnZero.Click += new System.EventHandler(this.btnZero_Click);
            // 
            // btnDeux
            // 
            this.btnDeux.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeux.Location = new System.Drawing.Point(232, 359);
            this.btnDeux.Name = "btnDeux";
            this.btnDeux.Size = new System.Drawing.Size(49, 40);
            this.btnDeux.TabIndex = 14;
            this.btnDeux.Text = "2";
            this.btnDeux.UseVisualStyleBackColor = true;
            this.btnDeux.Click += new System.EventHandler(this.btnDeux_Click);
            // 
            // btnUn
            // 
            this.btnUn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUn.Location = new System.Drawing.Point(177, 359);
            this.btnUn.Name = "btnUn";
            this.btnUn.Size = new System.Drawing.Size(49, 40);
            this.btnUn.TabIndex = 15;
            this.btnUn.Text = "1";
            this.btnUn.UseVisualStyleBackColor = true;
            this.btnUn.Click += new System.EventHandler(this.btnUn_Click);
            // 
            // btnTrois
            // 
            this.btnTrois.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrois.Location = new System.Drawing.Point(287, 359);
            this.btnTrois.Name = "btnTrois";
            this.btnTrois.Size = new System.Drawing.Size(49, 40);
            this.btnTrois.TabIndex = 16;
            this.btnTrois.Text = "3";
            this.btnTrois.UseVisualStyleBackColor = true;
            this.btnTrois.Click += new System.EventHandler(this.btnTrois_Click);
            // 
            // btnQuattre
            // 
            this.btnQuattre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuattre.Location = new System.Drawing.Point(177, 313);
            this.btnQuattre.Name = "btnQuattre";
            this.btnQuattre.Size = new System.Drawing.Size(49, 40);
            this.btnQuattre.TabIndex = 17;
            this.btnQuattre.Text = "4";
            this.btnQuattre.UseVisualStyleBackColor = true;
            this.btnQuattre.Click += new System.EventHandler(this.btnQuattre_Click);
            // 
            // btnCinq
            // 
            this.btnCinq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCinq.Location = new System.Drawing.Point(232, 313);
            this.btnCinq.Name = "btnCinq";
            this.btnCinq.Size = new System.Drawing.Size(49, 40);
            this.btnCinq.TabIndex = 18;
            this.btnCinq.Text = "5";
            this.btnCinq.UseVisualStyleBackColor = true;
            this.btnCinq.Click += new System.EventHandler(this.btnCinq_Click);
            // 
            // btnSix
            // 
            this.btnSix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSix.Location = new System.Drawing.Point(287, 313);
            this.btnSix.Name = "btnSix";
            this.btnSix.Size = new System.Drawing.Size(49, 40);
            this.btnSix.TabIndex = 19;
            this.btnSix.Text = "6";
            this.btnSix.UseVisualStyleBackColor = true;
            this.btnSix.Click += new System.EventHandler(this.btnSix_Click);
            // 
            // btnSept
            // 
            this.btnSept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSept.Location = new System.Drawing.Point(177, 269);
            this.btnSept.Name = "btnSept";
            this.btnSept.Size = new System.Drawing.Size(49, 40);
            this.btnSept.TabIndex = 20;
            this.btnSept.Text = "7";
            this.btnSept.UseVisualStyleBackColor = true;
            this.btnSept.Click += new System.EventHandler(this.btnSept_Click);
            // 
            // btnHuit
            // 
            this.btnHuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuit.Location = new System.Drawing.Point(232, 269);
            this.btnHuit.Name = "btnHuit";
            this.btnHuit.Size = new System.Drawing.Size(49, 40);
            this.btnHuit.TabIndex = 21;
            this.btnHuit.Text = "8";
            this.btnHuit.UseVisualStyleBackColor = true;
            this.btnHuit.Click += new System.EventHandler(this.btnHuit_Click);
            // 
            // btnNeuf
            // 
            this.btnNeuf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNeuf.Location = new System.Drawing.Point(287, 269);
            this.btnNeuf.Name = "btnNeuf";
            this.btnNeuf.Size = new System.Drawing.Size(49, 40);
            this.btnNeuf.TabIndex = 22;
            this.btnNeuf.Text = "9";
            this.btnNeuf.UseVisualStyleBackColor = true;
            this.btnNeuf.Click += new System.EventHandler(this.btnNeuf_Click);
            // 
            // btnVirgule
            // 
            this.btnVirgule.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVirgule.Location = new System.Drawing.Point(287, 405);
            this.btnVirgule.Name = "btnVirgule";
            this.btnVirgule.Size = new System.Drawing.Size(49, 40);
            this.btnVirgule.TabIndex = 23;
            this.btnVirgule.Text = ",";
            this.btnVirgule.UseVisualStyleBackColor = true;
            this.btnVirgule.Click += new System.EventHandler(this.btnVirgule_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(177, 405);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(49, 40);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "C";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnEspece
            // 
            this.btnEspece.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEspece.Location = new System.Drawing.Point(342, 269);
            this.btnEspece.Name = "btnEspece";
            this.btnEspece.Size = new System.Drawing.Size(80, 40);
            this.btnEspece.TabIndex = 25;
            this.btnEspece.Text = "Especes";
            this.btnEspece.UseVisualStyleBackColor = true;
            this.btnEspece.Click += new System.EventHandler(this.btnEspece_Click);
            // 
            // btnCarte
            // 
            this.btnCarte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarte.Location = new System.Drawing.Point(342, 313);
            this.btnCarte.Name = "btnCarte";
            this.btnCarte.Size = new System.Drawing.Size(80, 40);
            this.btnCarte.TabIndex = 26;
            this.btnCarte.Text = "CB";
            this.btnCarte.UseVisualStyleBackColor = true;
            this.btnCarte.Click += new System.EventHandler(this.btnCarte_Click);
            // 
            // btnCheque
            // 
            this.btnCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheque.Location = new System.Drawing.Point(342, 359);
            this.btnCheque.Name = "btnCheque";
            this.btnCheque.Size = new System.Drawing.Size(80, 40);
            this.btnCheque.TabIndex = 27;
            this.btnCheque.Text = "Cheque";
            this.btnCheque.UseVisualStyleBackColor = true;
            this.btnCheque.Click += new System.EventHandler(this.btnCheque_Click);
            // 
            // btnCtr
            // 
            this.btnCtr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCtr.Location = new System.Drawing.Point(342, 405);
            this.btnCtr.Name = "btnCtr";
            this.btnCtr.Size = new System.Drawing.Size(80, 40);
            this.btnCtr.TabIndex = 28;
            this.btnCtr.Text = "CTR";
            this.btnCtr.UseVisualStyleBackColor = true;
            this.btnCtr.Click += new System.EventHandler(this.btnCtr_Click);
            // 
            // lblResteEncore
            // 
            this.lblResteEncore.AutoSize = true;
            this.lblResteEncore.Location = new System.Drawing.Point(329, 57);
            this.lblResteEncore.Name = "lblResteEncore";
            this.lblResteEncore.Size = new System.Drawing.Size(38, 13);
            this.lblResteEncore.TabIndex = 29;
            this.lblResteEncore.Text = "Reste:";
            // 
            // tbxResteEncore
            // 
            this.tbxResteEncore.Location = new System.Drawing.Point(373, 54);
            this.tbxResteEncore.Name = "tbxResteEncore";
            this.tbxResteEncore.ReadOnly = true;
            this.tbxResteEncore.Size = new System.Drawing.Size(100, 20);
            this.tbxResteEncore.TabIndex = 30;
            this.tbxResteEncore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(12, 470);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(75, 23);
            this.btnValider.TabIndex = 31;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // btnCorrection
            // 
            this.btnCorrection.Location = new System.Drawing.Point(232, 470);
            this.btnCorrection.Name = "btnCorrection";
            this.btnCorrection.Size = new System.Drawing.Size(75, 23);
            this.btnCorrection.TabIndex = 32;
            this.btnCorrection.Text = "Annuler";
            this.btnCorrection.UseVisualStyleBackColor = true;
            this.btnCorrection.Click += new System.EventHandler(this.btnCorrection_Click);
            // 
            // lblNumFacture
            // 
            this.lblNumFacture.AutoSize = true;
            this.lblNumFacture.Location = new System.Drawing.Point(12, 9);
            this.lblNumFacture.Name = "lblNumFacture";
            this.lblNumFacture.Size = new System.Drawing.Size(59, 13);
            this.lblNumFacture.TabIndex = 33;
            this.lblNumFacture.Text = "Facture n°:";
            // 
            // tbxNumFacture
            // 
            this.tbxNumFacture.Location = new System.Drawing.Point(77, 6);
            this.tbxNumFacture.Name = "tbxNumFacture";
            this.tbxNumFacture.ReadOnly = true;
            this.tbxNumFacture.Size = new System.Drawing.Size(100, 20);
            this.tbxNumFacture.TabIndex = 34;
            this.tbxNumFacture.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNomClient
            // 
            this.lblNomClient.AutoSize = true;
            this.lblNomClient.Location = new System.Drawing.Point(272, 9);
            this.lblNomClient.Name = "lblNomClient";
            this.lblNomClient.Size = new System.Drawing.Size(75, 13);
            this.lblNomClient.TabIndex = 35;
            this.lblNomClient.Text = "Nom du client:";
            // 
            // tbxNomClient
            // 
            this.tbxNomClient.Location = new System.Drawing.Point(353, 6);
            this.tbxNomClient.Name = "tbxNomClient";
            this.tbxNomClient.ReadOnly = true;
            this.tbxNomClient.Size = new System.Drawing.Size(141, 20);
            this.tbxNomClient.TabIndex = 36;
            this.tbxNomClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSimplyOrder
            // 
            this.btnSimplyOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimplyOrder.Location = new System.Drawing.Point(428, 313);
            this.btnSimplyOrder.Name = "btnSimplyOrder";
            this.btnSimplyOrder.Size = new System.Drawing.Size(128, 40);
            this.btnSimplyOrder.TabIndex = 37;
            this.btnSimplyOrder.Text = "Simply Order";
            this.btnSimplyOrder.UseVisualStyleBackColor = true;
            this.btnSimplyOrder.Click += new System.EventHandler(this.btnSimplyOrder_Click);
            // 
            // lblTotalSimply
            // 
            this.lblTotalSimply.AutoSize = true;
            this.lblTotalSimply.Location = new System.Drawing.Point(98, 189);
            this.lblTotalSimply.Name = "lblTotalSimply";
            this.lblTotalSimply.Size = new System.Drawing.Size(96, 13);
            this.lblTotalSimply.TabIndex = 38;
            this.lblTotalSimply.Text = "Total Simply Order:";
            // 
            // tbxMntSimply
            // 
            this.tbxMntSimply.Location = new System.Drawing.Point(207, 186);
            this.tbxMntSimply.Name = "tbxMntSimply";
            this.tbxMntSimply.ReadOnly = true;
            this.tbxMntSimply.Size = new System.Drawing.Size(100, 20);
            this.tbxMntSimply.TabIndex = 39;
            this.tbxMntSimply.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ReglementCommande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 527);
            this.Controls.Add(this.tbxMntSimply);
            this.Controls.Add(this.lblTotalSimply);
            this.Controls.Add(this.btnSimplyOrder);
            this.Controls.Add(this.tbxNomClient);
            this.Controls.Add(this.lblNomClient);
            this.Controls.Add(this.tbxNumFacture);
            this.Controls.Add(this.lblNumFacture);
            this.Controls.Add(this.btnCorrection);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.tbxResteEncore);
            this.Controls.Add(this.lblResteEncore);
            this.Controls.Add(this.btnCtr);
            this.Controls.Add(this.btnCheque);
            this.Controls.Add(this.btnCarte);
            this.Controls.Add(this.btnEspece);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnVirgule);
            this.Controls.Add(this.btnNeuf);
            this.Controls.Add(this.btnHuit);
            this.Controls.Add(this.btnSept);
            this.Controls.Add(this.btnSix);
            this.Controls.Add(this.btnCinq);
            this.Controls.Add(this.btnQuattre);
            this.Controls.Add(this.btnTrois);
            this.Controls.Add(this.btnUn);
            this.Controls.Add(this.btnDeux);
            this.Controls.Add(this.btnZero);
            this.Controls.Add(this.tbxSaisieMnt);
            this.Controls.Add(this.tbxMntCtr);
            this.Controls.Add(this.tbxMntCheque);
            this.Controls.Add(this.lblMntCtr);
            this.Controls.Add(this.lblMntCheque);
            this.Controls.Add(this.tbxMntCb);
            this.Controls.Add(this.lblMntCb);
            this.Controls.Add(this.tbxMntEspece);
            this.Controls.Add(this.lblMntEspece);
            this.Controls.Add(this.lblTotalCde);
            this.Controls.Add(this.tbxTotalCommande);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.lblMessage);
            this.Name = "ReglementCommande";
            this.Text = "ReglementCommande";
            this.Load += new System.EventHandler(this.ReglementCommande_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnRetour;
        private System.Windows.Forms.TextBox tbxTotalCommande;
        private System.Windows.Forms.Label lblTotalCde;
        private System.Windows.Forms.Label lblMntEspece;
        private System.Windows.Forms.TextBox tbxMntEspece;
        private System.Windows.Forms.Label lblMntCb;
        private System.Windows.Forms.TextBox tbxMntCb;
        private System.Windows.Forms.Label lblMntCheque;
        private System.Windows.Forms.Label lblMntCtr;
        private System.Windows.Forms.TextBox tbxMntCheque;
        private System.Windows.Forms.TextBox tbxMntCtr;
        private System.Windows.Forms.TextBox tbxSaisieMnt;
        private System.Windows.Forms.Button btnZero;
        private System.Windows.Forms.Button btnDeux;
        private System.Windows.Forms.Button btnUn;
        private System.Windows.Forms.Button btnTrois;
        private System.Windows.Forms.Button btnQuattre;
        private System.Windows.Forms.Button btnCinq;
        private System.Windows.Forms.Button btnSix;
        private System.Windows.Forms.Button btnSept;
        private System.Windows.Forms.Button btnHuit;
        private System.Windows.Forms.Button btnNeuf;
        private System.Windows.Forms.Button btnVirgule;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnEspece;
        private System.Windows.Forms.Button btnCarte;
        private System.Windows.Forms.Button btnCheque;
        private System.Windows.Forms.Button btnCtr;
        private System.Windows.Forms.Label lblResteEncore;
        private System.Windows.Forms.TextBox tbxResteEncore;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Button btnCorrection;
        private System.Windows.Forms.Label lblNumFacture;
        private System.Windows.Forms.TextBox tbxNumFacture;
        private System.Windows.Forms.Label lblNomClient;
        private System.Windows.Forms.TextBox tbxNomClient;
        private System.Windows.Forms.Button btnSimplyOrder;
        private System.Windows.Forms.Label lblTotalSimply;
        private System.Windows.Forms.TextBox tbxMntSimply;
    }
}