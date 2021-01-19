namespace AutoBot2
{
    partial class KakaoLoginPageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KakaoLoginPageForm));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.BtnWebExit = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BtnWebExit)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(500, 800);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // BtnWebExit
            // 
            this.BtnWebExit.BackColor = System.Drawing.Color.Transparent;
            this.BtnWebExit.ForeColor = System.Drawing.Color.Black;
            this.BtnWebExit.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.BtnWebExit.IconColor = System.Drawing.Color.Black;
            this.BtnWebExit.Location = new System.Drawing.Point(464, 0);
            this.BtnWebExit.Name = "BtnWebExit";
            this.BtnWebExit.Size = new System.Drawing.Size(32, 32);
            this.BtnWebExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BtnWebExit.TabIndex = 1;
            this.BtnWebExit.TabStop = false;
            this.BtnWebExit.Click += new System.EventHandler(this.BtnWebExit_Click);
            // 
            // KakaoLoginPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 800);
            this.Controls.Add(this.BtnWebExit);
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KakaoLoginPageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "카카오톡 로그인 창";
            this.Load += new System.EventHandler(this.KakaoLoginPageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BtnWebExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private FontAwesome.Sharp.IconPictureBox BtnWebExit;
    }
}