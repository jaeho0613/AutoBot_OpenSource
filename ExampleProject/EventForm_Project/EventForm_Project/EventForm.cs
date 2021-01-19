using System;
using System.Drawing;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace EventForm
{
    public partial class EventForm : Form
    {
        /// <summary>
        /// 상태 표시 창을 보여줍니다.
        /// </summary>
        /// <param name="msg">전달할 메세지 string</param>
        /// <param name="type">메세지 타입 Enum</param>
        public EventForm(string msg, enumType type)
        {
            InitializeComponent();

            timer1.Tick += timer1_Tick;

            showAlert(msg, type);
        }

        public enum enumAction
        {
            wait,
            start,
            close
        }

        public enum enumType
        {
            Success,
            Warning,
            Error,
            Info
        }

        private EventForm.enumAction action;

        private int x, y;

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            switch (this.action)
            {
                case enumAction.wait:
                    timer1.Interval = 1500;
                    action = enumAction.close;
                    break;
                case enumAction.start:
                    timer1.Interval = 1;
                    this.Opacity += 0.1f;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = enumAction.wait;
                        }
                    }
                    break;
                case enumAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1f;

                    this.Left -= 3;
                    if (base.Opacity == 0)
                    {
                        this.Dispose();
                        this.Close();
                    }
                    break;
            }
        }

        public void showAlert(string msg, enumType type)
        {
            this.Opacity = 0.0f;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 0; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                EventForm frm = (EventForm)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - (this.Height * i + this.Height);
                    this.Location = new Point(this.x, this.y);
                    break;
                }
            }

            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case enumType.Success:
                    this.IconMessage.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
                    this.BackColor = Color.SeaGreen;
                    break;
                case enumType.Error:
                    this.IconMessage.IconChar = FontAwesome.Sharp.IconChar.Bomb;
                    this.BackColor = Color.DarkRed;
                    break;
                case enumType.Info:
                    this.IconMessage.IconChar = FontAwesome.Sharp.IconChar.InfoCircle;
                    this.BackColor = Color.RoyalBlue;
                    break;
                case enumType.Warning:
                    this.IconMessage.IconChar = FontAwesome.Sharp.IconChar.ExclamationCircle;
                    this.BackColor = Color.DarkOrange;
                    break;
            }

            this.LabelMessageText.Text = msg;
            this.Show();
            this.action = enumAction.start;
            this.timer1.Interval = 1;
            timer1.Start();
        }

        private void BtnExit_Click(object sender, System.EventArgs e)
        {
            timer1.Interval = 1;
            action = enumAction.close;
        }
    }
}