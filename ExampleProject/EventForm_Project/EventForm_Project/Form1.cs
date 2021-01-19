using System;
using System.Windows.Forms;

namespace EventForm
{
    public partial class Form1 : Form
    {
        EventForm eventForm;

        public Form1()
        {
            InitializeComponent();

            Btn_Success.Click += Btn_Success_Click;
            Btn_Warning.Click += Btn_Warning_Click;
            Btn_Error.Click += Btn_Error_Click;
            Btn_Info.Click += Btn_Info_Click;
        }

        private void Btn_Info_Click(object sender, EventArgs e)
        {
            eventForm = new EventForm("정보가 출력됐습니다.", EventForm.enumType.Info);
        }

        private void Btn_Error_Click(object sender, EventArgs e)
        {
            eventForm = new EventForm("에러가 발생했습니다.", EventForm.enumType.Error);
        }

        private void Btn_Warning_Click(object sender, EventArgs e)
        {
            eventForm = new EventForm("실패 했습니다.", EventForm.enumType.Warning);
        }

        private void Btn_Success_Click(object sender, EventArgs e)
        {
            eventForm = new EventForm("성공 했습니다.", EventForm.enumType.Success);
        }
    }
}
