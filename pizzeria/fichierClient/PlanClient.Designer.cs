namespace pizzeria
{
    partial class PlanClient
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
            this.webBrowserPlan = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowserPlan
            // 
            this.webBrowserPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserPlan.Location = new System.Drawing.Point(0, 0);
            this.webBrowserPlan.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserPlan.Name = "webBrowserPlan";
            this.webBrowserPlan.Size = new System.Drawing.Size(984, 461);
            this.webBrowserPlan.TabIndex = 0;
            // 
            // PlanClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.webBrowserPlan);
            this.Name = "PlanClient";
            this.Text = "PlanClient";
            this.Load += new System.EventHandler(this.PlanClient_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserPlan;
    }
}