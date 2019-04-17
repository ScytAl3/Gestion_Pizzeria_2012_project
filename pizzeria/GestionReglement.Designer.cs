namespace pizzeria
{
    partial class GestionReglement
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
            this.dtgTypeReglement = new System.Windows.Forms.DataGridView();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnRetour = new System.Windows.Forms.Button();
            this.lblEtatCde = new System.Windows.Forms.Label();
            this.lbxEtat = new System.Windows.Forms.ListBox();
            this.lblRetrait = new System.Windows.Forms.Label();
            this.lbxRetrait = new System.Windows.Forms.ListBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblRechDate = new System.Windows.Forms.Label();
            this.lblTotalEspece = new System.Windows.Forms.Label();
            this.tbxTotalEspèces = new System.Windows.Forms.TextBox();
            this.lblTotalCb = new System.Windows.Forms.Label();
            this.tbxTotalCb = new System.Windows.Forms.TextBox();
            this.cbxRechMois = new System.Windows.Forms.CheckBox();
            this.lblTotalCheque = new System.Windows.Forms.Label();
            this.tbxTotalCheque = new System.Windows.Forms.TextBox();
            this.lblTotalCtr = new System.Windows.Forms.Label();
            this.tbxTotalCtr = new System.Windows.Forms.TextBox();
            this.lblTotalSimply = new System.Windows.Forms.Label();
            this.tbxSimply = new System.Windows.Forms.TextBox();
            this.lblLivraison = new System.Windows.Forms.Label();
            this.lblEspeceLivraison = new System.Windows.Forms.Label();
            this.tbxEspeceLivraison = new System.Windows.Forms.TextBox();
            this.lblChequeLivraison = new System.Windows.Forms.Label();
            this.tbxChequeLivraison = new System.Windows.Forms.TextBox();
            this.lblCtrLivraison = new System.Windows.Forms.Label();
            this.tbxCtrLivraison = new System.Windows.Forms.TextBox();
            this.lblSimplyLivraison = new System.Windows.Forms.Label();
            this.tbxSimplyLivraison = new System.Windows.Forms.TextBox();
            this.lblSurPlace = new System.Windows.Forms.Label();
            this.lblEspeceSP = new System.Windows.Forms.Label();
            this.tbxEspeceSP = new System.Windows.Forms.TextBox();
            this.lblCbSP = new System.Windows.Forms.Label();
            this.tbxCbSP = new System.Windows.Forms.TextBox();
            this.lblChequeSP = new System.Windows.Forms.Label();
            this.tbxChequeSP = new System.Windows.Forms.TextBox();
            this.lblCtrSP = new System.Windows.Forms.Label();
            this.tbxCtrSp = new System.Windows.Forms.TextBox();
            this.lblSimplySP = new System.Windows.Forms.Label();
            this.tbxSimplySP = new System.Windows.Forms.TextBox();
            this.lblTva1 = new System.Windows.Forms.Label();
            this.tbxPremTva = new System.Windows.Forms.TextBox();
            this.lblTva2 = new System.Windows.Forms.Label();
            this.tbxDeuxTva = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTypeReglement)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgTypeReglement
            // 
            this.dtgTypeReglement.AllowUserToAddRows = false;
            this.dtgTypeReglement.AllowUserToDeleteRows = false;
            this.dtgTypeReglement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTypeReglement.Location = new System.Drawing.Point(12, 77);
            this.dtgTypeReglement.Name = "dtgTypeReglement";
            this.dtgTypeReglement.Size = new System.Drawing.Size(750, 350);
            this.dtgTypeReglement.TabIndex = 0;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(12, 639);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(53, 13);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Message!";
            // 
            // btnRetour
            // 
            this.btnRetour.Location = new System.Drawing.Point(1138, 616);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(75, 23);
            this.btnRetour.TabIndex = 2;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = true;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // lblEtatCde
            // 
            this.lblEtatCde.AutoSize = true;
            this.lblEtatCde.Location = new System.Drawing.Point(796, 77);
            this.lblEtatCde.Name = "lblEtatCde";
            this.lblEtatCde.Size = new System.Drawing.Size(109, 13);
            this.lblEtatCde.TabIndex = 3;
            this.lblEtatCde.Text = "Etat des commandes:";
            // 
            // lbxEtat
            // 
            this.lbxEtat.Enabled = false;
            this.lbxEtat.FormattingEnabled = true;
            this.lbxEtat.Location = new System.Drawing.Point(799, 104);
            this.lbxEtat.Name = "lbxEtat";
            this.lbxEtat.Size = new System.Drawing.Size(161, 56);
            this.lbxEtat.TabIndex = 6;
            // 
            // lblRetrait
            // 
            this.lblRetrait.AutoSize = true;
            this.lblRetrait.Location = new System.Drawing.Point(796, 184);
            this.lblRetrait.Name = "lblRetrait";
            this.lblRetrait.Size = new System.Drawing.Size(177, 13);
            this.lblRetrait.TabIndex = 7;
            this.lblRetrait.Text = "Détail des commandes non-soldées:";
            // 
            // lbxRetrait
            // 
            this.lbxRetrait.Enabled = false;
            this.lbxRetrait.FormattingEnabled = true;
            this.lbxRetrait.Location = new System.Drawing.Point(799, 209);
            this.lbxRetrait.Name = "lbxRetrait";
            this.lbxRetrait.Size = new System.Drawing.Size(161, 95);
            this.lbxRetrait.TabIndex = 8;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(123, 39);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 16;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // lblRechDate
            // 
            this.lblRechDate.AutoSize = true;
            this.lblRechDate.Location = new System.Drawing.Point(9, 45);
            this.lblRechDate.Name = "lblRechDate";
            this.lblRechDate.Size = new System.Drawing.Size(108, 13);
            this.lblRechDate.TabIndex = 15;
            this.lblRechDate.Text = "Rechercher par date:";
            // 
            // lblTotalEspece
            // 
            this.lblTotalEspece.AutoSize = true;
            this.lblTotalEspece.Location = new System.Drawing.Point(12, 453);
            this.lblTotalEspece.Name = "lblTotalEspece";
            this.lblTotalEspece.Size = new System.Drawing.Size(97, 13);
            this.lblTotalEspece.TabIndex = 17;
            this.lblTotalEspece.Text = "Total des espèces:";
            // 
            // tbxTotalEspèces
            // 
            this.tbxTotalEspèces.Location = new System.Drawing.Point(115, 450);
            this.tbxTotalEspèces.Name = "tbxTotalEspèces";
            this.tbxTotalEspèces.ReadOnly = true;
            this.tbxTotalEspèces.Size = new System.Drawing.Size(58, 20);
            this.tbxTotalEspèces.TabIndex = 18;
            this.tbxTotalEspèces.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalCb
            // 
            this.lblTotalCb.AutoSize = true;
            this.lblTotalCb.Location = new System.Drawing.Point(179, 453);
            this.lblTotalCb.Name = "lblTotalCb";
            this.lblTotalCb.Size = new System.Drawing.Size(71, 13);
            this.lblTotalCb.TabIndex = 19;
            this.lblTotalCb.Text = "Total des CB:";
            // 
            // tbxTotalCb
            // 
            this.tbxTotalCb.Location = new System.Drawing.Point(256, 450);
            this.tbxTotalCb.Name = "tbxTotalCb";
            this.tbxTotalCb.ReadOnly = true;
            this.tbxTotalCb.Size = new System.Drawing.Size(58, 20);
            this.tbxTotalCb.TabIndex = 20;
            this.tbxTotalCb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbxRechMois
            // 
            this.cbxRechMois.AutoSize = true;
            this.cbxRechMois.Location = new System.Drawing.Point(372, 44);
            this.cbxRechMois.Name = "cbxRechMois";
            this.cbxRechMois.Size = new System.Drawing.Size(138, 17);
            this.cbxRechMois.TabIndex = 21;
            this.cbxRechMois.Text = "Rechercher sur un mois";
            this.cbxRechMois.UseVisualStyleBackColor = true;
            // 
            // lblTotalCheque
            // 
            this.lblTotalCheque.AutoSize = true;
            this.lblTotalCheque.Location = new System.Drawing.Point(320, 453);
            this.lblTotalCheque.Name = "lblTotalCheque";
            this.lblTotalCheque.Size = new System.Drawing.Size(78, 13);
            this.lblTotalCheque.TabIndex = 22;
            this.lblTotalCheque.Text = "Total chéques:";
            // 
            // tbxTotalCheque
            // 
            this.tbxTotalCheque.Location = new System.Drawing.Point(404, 450);
            this.tbxTotalCheque.Name = "tbxTotalCheque";
            this.tbxTotalCheque.ReadOnly = true;
            this.tbxTotalCheque.Size = new System.Drawing.Size(58, 20);
            this.tbxTotalCheque.TabIndex = 23;
            this.tbxTotalCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalCtr
            // 
            this.lblTotalCtr.AutoSize = true;
            this.lblTotalCtr.Location = new System.Drawing.Point(475, 453);
            this.lblTotalCtr.Name = "lblTotalCtr";
            this.lblTotalCtr.Size = new System.Drawing.Size(59, 13);
            this.lblTotalCtr.TabIndex = 24;
            this.lblTotalCtr.Text = "Total CTR:";
            // 
            // tbxTotalCtr
            // 
            this.tbxTotalCtr.Location = new System.Drawing.Point(540, 450);
            this.tbxTotalCtr.Name = "tbxTotalCtr";
            this.tbxTotalCtr.ReadOnly = true;
            this.tbxTotalCtr.Size = new System.Drawing.Size(58, 20);
            this.tbxTotalCtr.TabIndex = 25;
            this.tbxTotalCtr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalSimply
            // 
            this.lblTotalSimply.AutoSize = true;
            this.lblTotalSimply.Location = new System.Drawing.Point(613, 453);
            this.lblTotalSimply.Name = "lblTotalSimply";
            this.lblTotalSimply.Size = new System.Drawing.Size(96, 13);
            this.lblTotalSimply.TabIndex = 26;
            this.lblTotalSimply.Text = "Total Simply Order:";
            // 
            // tbxSimply
            // 
            this.tbxSimply.Location = new System.Drawing.Point(715, 450);
            this.tbxSimply.Name = "tbxSimply";
            this.tbxSimply.ReadOnly = true;
            this.tbxSimply.Size = new System.Drawing.Size(58, 20);
            this.tbxSimply.TabIndex = 27;
            this.tbxSimply.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblLivraison
            // 
            this.lblLivraison.AutoSize = true;
            this.lblLivraison.Location = new System.Drawing.Point(12, 489);
            this.lblLivraison.Name = "lblLivraison";
            this.lblLivraison.Size = new System.Drawing.Size(117, 13);
            this.lblLivraison.TabIndex = 28;
            this.lblLivraison.Text = "Encaissement livraison:";
            // 
            // lblEspeceLivraison
            // 
            this.lblEspeceLivraison.AutoSize = true;
            this.lblEspeceLivraison.Location = new System.Drawing.Point(12, 522);
            this.lblEspeceLivraison.Name = "lblEspeceLivraison";
            this.lblEspeceLivraison.Size = new System.Drawing.Size(77, 13);
            this.lblEspeceLivraison.TabIndex = 29;
            this.lblEspeceLivraison.Text = "Total espèces:";
            // 
            // tbxEspeceLivraison
            // 
            this.tbxEspeceLivraison.Location = new System.Drawing.Point(115, 519);
            this.tbxEspeceLivraison.Name = "tbxEspeceLivraison";
            this.tbxEspeceLivraison.ReadOnly = true;
            this.tbxEspeceLivraison.Size = new System.Drawing.Size(58, 20);
            this.tbxEspeceLivraison.TabIndex = 30;
            this.tbxEspeceLivraison.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblChequeLivraison
            // 
            this.lblChequeLivraison.AutoSize = true;
            this.lblChequeLivraison.Location = new System.Drawing.Point(320, 522);
            this.lblChequeLivraison.Name = "lblChequeLivraison";
            this.lblChequeLivraison.Size = new System.Drawing.Size(78, 13);
            this.lblChequeLivraison.TabIndex = 31;
            this.lblChequeLivraison.Text = "Total chéques:";
            // 
            // tbxChequeLivraison
            // 
            this.tbxChequeLivraison.Location = new System.Drawing.Point(404, 519);
            this.tbxChequeLivraison.Name = "tbxChequeLivraison";
            this.tbxChequeLivraison.ReadOnly = true;
            this.tbxChequeLivraison.Size = new System.Drawing.Size(58, 20);
            this.tbxChequeLivraison.TabIndex = 32;
            this.tbxChequeLivraison.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCtrLivraison
            // 
            this.lblCtrLivraison.AutoSize = true;
            this.lblCtrLivraison.Location = new System.Drawing.Point(475, 522);
            this.lblCtrLivraison.Name = "lblCtrLivraison";
            this.lblCtrLivraison.Size = new System.Drawing.Size(59, 13);
            this.lblCtrLivraison.TabIndex = 33;
            this.lblCtrLivraison.Text = "Total CTR:";
            // 
            // tbxCtrLivraison
            // 
            this.tbxCtrLivraison.Location = new System.Drawing.Point(540, 519);
            this.tbxCtrLivraison.Name = "tbxCtrLivraison";
            this.tbxCtrLivraison.ReadOnly = true;
            this.tbxCtrLivraison.Size = new System.Drawing.Size(58, 20);
            this.tbxCtrLivraison.TabIndex = 34;
            this.tbxCtrLivraison.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSimplyLivraison
            // 
            this.lblSimplyLivraison.AutoSize = true;
            this.lblSimplyLivraison.Location = new System.Drawing.Point(613, 522);
            this.lblSimplyLivraison.Name = "lblSimplyLivraison";
            this.lblSimplyLivraison.Size = new System.Drawing.Size(96, 13);
            this.lblSimplyLivraison.TabIndex = 35;
            this.lblSimplyLivraison.Text = "Total Simply Order:";
            // 
            // tbxSimplyLivraison
            // 
            this.tbxSimplyLivraison.Location = new System.Drawing.Point(715, 519);
            this.tbxSimplyLivraison.Name = "tbxSimplyLivraison";
            this.tbxSimplyLivraison.ReadOnly = true;
            this.tbxSimplyLivraison.Size = new System.Drawing.Size(58, 20);
            this.tbxSimplyLivraison.TabIndex = 36;
            this.tbxSimplyLivraison.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSurPlace
            // 
            this.lblSurPlace.AutoSize = true;
            this.lblSurPlace.Location = new System.Drawing.Point(12, 560);
            this.lblSurPlace.Name = "lblSurPlace";
            this.lblSurPlace.Size = new System.Drawing.Size(168, 13);
            this.lblSurPlace.TabIndex = 37;
            this.lblSurPlace.Text = "Encaissement sur place/emporter:";
            // 
            // lblEspeceSP
            // 
            this.lblEspeceSP.AutoSize = true;
            this.lblEspeceSP.Location = new System.Drawing.Point(12, 591);
            this.lblEspeceSP.Name = "lblEspeceSP";
            this.lblEspeceSP.Size = new System.Drawing.Size(77, 13);
            this.lblEspeceSP.TabIndex = 38;
            this.lblEspeceSP.Text = "Total espèces:";
            // 
            // tbxEspeceSP
            // 
            this.tbxEspeceSP.Location = new System.Drawing.Point(115, 588);
            this.tbxEspeceSP.Name = "tbxEspeceSP";
            this.tbxEspeceSP.ReadOnly = true;
            this.tbxEspeceSP.Size = new System.Drawing.Size(58, 20);
            this.tbxEspeceSP.TabIndex = 39;
            this.tbxEspeceSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCbSP
            // 
            this.lblCbSP.AutoSize = true;
            this.lblCbSP.Location = new System.Drawing.Point(179, 591);
            this.lblCbSP.Name = "lblCbSP";
            this.lblCbSP.Size = new System.Drawing.Size(51, 13);
            this.lblCbSP.TabIndex = 40;
            this.lblCbSP.Text = "Total CB:";
            // 
            // tbxCbSP
            // 
            this.tbxCbSP.Location = new System.Drawing.Point(256, 591);
            this.tbxCbSP.Name = "tbxCbSP";
            this.tbxCbSP.ReadOnly = true;
            this.tbxCbSP.Size = new System.Drawing.Size(58, 20);
            this.tbxCbSP.TabIndex = 41;
            this.tbxCbSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblChequeSP
            // 
            this.lblChequeSP.AutoSize = true;
            this.lblChequeSP.Location = new System.Drawing.Point(320, 594);
            this.lblChequeSP.Name = "lblChequeSP";
            this.lblChequeSP.Size = new System.Drawing.Size(78, 13);
            this.lblChequeSP.TabIndex = 42;
            this.lblChequeSP.Text = "Total chéques:";
            // 
            // tbxChequeSP
            // 
            this.tbxChequeSP.Location = new System.Drawing.Point(404, 588);
            this.tbxChequeSP.Name = "tbxChequeSP";
            this.tbxChequeSP.ReadOnly = true;
            this.tbxChequeSP.Size = new System.Drawing.Size(58, 20);
            this.tbxChequeSP.TabIndex = 43;
            this.tbxChequeSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCtrSP
            // 
            this.lblCtrSP.AutoSize = true;
            this.lblCtrSP.Location = new System.Drawing.Point(475, 594);
            this.lblCtrSP.Name = "lblCtrSP";
            this.lblCtrSP.Size = new System.Drawing.Size(59, 13);
            this.lblCtrSP.TabIndex = 44;
            this.lblCtrSP.Text = "Total CTR:";
            // 
            // tbxCtrSp
            // 
            this.tbxCtrSp.Location = new System.Drawing.Point(540, 588);
            this.tbxCtrSp.Name = "tbxCtrSp";
            this.tbxCtrSp.ReadOnly = true;
            this.tbxCtrSp.Size = new System.Drawing.Size(58, 20);
            this.tbxCtrSp.TabIndex = 45;
            this.tbxCtrSp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSimplySP
            // 
            this.lblSimplySP.AutoSize = true;
            this.lblSimplySP.Location = new System.Drawing.Point(613, 591);
            this.lblSimplySP.Name = "lblSimplySP";
            this.lblSimplySP.Size = new System.Drawing.Size(96, 13);
            this.lblSimplySP.TabIndex = 46;
            this.lblSimplySP.Text = "Total Simply Order:";
            // 
            // tbxSimplySP
            // 
            this.tbxSimplySP.Location = new System.Drawing.Point(715, 588);
            this.tbxSimplySP.Name = "tbxSimplySP";
            this.tbxSimplySP.ReadOnly = true;
            this.tbxSimplySP.Size = new System.Drawing.Size(58, 20);
            this.tbxSimplySP.TabIndex = 47;
            this.tbxSimplySP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTva1
            // 
            this.lblTva1.AutoSize = true;
            this.lblTva1.Location = new System.Drawing.Point(796, 327);
            this.lblTva1.Name = "lblTva1";
            this.lblTva1.Size = new System.Drawing.Size(99, 13);
            this.lblTva1.TabIndex = 48;
            this.lblTva1.Text = "Montant TVA à 7%:";
            // 
            // tbxPremTva
            // 
            this.tbxPremTva.Location = new System.Drawing.Point(799, 353);
            this.tbxPremTva.Name = "tbxPremTva";
            this.tbxPremTva.ReadOnly = true;
            this.tbxPremTva.Size = new System.Drawing.Size(100, 20);
            this.tbxPremTva.TabIndex = 49;
            this.tbxPremTva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTva2
            // 
            this.lblTva2.AutoSize = true;
            this.lblTva2.Location = new System.Drawing.Point(796, 389);
            this.lblTva2.Name = "lblTva2";
            this.lblTva2.Size = new System.Drawing.Size(111, 13);
            this.lblTva2.TabIndex = 50;
            this.lblTva2.Text = "Montant TVA à 19,6%";
            // 
            // tbxDeuxTva
            // 
            this.tbxDeuxTva.Location = new System.Drawing.Point(799, 416);
            this.tbxDeuxTva.Name = "tbxDeuxTva";
            this.tbxDeuxTva.ReadOnly = true;
            this.tbxDeuxTva.Size = new System.Drawing.Size(100, 20);
            this.tbxDeuxTva.TabIndex = 51;
            this.tbxDeuxTva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // GestionReglement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 661);
            this.Controls.Add(this.tbxDeuxTva);
            this.Controls.Add(this.lblTva2);
            this.Controls.Add(this.tbxPremTva);
            this.Controls.Add(this.lblTva1);
            this.Controls.Add(this.tbxSimplySP);
            this.Controls.Add(this.lblSimplySP);
            this.Controls.Add(this.tbxCtrSp);
            this.Controls.Add(this.lblCtrSP);
            this.Controls.Add(this.tbxChequeSP);
            this.Controls.Add(this.lblChequeSP);
            this.Controls.Add(this.tbxCbSP);
            this.Controls.Add(this.lblCbSP);
            this.Controls.Add(this.tbxEspeceSP);
            this.Controls.Add(this.lblEspeceSP);
            this.Controls.Add(this.lblSurPlace);
            this.Controls.Add(this.tbxSimplyLivraison);
            this.Controls.Add(this.lblSimplyLivraison);
            this.Controls.Add(this.tbxCtrLivraison);
            this.Controls.Add(this.lblCtrLivraison);
            this.Controls.Add(this.tbxChequeLivraison);
            this.Controls.Add(this.lblChequeLivraison);
            this.Controls.Add(this.tbxEspeceLivraison);
            this.Controls.Add(this.lblEspeceLivraison);
            this.Controls.Add(this.lblLivraison);
            this.Controls.Add(this.tbxSimply);
            this.Controls.Add(this.lblTotalSimply);
            this.Controls.Add(this.tbxTotalCtr);
            this.Controls.Add(this.lblTotalCtr);
            this.Controls.Add(this.tbxTotalCheque);
            this.Controls.Add(this.lblTotalCheque);
            this.Controls.Add(this.cbxRechMois);
            this.Controls.Add(this.tbxTotalCb);
            this.Controls.Add(this.lblTotalCb);
            this.Controls.Add(this.tbxTotalEspèces);
            this.Controls.Add(this.lblTotalEspece);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblRechDate);
            this.Controls.Add(this.lbxRetrait);
            this.Controls.Add(this.lblRetrait);
            this.Controls.Add(this.lbxEtat);
            this.Controls.Add(this.lblEtatCde);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.dtgTypeReglement);
            this.Name = "GestionReglement";
            this.Text = "GestionReglement";
            this.Load += new System.EventHandler(this.GestionReglement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTypeReglement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgTypeReglement;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnRetour;
        private System.Windows.Forms.Label lblEtatCde;
        private System.Windows.Forms.ListBox lbxEtat;
        private System.Windows.Forms.Label lblRetrait;
        private System.Windows.Forms.ListBox lbxRetrait;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblRechDate;
        private System.Windows.Forms.Label lblTotalEspece;
        private System.Windows.Forms.TextBox tbxTotalEspèces;
        private System.Windows.Forms.Label lblTotalCb;
        private System.Windows.Forms.TextBox tbxTotalCb;
        private System.Windows.Forms.CheckBox cbxRechMois;
        private System.Windows.Forms.Label lblTotalCheque;
        private System.Windows.Forms.TextBox tbxTotalCheque;
        private System.Windows.Forms.Label lblTotalCtr;
        private System.Windows.Forms.TextBox tbxTotalCtr;
        private System.Windows.Forms.Label lblTotalSimply;
        private System.Windows.Forms.TextBox tbxSimply;
        private System.Windows.Forms.Label lblLivraison;
        private System.Windows.Forms.Label lblEspeceLivraison;
        private System.Windows.Forms.TextBox tbxEspeceLivraison;
        private System.Windows.Forms.Label lblChequeLivraison;
        private System.Windows.Forms.TextBox tbxChequeLivraison;
        private System.Windows.Forms.Label lblCtrLivraison;
        private System.Windows.Forms.TextBox tbxCtrLivraison;
        private System.Windows.Forms.Label lblSimplyLivraison;
        private System.Windows.Forms.TextBox tbxSimplyLivraison;
        private System.Windows.Forms.Label lblSurPlace;
        private System.Windows.Forms.Label lblEspeceSP;
        private System.Windows.Forms.TextBox tbxEspeceSP;
        private System.Windows.Forms.Label lblCbSP;
        private System.Windows.Forms.TextBox tbxCbSP;
        private System.Windows.Forms.Label lblChequeSP;
        private System.Windows.Forms.TextBox tbxChequeSP;
        private System.Windows.Forms.Label lblCtrSP;
        private System.Windows.Forms.TextBox tbxCtrSp;
        private System.Windows.Forms.Label lblSimplySP;
        private System.Windows.Forms.TextBox tbxSimplySP;
        private System.Windows.Forms.Label lblTva1;
        private System.Windows.Forms.TextBox tbxPremTva;
        private System.Windows.Forms.Label lblTva2;
        private System.Windows.Forms.TextBox tbxDeuxTva;
    }
}