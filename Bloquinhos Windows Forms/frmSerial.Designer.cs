namespace BloquinhosWin
{
    sealed partial class FrmSerial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSerial));
            this.label1 = new System.Windows.Forms.Label();
            this.btnValidate = new System.Windows.Forms.Button();
            this.txtPre = new System.Windows.Forms.MaskedTextBox();
            this.txtPos = new System.Windows.Forms.MaskedTextBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 69);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your game is not registered. To play fully, enter with the serial at the field be" +
                "llow:";
            // 
            // btnValidate
            // 
            this.btnValidate.Image = global::BloquinhosWin.Properties.Resources.dollar;
            this.btnValidate.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnValidate.Location = new System.Drawing.Point(318, 118);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(84, 84);
            this.btnValidate.TabIndex = 3;
            this.btnValidate.Text = "Validate";
            this.btnValidate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.BtnValidateClick);
            // 
            // txtPre
            // 
            this.txtPre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPre.Location = new System.Drawing.Point(12, 60);
            this.txtPre.Mask = "9999-9999-9999-9999-9999-9999-9999-9999-9999";
            this.txtPre.Name = "txtPre";
            this.txtPre.ReadOnly = true;
            this.txtPre.Size = new System.Drawing.Size(480, 23);
            this.txtPre.TabIndex = 4;
            // 
            // txtPos
            // 
            this.txtPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPos.Location = new System.Drawing.Point(12, 89);
            this.txtPos.Mask = "9999-9999-9999-9999-9999-9999-9999-9999-9999";
            this.txtPos.Name = "txtPos";
            this.txtPos.Size = new System.Drawing.Size(480, 23);
            this.txtPos.TabIndex = 5;
            // 
            // btnFechar
            // 
            this.btnFechar.Image = global::BloquinhosWin.Properties.Resources.close;
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFechar.Location = new System.Drawing.Point(408, 118);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(84, 84);
            this.btnFechar.TabIndex = 6;
            this.btnFechar.Text = "Close";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.BtnFecharClick);
            // 
            // FrmSerial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 213);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.txtPos);
            this.Controls.Add(this.txtPre);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSerial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial";
            this.Load += new System.EventHandler(this.FrmSerial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.MaskedTextBox txtPre;
        private System.Windows.Forms.MaskedTextBox txtPos;
        private System.Windows.Forms.Button btnFechar;
    }
}