namespace EventForm
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
            this.Btn_Success = new System.Windows.Forms.Button();
            this.Btn_Warning = new System.Windows.Forms.Button();
            this.Btn_Error = new System.Windows.Forms.Button();
            this.Btn_Info = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_Success
            // 
            this.Btn_Success.Location = new System.Drawing.Point(12, 12);
            this.Btn_Success.Name = "Btn_Success";
            this.Btn_Success.Size = new System.Drawing.Size(109, 76);
            this.Btn_Success.TabIndex = 0;
            this.Btn_Success.Text = "성공 타입";
            this.Btn_Success.UseVisualStyleBackColor = true;
            // 
            // Btn_Warning
            // 
            this.Btn_Warning.Location = new System.Drawing.Point(127, 12);
            this.Btn_Warning.Name = "Btn_Warning";
            this.Btn_Warning.Size = new System.Drawing.Size(109, 76);
            this.Btn_Warning.TabIndex = 1;
            this.Btn_Warning.Text = "실패 타입";
            this.Btn_Warning.UseVisualStyleBackColor = true;
            // 
            // Btn_Error
            // 
            this.Btn_Error.Location = new System.Drawing.Point(242, 12);
            this.Btn_Error.Name = "Btn_Error";
            this.Btn_Error.Size = new System.Drawing.Size(109, 76);
            this.Btn_Error.TabIndex = 2;
            this.Btn_Error.Text = "에러 타입";
            this.Btn_Error.UseVisualStyleBackColor = true;
            // 
            // Btn_Info
            // 
            this.Btn_Info.Location = new System.Drawing.Point(357, 12);
            this.Btn_Info.Name = "Btn_Info";
            this.Btn_Info.Size = new System.Drawing.Size(109, 76);
            this.Btn_Info.TabIndex = 3;
            this.Btn_Info.Text = "인포 타입";
            this.Btn_Info.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 105);
            this.Controls.Add(this.Btn_Info);
            this.Controls.Add(this.Btn_Error);
            this.Controls.Add(this.Btn_Warning);
            this.Controls.Add(this.Btn_Success);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Success;
        private System.Windows.Forms.Button Btn_Warning;
        private System.Windows.Forms.Button Btn_Error;
        private System.Windows.Forms.Button Btn_Info;
    }
}

