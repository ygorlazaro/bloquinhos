namespace BloquinhosWin
{
    partial class FrmLanguage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLanguage));
            this.btnEn = new System.Windows.Forms.Button();
            this.btnPt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEn
            // 
            this.btnEn.Image = global::BloquinhosWin.Properties.Resources.United_States;
            this.btnEn.Location = new System.Drawing.Point(82, 12);
            this.btnEn.Name = "btnEn";
            this.btnEn.Size = new System.Drawing.Size(64, 64);
            this.btnEn.TabIndex = 1;
            this.btnEn.UseVisualStyleBackColor = true;
            this.btnEn.Click += new System.EventHandler(this.BtnEnClick);
            // 
            // btnPt
            // 
            this.btnPt.Image = ((System.Drawing.Image)(resources.GetObject("btnPt.Image")));
            this.btnPt.Location = new System.Drawing.Point(12, 12);
            this.btnPt.Name = "btnPt";
            this.btnPt.Size = new System.Drawing.Size(64, 64);
            this.btnPt.TabIndex = 0;
            this.btnPt.UseVisualStyleBackColor = true;
            this.btnPt.Click += new System.EventHandler(this.BtnPtClick);
            // 
            // FrmLanguage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(155, 86);
            this.Controls.Add(this.btnEn);
            this.Controls.Add(this.btnPt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLanguage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Languages";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPt;
        private System.Windows.Forms.Button btnEn;

    }
}