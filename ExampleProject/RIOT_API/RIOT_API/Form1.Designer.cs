namespace RIOT_API
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
            this.TextBox_Url = new System.Windows.Forms.TextBox();
            this.Btn_Using = new System.Windows.Forms.Button();
            this.TextBox_OutPut = new System.Windows.Forms.TextBox();
            this.TextBox_Method = new System.Windows.Forms.TextBox();
            this.Btn_ClientInit = new System.Windows.Forms.Button();
            this.Btn_RunePage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBox_Url
            // 
            this.TextBox_Url.Location = new System.Drawing.Point(12, 12);
            this.TextBox_Url.Name = "TextBox_Url";
            this.TextBox_Url.Size = new System.Drawing.Size(352, 21);
            this.TextBox_Url.TabIndex = 0;
            // 
            // Btn_Using
            // 
            this.Btn_Using.Location = new System.Drawing.Point(12, 39);
            this.Btn_Using.Name = "Btn_Using";
            this.Btn_Using.Size = new System.Drawing.Size(75, 23);
            this.Btn_Using.TabIndex = 1;
            this.Btn_Using.Text = "시작";
            this.Btn_Using.UseVisualStyleBackColor = true;
            // 
            // TextBox_OutPut
            // 
            this.TextBox_OutPut.Location = new System.Drawing.Point(12, 68);
            this.TextBox_OutPut.Multiline = true;
            this.TextBox_OutPut.Name = "TextBox_OutPut";
            this.TextBox_OutPut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBox_OutPut.Size = new System.Drawing.Size(541, 483);
            this.TextBox_OutPut.TabIndex = 2;
            // 
            // TextBox_Method
            // 
            this.TextBox_Method.Location = new System.Drawing.Point(370, 12);
            this.TextBox_Method.Name = "TextBox_Method";
            this.TextBox_Method.Size = new System.Drawing.Size(102, 21);
            this.TextBox_Method.TabIndex = 3;
            // 
            // Btn_ClientInit
            // 
            this.Btn_ClientInit.Location = new System.Drawing.Point(478, 12);
            this.Btn_ClientInit.Name = "Btn_ClientInit";
            this.Btn_ClientInit.Size = new System.Drawing.Size(75, 23);
            this.Btn_ClientInit.TabIndex = 4;
            this.Btn_ClientInit.Text = "클라리언트";
            this.Btn_ClientInit.UseVisualStyleBackColor = true;
            // 
            // Btn_RunePage
            // 
            this.Btn_RunePage.Location = new System.Drawing.Point(93, 39);
            this.Btn_RunePage.Name = "Btn_RunePage";
            this.Btn_RunePage.Size = new System.Drawing.Size(75, 23);
            this.Btn_RunePage.TabIndex = 5;
            this.Btn_RunePage.Text = "룬 페이지";
            this.Btn_RunePage.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 561);
            this.Controls.Add(this.Btn_RunePage);
            this.Controls.Add(this.Btn_ClientInit);
            this.Controls.Add(this.TextBox_Method);
            this.Controls.Add(this.TextBox_OutPut);
            this.Controls.Add(this.Btn_Using);
            this.Controls.Add(this.TextBox_Url);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox_Url;
        private System.Windows.Forms.Button Btn_Using;
        private System.Windows.Forms.TextBox TextBox_OutPut;
        private System.Windows.Forms.TextBox TextBox_Method;
        private System.Windows.Forms.Button Btn_ClientInit;
        private System.Windows.Forms.Button Btn_RunePage;
    }
}

