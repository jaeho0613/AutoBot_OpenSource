namespace EventForm
{
    partial class EventForm
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
            this.IconMessage.IconChar = FontAwesome.Sharp.IconChar.None;
            this.IconMessage.IconColor = System.Drawing.Color.White;
            this.IconMessage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.IconMessage.IconSize = 54;
            this.IconMessage.Location = new System.Drawing.Point(12, 12);
            this.IconMessage.Name = "IconMessage";
            this.IconMessage.Size = new System.Drawing.Size(54, 54);
            this.IconMessage.TabIndex = 0;
            this.IconMessage.TabStop = false;
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.Transparent;
            this.BtnExit.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.BtnExit.IconColor = System.Drawing.Color.White;
            this.BtnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnExit.IconSize = 54;
            this.BtnExit.Location = new System.Drawing.Point(445, 12);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(54, 54);
            this.BtnExit.TabIndex = 1;
            this.BtnExit.TabStop = false;
            // 
            // LabelMessageText
            // 
            this.LabelMessageText.AutoSize = true;
            this.LabelMessageText.Font = new System.Drawing.Font("굴림", 30F);
            this.LabelMessageText.ForeColor = System.Drawing.Color.White;
            this.LabelMessageText.Location = new System.Drawing.Point(72, 12);
            this.LabelMessageText.Name = "LabelMessageText";
            this.LabelMessageText.Size = new System.Drawing.Size(128, 40);
            this.LabelMessageText.TabIndex = 2;
            this.LabelMessageText.Text = "label1";
            // 
            // EventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(512, 76);
            this.Controls.Add(this.LabelMessageText);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.IconMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EventForm";
            this.Text = "EventForm";
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