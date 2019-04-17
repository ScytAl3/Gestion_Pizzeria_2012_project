namespace pizzeria
{
    partial class AjouterCommande
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
            this.lblNumCde = new System.Windows.Forms.Label();
            this.tbxNumCde = new System.Windows.Forms.TextBox();
            this.lblNomClient = new System.Windows.Forms.Label();
            this.tbxNomClient = new System.Windows.Forms.TextBox();
            this.dtgCommandeDetail = new System.Windows.Forms.DataGridView();
            this.lblTotalCde = new System.Windows.Forms.Label();
            this.tbxTotal = new System.Windows.Forms.TextBox();
            this.gbxBoisson = new System.Windows.Forms.GroupBox();
            this.btnAjoutBoisson = new System.Windows.Forms.Button();
            this.nudQuantiteBoisson = new System.Windows.Forms.NumericUpDown();
            this.cboxBoisson = new System.Windows.Forms.ComboBox();
            this.cboxTypeBoisson = new System.Windows.Forms.ComboBox();
            this.gbxPlats = new System.Windows.Forms.GroupBox();
            this.btnAjoutPlat = new System.Windows.Forms.Button();
            this.tbxCommPlat = new System.Windows.Forms.TextBox();
            this.nudQuantitePlat = new System.Windows.Forms.NumericUpDown();
            this.cboxPlat = new System.Windows.Forms.ComboBox();
            this.cboxTypePlat = new System.Windows.Forms.ComboBox();
            this.gbxSupplement = new System.Windows.Forms.GroupBox();
            this.btnSuppAjout = new System.Windows.Forms.Button();
            this.nudQuantiteSupp = new System.Windows.Forms.NumericUpDown();
            this.cboxSupplement = new System.Windows.Forms.ComboBox();
            this.gbxPizza = new System.Windows.Forms.GroupBox();
            this.btnAjoutPizza = new System.Windows.Forms.Button();
            this.tbxCommPizza = new System.Windows.Forms.TextBox();
            this.nudQuantitePizza = new System.Windows.Forms.NumericUpDown();
            this.cboxPizza = new System.Windows.Forms.ComboBox();
            this.cboxTypePizza = new System.Windows.Forms.ComboBox();
            this.gboxMenu = new System.Windows.Forms.GroupBox();
            this.btnAjoutBmenu = new System.Windows.Forms.Button();
            this.tbxCommMenu = new System.Windows.Forms.TextBox();
            this.btnAjoutMenu = new System.Windows.Forms.Button();
            this.btnAjoutPmenu = new System.Windows.Forms.Button();
            this.lboxBoissonMenu = new System.Windows.Forms.ListBox();
            this.lboxPizzaMenu = new System.Windows.Forms.ListBox();
            this.cboxBoissonMenu = new System.Windows.Forms.ComboBox();
            this.cboxPizzaMenu = new System.Windows.Forms.ComboBox();
            this.cboxTypeMenu = new System.Windows.Forms.ComboBox();
            this.btnSuppModif = new System.Windows.Forms.Button();
            this.btnValider = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCommandeDetail)).BeginInit();
            this.gbxBoisson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantiteBoisson)).BeginInit();
            this.gbxPlats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantitePlat)).BeginInit();
            this.gbxSupplement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantiteSupp)).BeginInit();
            this.gbxPizza.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantitePizza)).BeginInit();
            this.gboxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(12, 719);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(53, 13);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Message!";
            // 
            // btnRetour
            // 
            this.btnRetour.Location = new System.Drawing.Point(1115, 706);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(75, 23);
            this.btnRetour.TabIndex = 1;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = true;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // lblNumCde
            // 
            this.lblNumCde.AutoSize = true;
            this.lblNumCde.Location = new System.Drawing.Point(12, 29);
            this.lblNumCde.Name = "lblNumCde";
            this.lblNumCde.Size = new System.Drawing.Size(76, 13);
            this.lblNumCde.TabIndex = 2;
            this.lblNumCde.Text = "Commande n°:";
            // 
            // tbxNumCde
            // 
            this.tbxNumCde.Location = new System.Drawing.Point(94, 26);
            this.tbxNumCde.Name = "tbxNumCde";
            this.tbxNumCde.ReadOnly = true;
            this.tbxNumCde.Size = new System.Drawing.Size(65, 20);
            this.tbxNumCde.TabIndex = 3;
            this.tbxNumCde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNomClient
            // 
            this.lblNomClient.AutoSize = true;
            this.lblNomClient.Location = new System.Drawing.Point(332, 29);
            this.lblNomClient.Name = "lblNomClient";
            this.lblNomClient.Size = new System.Drawing.Size(75, 13);
            this.lblNomClient.TabIndex = 4;
            this.lblNomClient.Text = "Nom du client:";
            // 
            // tbxNomClient
            // 
            this.tbxNomClient.Location = new System.Drawing.Point(413, 26);
            this.tbxNomClient.Name = "tbxNomClient";
            this.tbxNomClient.ReadOnly = true;
            this.tbxNomClient.Size = new System.Drawing.Size(162, 20);
            this.tbxNomClient.TabIndex = 5;
            this.tbxNomClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtgCommandeDetail
            // 
            this.dtgCommandeDetail.AllowUserToAddRows = false;
            this.dtgCommandeDetail.AllowUserToDeleteRows = false;
            this.dtgCommandeDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCommandeDetail.Location = new System.Drawing.Point(15, 91);
            this.dtgCommandeDetail.Name = "dtgCommandeDetail";
            this.dtgCommandeDetail.Size = new System.Drawing.Size(400, 189);
            this.dtgCommandeDetail.TabIndex = 6;
            // 
            // lblTotalCde
            // 
            this.lblTotalCde.AutoSize = true;
            this.lblTotalCde.Location = new System.Drawing.Point(238, 295);
            this.lblTotalCde.Name = "lblTotalCde";
            this.lblTotalCde.Size = new System.Drawing.Size(115, 13);
            this.lblTotalCde.TabIndex = 7;
            this.lblTotalCde.Text = "Total de la commande:";
            // 
            // tbxTotal
            // 
            this.tbxTotal.Location = new System.Drawing.Point(359, 292);
            this.tbxTotal.Name = "tbxTotal";
            this.tbxTotal.ReadOnly = true;
            this.tbxTotal.Size = new System.Drawing.Size(56, 20);
            this.tbxTotal.TabIndex = 8;
            this.tbxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbxBoisson
            // 
            this.gbxBoisson.Controls.Add(this.btnAjoutBoisson);
            this.gbxBoisson.Controls.Add(this.nudQuantiteBoisson);
            this.gbxBoisson.Controls.Add(this.cboxBoisson);
            this.gbxBoisson.Controls.Add(this.cboxTypeBoisson);
            this.gbxBoisson.Location = new System.Drawing.Point(623, 376);
            this.gbxBoisson.Name = "gbxBoisson";
            this.gbxBoisson.Size = new System.Drawing.Size(567, 80);
            this.gbxBoisson.TabIndex = 68;
            this.gbxBoisson.TabStop = false;
            this.gbxBoisson.Text = "Les Boissons";
            // 
            // btnAjoutBoisson
            // 
            this.btnAjoutBoisson.Location = new System.Drawing.Point(474, 38);
            this.btnAjoutBoisson.Name = "btnAjoutBoisson";
            this.btnAjoutBoisson.Size = new System.Drawing.Size(87, 23);
            this.btnAjoutBoisson.TabIndex = 3;
            this.btnAjoutBoisson.Text = "Ajouter";
            this.btnAjoutBoisson.UseVisualStyleBackColor = true;
            this.btnAjoutBoisson.Click += new System.EventHandler(this.btnAjoutBoisson_Click_1);
            // 
            // nudQuantiteBoisson
            // 
            this.nudQuantiteBoisson.Location = new System.Drawing.Point(381, 38);
            this.nudQuantiteBoisson.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantiteBoisson.Name = "nudQuantiteBoisson";
            this.nudQuantiteBoisson.Size = new System.Drawing.Size(66, 20);
            this.nudQuantiteBoisson.TabIndex = 2;
            this.nudQuantiteBoisson.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cboxBoisson
            // 
            this.cboxBoisson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxBoisson.FormattingEnabled = true;
            this.cboxBoisson.Location = new System.Drawing.Point(201, 37);
            this.cboxBoisson.Name = "cboxBoisson";
            this.cboxBoisson.Size = new System.Drawing.Size(138, 21);
            this.cboxBoisson.TabIndex = 1;
            // 
            // cboxTypeBoisson
            // 
            this.cboxTypeBoisson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTypeBoisson.FormattingEnabled = true;
            this.cboxTypeBoisson.Location = new System.Drawing.Point(6, 37);
            this.cboxTypeBoisson.Name = "cboxTypeBoisson";
            this.cboxTypeBoisson.Size = new System.Drawing.Size(138, 21);
            this.cboxTypeBoisson.TabIndex = 0;
            this.cboxTypeBoisson.SelectedValueChanged += new System.EventHandler(this.cboxTypeBoisson_SelectedValueChanged_1);
            // 
            // gbxPlats
            // 
            this.gbxPlats.Controls.Add(this.btnAjoutPlat);
            this.gbxPlats.Controls.Add(this.tbxCommPlat);
            this.gbxPlats.Controls.Add(this.nudQuantitePlat);
            this.gbxPlats.Controls.Add(this.cboxPlat);
            this.gbxPlats.Controls.Add(this.cboxTypePlat);
            this.gbxPlats.Location = new System.Drawing.Point(623, 244);
            this.gbxPlats.Name = "gbxPlats";
            this.gbxPlats.Size = new System.Drawing.Size(567, 117);
            this.gbxPlats.TabIndex = 67;
            this.gbxPlats.TabStop = false;
            this.gbxPlats.Text = "Les Plats et desserts";
            // 
            // btnAjoutPlat
            // 
            this.btnAjoutPlat.Location = new System.Drawing.Point(474, 75);
            this.btnAjoutPlat.Name = "btnAjoutPlat";
            this.btnAjoutPlat.Size = new System.Drawing.Size(87, 23);
            this.btnAjoutPlat.TabIndex = 4;
            this.btnAjoutPlat.Text = "Ajouter";
            this.btnAjoutPlat.UseVisualStyleBackColor = true;
            this.btnAjoutPlat.Click += new System.EventHandler(this.btnAjoutPlat_Click_1);
            // 
            // tbxCommPlat
            // 
            this.tbxCommPlat.Location = new System.Drawing.Point(6, 78);
            this.tbxCommPlat.Name = "tbxCommPlat";
            this.tbxCommPlat.Size = new System.Drawing.Size(371, 20);
            this.tbxCommPlat.TabIndex = 3;
            // 
            // nudQuantitePlat
            // 
            this.nudQuantitePlat.Location = new System.Drawing.Point(381, 36);
            this.nudQuantitePlat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantitePlat.Name = "nudQuantitePlat";
            this.nudQuantitePlat.Size = new System.Drawing.Size(66, 20);
            this.nudQuantitePlat.TabIndex = 2;
            this.nudQuantitePlat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cboxPlat
            // 
            this.cboxPlat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxPlat.FormattingEnabled = true;
            this.cboxPlat.Location = new System.Drawing.Point(201, 35);
            this.cboxPlat.Name = "cboxPlat";
            this.cboxPlat.Size = new System.Drawing.Size(138, 21);
            this.cboxPlat.TabIndex = 1;
            // 
            // cboxTypePlat
            // 
            this.cboxTypePlat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTypePlat.FormattingEnabled = true;
            this.cboxTypePlat.Location = new System.Drawing.Point(6, 35);
            this.cboxTypePlat.Name = "cboxTypePlat";
            this.cboxTypePlat.Size = new System.Drawing.Size(138, 21);
            this.cboxTypePlat.TabIndex = 0;
            this.cboxTypePlat.SelectedValueChanged += new System.EventHandler(this.cboxTypePlat_SelectedValueChanged_1);
            // 
            // gbxSupplement
            // 
            this.gbxSupplement.Controls.Add(this.btnSuppAjout);
            this.gbxSupplement.Controls.Add(this.nudQuantiteSupp);
            this.gbxSupplement.Controls.Add(this.cboxSupplement);
            this.gbxSupplement.Location = new System.Drawing.Point(623, 142);
            this.gbxSupplement.Name = "gbxSupplement";
            this.gbxSupplement.Size = new System.Drawing.Size(567, 80);
            this.gbxSupplement.TabIndex = 66;
            this.gbxSupplement.TabStop = false;
            this.gbxSupplement.Text = "Les Suppléments";
            // 
            // btnSuppAjout
            // 
            this.btnSuppAjout.Location = new System.Drawing.Point(474, 30);
            this.btnSuppAjout.Name = "btnSuppAjout";
            this.btnSuppAjout.Size = new System.Drawing.Size(87, 23);
            this.btnSuppAjout.TabIndex = 2;
            this.btnSuppAjout.Text = "Ajouter";
            this.btnSuppAjout.UseVisualStyleBackColor = true;
            this.btnSuppAjout.Click += new System.EventHandler(this.btnSuppAjout_Click_1);
            // 
            // nudQuantiteSupp
            // 
            this.nudQuantiteSupp.Location = new System.Drawing.Point(183, 33);
            this.nudQuantiteSupp.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantiteSupp.Name = "nudQuantiteSupp";
            this.nudQuantiteSupp.Size = new System.Drawing.Size(59, 20);
            this.nudQuantiteSupp.TabIndex = 1;
            this.nudQuantiteSupp.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cboxSupplement
            // 
            this.cboxSupplement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSupplement.FormattingEnabled = true;
            this.cboxSupplement.Location = new System.Drawing.Point(6, 32);
            this.cboxSupplement.Name = "cboxSupplement";
            this.cboxSupplement.Size = new System.Drawing.Size(138, 21);
            this.cboxSupplement.TabIndex = 0;
            // 
            // gbxPizza
            // 
            this.gbxPizza.Controls.Add(this.btnAjoutPizza);
            this.gbxPizza.Controls.Add(this.tbxCommPizza);
            this.gbxPizza.Controls.Add(this.nudQuantitePizza);
            this.gbxPizza.Controls.Add(this.cboxPizza);
            this.gbxPizza.Controls.Add(this.cboxTypePizza);
            this.gbxPizza.Location = new System.Drawing.Point(623, 12);
            this.gbxPizza.Name = "gbxPizza";
            this.gbxPizza.Size = new System.Drawing.Size(567, 117);
            this.gbxPizza.TabIndex = 65;
            this.gbxPizza.TabStop = false;
            this.gbxPizza.Text = "Les Pizzas";
            // 
            // btnAjoutPizza
            // 
            this.btnAjoutPizza.Location = new System.Drawing.Point(474, 75);
            this.btnAjoutPizza.Name = "btnAjoutPizza";
            this.btnAjoutPizza.Size = new System.Drawing.Size(87, 23);
            this.btnAjoutPizza.TabIndex = 4;
            this.btnAjoutPizza.Text = "Ajouter";
            this.btnAjoutPizza.UseVisualStyleBackColor = true;
            this.btnAjoutPizza.Click += new System.EventHandler(this.btnAjoutPizza_Click_1);
            // 
            // tbxCommPizza
            // 
            this.tbxCommPizza.Location = new System.Drawing.Point(6, 75);
            this.tbxCommPizza.MaxLength = 50;
            this.tbxCommPizza.Name = "tbxCommPizza";
            this.tbxCommPizza.Size = new System.Drawing.Size(371, 20);
            this.tbxCommPizza.TabIndex = 3;
            // 
            // nudQuantitePizza
            // 
            this.nudQuantitePizza.Location = new System.Drawing.Point(381, 33);
            this.nudQuantitePizza.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantitePizza.Name = "nudQuantitePizza";
            this.nudQuantitePizza.Size = new System.Drawing.Size(66, 20);
            this.nudQuantitePizza.TabIndex = 2;
            this.nudQuantitePizza.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cboxPizza
            // 
            this.cboxPizza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxPizza.FormattingEnabled = true;
            this.cboxPizza.Location = new System.Drawing.Point(201, 32);
            this.cboxPizza.Name = "cboxPizza";
            this.cboxPizza.Size = new System.Drawing.Size(138, 21);
            this.cboxPizza.TabIndex = 1;
            // 
            // cboxTypePizza
            // 
            this.cboxTypePizza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTypePizza.FormattingEnabled = true;
            this.cboxTypePizza.Location = new System.Drawing.Point(6, 32);
            this.cboxTypePizza.Name = "cboxTypePizza";
            this.cboxTypePizza.Size = new System.Drawing.Size(138, 21);
            this.cboxTypePizza.TabIndex = 0;
            this.cboxTypePizza.SelectedValueChanged += new System.EventHandler(this.cboxTypePizza_SelectedValueChanged_1);
            // 
            // gboxMenu
            // 
            this.gboxMenu.Controls.Add(this.btnAjoutBmenu);
            this.gboxMenu.Controls.Add(this.tbxCommMenu);
            this.gboxMenu.Controls.Add(this.btnAjoutMenu);
            this.gboxMenu.Controls.Add(this.btnAjoutPmenu);
            this.gboxMenu.Controls.Add(this.lboxBoissonMenu);
            this.gboxMenu.Controls.Add(this.lboxPizzaMenu);
            this.gboxMenu.Controls.Add(this.cboxBoissonMenu);
            this.gboxMenu.Controls.Add(this.cboxPizzaMenu);
            this.gboxMenu.Controls.Add(this.cboxTypeMenu);
            this.gboxMenu.Location = new System.Drawing.Point(623, 474);
            this.gboxMenu.Name = "gboxMenu";
            this.gboxMenu.Size = new System.Drawing.Size(567, 220);
            this.gboxMenu.TabIndex = 69;
            this.gboxMenu.TabStop = false;
            this.gboxMenu.Text = "Les Menus";
            // 
            // btnAjoutBmenu
            // 
            this.btnAjoutBmenu.Location = new System.Drawing.Point(527, 36);
            this.btnAjoutBmenu.Name = "btnAjoutBmenu";
            this.btnAjoutBmenu.Size = new System.Drawing.Size(18, 23);
            this.btnAjoutBmenu.TabIndex = 8;
            this.btnAjoutBmenu.Text = "+";
            this.btnAjoutBmenu.UseVisualStyleBackColor = true;
            this.btnAjoutBmenu.Click += new System.EventHandler(this.btnAjoutBmenu_Click_1);
            // 
            // tbxCommMenu
            // 
            this.tbxCommMenu.Location = new System.Drawing.Point(6, 194);
            this.tbxCommMenu.Name = "tbxCommMenu";
            this.tbxCommMenu.Size = new System.Drawing.Size(371, 20);
            this.tbxCommMenu.TabIndex = 7;
            // 
            // btnAjoutMenu
            // 
            this.btnAjoutMenu.Location = new System.Drawing.Point(474, 181);
            this.btnAjoutMenu.Name = "btnAjoutMenu";
            this.btnAjoutMenu.Size = new System.Drawing.Size(87, 23);
            this.btnAjoutMenu.TabIndex = 6;
            this.btnAjoutMenu.Text = "Ajouter";
            this.btnAjoutMenu.UseVisualStyleBackColor = true;
            this.btnAjoutMenu.Click += new System.EventHandler(this.btnAjoutMenu_Click_1);
            // 
            // btnAjoutPmenu
            // 
            this.btnAjoutPmenu.Location = new System.Drawing.Point(332, 36);
            this.btnAjoutPmenu.Name = "btnAjoutPmenu";
            this.btnAjoutPmenu.Size = new System.Drawing.Size(18, 23);
            this.btnAjoutPmenu.TabIndex = 5;
            this.btnAjoutPmenu.Text = "+";
            this.btnAjoutPmenu.UseVisualStyleBackColor = true;
            this.btnAjoutPmenu.Click += new System.EventHandler(this.btnAjoutPmenu_Click_1);
            // 
            // lboxBoissonMenu
            // 
            this.lboxBoissonMenu.FormattingEnabled = true;
            this.lboxBoissonMenu.Location = new System.Drawing.Point(291, 80);
            this.lboxBoissonMenu.Name = "lboxBoissonMenu";
            this.lboxBoissonMenu.Size = new System.Drawing.Size(138, 95);
            this.lboxBoissonMenu.TabIndex = 4;
            this.lboxBoissonMenu.DoubleClick += new System.EventHandler(this.lboxBoissonMenu_DoubleClick_1);
            // 
            // lboxPizzaMenu
            // 
            this.lboxPizzaMenu.FormattingEnabled = true;
            this.lboxPizzaMenu.Location = new System.Drawing.Point(104, 80);
            this.lboxPizzaMenu.Name = "lboxPizzaMenu";
            this.lboxPizzaMenu.Size = new System.Drawing.Size(138, 95);
            this.lboxPizzaMenu.TabIndex = 3;
            this.lboxPizzaMenu.DoubleClick += new System.EventHandler(this.lboxPizzaMenu_DoubleClick_1);
            // 
            // cboxBoissonMenu
            // 
            this.cboxBoissonMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxBoissonMenu.FormattingEnabled = true;
            this.cboxBoissonMenu.Location = new System.Drawing.Point(372, 38);
            this.cboxBoissonMenu.Name = "cboxBoissonMenu";
            this.cboxBoissonMenu.Size = new System.Drawing.Size(138, 21);
            this.cboxBoissonMenu.TabIndex = 2;
            // 
            // cboxPizzaMenu
            // 
            this.cboxPizzaMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxPizzaMenu.FormattingEnabled = true;
            this.cboxPizzaMenu.Location = new System.Drawing.Point(174, 38);
            this.cboxPizzaMenu.Name = "cboxPizzaMenu";
            this.cboxPizzaMenu.Size = new System.Drawing.Size(138, 21);
            this.cboxPizzaMenu.TabIndex = 1;
            // 
            // cboxTypeMenu
            // 
            this.cboxTypeMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTypeMenu.FormattingEnabled = true;
            this.cboxTypeMenu.Location = new System.Drawing.Point(6, 38);
            this.cboxTypeMenu.Name = "cboxTypeMenu";
            this.cboxTypeMenu.Size = new System.Drawing.Size(138, 21);
            this.cboxTypeMenu.TabIndex = 0;
            this.cboxTypeMenu.SelectedValueChanged += new System.EventHandler(this.cboxTypeMenu_SelectedValueChanged_1);
            // 
            // btnSuppModif
            // 
            this.btnSuppModif.Location = new System.Drawing.Point(15, 295);
            this.btnSuppModif.Name = "btnSuppModif";
            this.btnSuppModif.Size = new System.Drawing.Size(101, 23);
            this.btnSuppModif.TabIndex = 70;
            this.btnSuppModif.Text = "Supprimer";
            this.btnSuppModif.UseVisualStyleBackColor = true;
            this.btnSuppModif.Click += new System.EventHandler(this.btnSuppModif_Click_1);
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(15, 693);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(76, 23);
            this.btnValider.TabIndex = 71;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // AjouterCommande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 741);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.btnSuppModif);
            this.Controls.Add(this.gboxMenu);
            this.Controls.Add(this.gbxBoisson);
            this.Controls.Add(this.gbxPlats);
            this.Controls.Add(this.gbxSupplement);
            this.Controls.Add(this.gbxPizza);
            this.Controls.Add(this.tbxTotal);
            this.Controls.Add(this.lblTotalCde);
            this.Controls.Add(this.dtgCommandeDetail);
            this.Controls.Add(this.tbxNomClient);
            this.Controls.Add(this.lblNomClient);
            this.Controls.Add(this.tbxNumCde);
            this.Controls.Add(this.lblNumCde);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.lblMessage);
            this.Name = "AjouterCommande";
            this.Text = "AjouterCommande";
            this.Load += new System.EventHandler(this.AjouterCommande_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCommandeDetail)).EndInit();
            this.gbxBoisson.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantiteBoisson)).EndInit();
            this.gbxPlats.ResumeLayout(false);
            this.gbxPlats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantitePlat)).EndInit();
            this.gbxSupplement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantiteSupp)).EndInit();
            this.gbxPizza.ResumeLayout(false);
            this.gbxPizza.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantitePizza)).EndInit();
            this.gboxMenu.ResumeLayout(false);
            this.gboxMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnRetour;
        private System.Windows.Forms.Label lblNumCde;
        private System.Windows.Forms.TextBox tbxNumCde;
        private System.Windows.Forms.Label lblNomClient;
        private System.Windows.Forms.TextBox tbxNomClient;
        private System.Windows.Forms.DataGridView dtgCommandeDetail;
        private System.Windows.Forms.Label lblTotalCde;
        private System.Windows.Forms.TextBox tbxTotal;
        private System.Windows.Forms.GroupBox gbxBoisson;
        private System.Windows.Forms.Button btnAjoutBoisson;
        private System.Windows.Forms.NumericUpDown nudQuantiteBoisson;
        private System.Windows.Forms.ComboBox cboxBoisson;
        private System.Windows.Forms.ComboBox cboxTypeBoisson;
        private System.Windows.Forms.GroupBox gbxPlats;
        private System.Windows.Forms.Button btnAjoutPlat;
        private System.Windows.Forms.TextBox tbxCommPlat;
        private System.Windows.Forms.NumericUpDown nudQuantitePlat;
        private System.Windows.Forms.ComboBox cboxPlat;
        private System.Windows.Forms.ComboBox cboxTypePlat;
        private System.Windows.Forms.GroupBox gbxSupplement;
        private System.Windows.Forms.Button btnSuppAjout;
        private System.Windows.Forms.NumericUpDown nudQuantiteSupp;
        private System.Windows.Forms.ComboBox cboxSupplement;
        private System.Windows.Forms.GroupBox gbxPizza;
        private System.Windows.Forms.Button btnAjoutPizza;
        private System.Windows.Forms.TextBox tbxCommPizza;
        private System.Windows.Forms.NumericUpDown nudQuantitePizza;
        private System.Windows.Forms.ComboBox cboxPizza;
        private System.Windows.Forms.ComboBox cboxTypePizza;
        private System.Windows.Forms.GroupBox gboxMenu;
        private System.Windows.Forms.Button btnAjoutBmenu;
        private System.Windows.Forms.TextBox tbxCommMenu;
        private System.Windows.Forms.Button btnAjoutMenu;
        private System.Windows.Forms.Button btnAjoutPmenu;
        private System.Windows.Forms.ListBox lboxBoissonMenu;
        private System.Windows.Forms.ListBox lboxPizzaMenu;
        private System.Windows.Forms.ComboBox cboxBoissonMenu;
        private System.Windows.Forms.ComboBox cboxPizzaMenu;
        private System.Windows.Forms.ComboBox cboxTypeMenu;
        private System.Windows.Forms.Button btnSuppModif;
        private System.Windows.Forms.Button btnValider;
    }
}