namespace AutoBot2
{
    partial class StatusDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusDisplay));
            this.IconMessage = new FontAwesome.Sharp.IconPictureBox();
            this.BtnExit = new FontAwesome.Sharp.IconPictureBox();
            this.LabelMessageText = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.IconMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnExit)).BeginInit();
            this.SuspendLayout();
            // 
            // IconMessage
            // 
            this.IconMessage.BackColor = System.Drawing.Color.Transparent;
            this.IconMessage.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            this.IconMessage.IconColor = System.Drawing.Color.White;
            this.IconMessage.IconSize = 54;
            this.IconMessage.Location = new System.Drawing.Point(1, 8);
            this.IconMessage.Name = "IconMessage";
            this.IconMessage.Size = new System.Drawing.Size(54, 54);
            this.IconMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.IconMessage.TabIndex = 0;
            this.IconMessage.TabStop = false;
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.Transparent;
            this.BtnExit.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.BtnExit.IconColor = System.Drawing.Color.White;
            this.BtnExit.IconSize = 35;
            this.BtnExit.Location = new System.Drawing.Point(409, 18);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(35, 35);
            this.BtnExit.TabIndex = 1;
            this.BtnExit.TabStop = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // LabelMessageText
            // 
            this.LabelMessageText.AutoSize = true;
            this.LabelMessageText.Font = new System.Drawing.Font("나눔바른고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LabelMessageText.ForeColor = System.Drawing.Color.White;
            this.LabelMessageText.Location = new System.Drawing.Point(58, 23);
            this.LabelMessageText.Name = "LabelMessageText";
            this.LabelMessageText.Size = new System.Drawing.Size(138, 24);
            this.LabelMessageText.TabIndex = 2;
            this.LabelMessageText.Text = "Message Box";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // StatusDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(450, 70);
            this.Controls.Add(this.LabelMessageText);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.IconMessage);
            this.Font = new System.Drawing.Font("나눔바른고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StatusDisplay";
            this.Text = "알림창";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.IconMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox IconMessage;
        private FontAwesome.Sharp.IconPictureBox BtnExit;
        private System.Windows.Forms.Label LabelMessageText;
        private System.Windows.Forms.Timer timer1;
    }
}