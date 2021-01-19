namespace KAKAO_API
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_Login = new System.Windows.Forms.Button();
            this.Btn_Logout = new System.Windows.Forms.Button();
            this.Btn_TemplateSendMessage = new System.Windows.Forms.Button();
            this.Ptb_UserImg = new System.Windows.Forms.PictureBox();
            this.Label_UserName = new System.Windows.Forms.Label();
            this.Btn_UserData = new System.Windows.Forms.Button();
            this.Btn_DefaultSendMessage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Ptb_UserImg)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Login
            // 
            this.Btn_Login.Location = new System.Drawing.Point(12, 12);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.Size = new System.Drawing.Size(138, 33);
            this.Btn_Login.TabIndex = 0;
            this.Btn_Login.Text = "로그인 버튼";
            this.Btn_Login.UseVisualStyleBackColor = true;
            // 
            // Btn_Logout
            // 
            this.Btn_Logout.Location = new System.Drawing.Point(156, 12);
            this.Btn_Logout.Name = "Btn_Logout";
            this.Btn_Logout.Size = new System.Drawing.Size(138, 33);
            this.Btn_Logout.TabIndex = 1;
            this.Btn_Logout.Text = "로그아웃 버튼";
            this.Btn_Logout.UseVisualStyleBackColor = true;
            // 
            // Btn_TemplateSendMessage
            // 
            this.Btn_TemplateSendMessage.Location = new System.Drawing.Point(12, 51);
            this.Btn_TemplateSendMessage.Name = "Btn_TemplateSendMessage";
            this.Btn_TemplateSendMessage.Size = new System.Drawing.Size(138, 77);
            this.Btn_TemplateSendMessage.TabIndex = 2;
            this.Btn_TemplateSendMessage.Text = "템플릿 메시지";
            this.Btn_TemplateSendMessage.UseVisualStyleBackColor = true;
            // 
            // Ptb_UserImg
            // 
            this.Ptb_UserImg.Location = new System.Drawing.Point(12, 134);
            this.Ptb_UserImg.Name = "Ptb_UserImg";
            this.Ptb_UserImg.Size = new System.Drawing.Size(120, 120);
            this.Ptb_UserImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Ptb_UserImg.TabIndex = 3;
            this.Ptb_UserImg.TabStop = false;
            // 
            // Label_UserName
            // 
            this.Label_UserName.AutoSize = true;
            this.Label_UserName.Font = new System.Drawing.Font("굴림", 20F);
            this.Label_UserName.Location = new System.Drawing.Point(138, 134);
            this.Label_UserName.Name = "Label_UserName";
            this.Label_UserName.Size = new System.Drawing.Size(86, 27);
            this.Label_UserName.TabIndex = 4;
            this.Label_UserName.Text = "label1";
            // 
            // Btn_UserData
            // 
            this.Btn_UserData.Location = new System.Drawing.Point(300, 51);
            this.Btn_UserData.Name = "Btn_UserData";
            this.Btn_UserData.Size = new System.Drawing.Size(138, 77);
            this.Btn_UserData.TabIndex = 5;
            this.Btn_UserData.Text = "유저 데이터";
            this.Btn_UserData.UseVisualStyleBackColor = true;
            // 
            // Btn_DefaultSendMessage
            // 
            this.Btn_DefaultSendMessage.Location = new System.Drawing.Point(156, 51);
            this.Btn_DefaultSendMessage.Name = "Btn_DefaultSendMessage";
            this.Btn_DefaultSendMessage.Size = new System.Drawing.Size(138, 77);
            this.Btn_DefaultSendMessage.TabIndex = 6;
            this.Btn_DefaultSendMessage.Text = "커스텀 메시지";
            this.Btn_DefaultSendMessage.UseVisualStyleBackColor = true;
            // 
            // KakaoMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 277);
            this.Controls.Add(this.Btn_DefaultSendMessage);
            this.Controls.Add(this.Btn_UserData);
            this.Controls.Add(this.Label_UserName);
            this.Controls.Add(this.Ptb_UserImg);
            this.Controls.Add(this.Btn_TemplateSendMessage);
            this.Controls.Add(this.Btn_Logout);
            this.Controls.Add(this.Btn_Login);
            this.Name = "KakaoMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Ptb_UserImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Login;
        private System.Windows.Forms.Button Btn_Logout;
        private System.Windows.Forms.Button Btn_TemplateSendMessage;
        private System.Windows.Forms.PictureBox Ptb_UserImg;
        private System.Windows.Forms.Label Label_UserName;
        private System.Windows.Forms.Button Btn_UserData;
        private System.Windows.Forms.Button Btn_DefaultSendMessage;
    }
}

