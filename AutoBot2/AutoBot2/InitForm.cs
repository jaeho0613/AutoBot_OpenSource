using AutoBot2.Scripts.Init;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AutoBot2
{
    public partial class InitForm : Form
    {
        InitManager initManager;

        Timer timer = new Timer(); // UI Animation Timer

        string path = Application.StartupPath; // 챔피언 목록 json 저장 경로
        string targetApplication; // WebBrowser 타켓
        int ieEmulation; // WebBrowser 버전

        public InitForm(string targetApplication, int ieEmulation)
        {
            InitializeComponent();

            initManager = new InitManager();

            timer.Tick += new EventHandler(FadeOut);
            timer.Interval = 100;

            this.targetApplication = targetApplication;
            this.ieEmulation = ieEmulation;
        }

        //폼이 로드되고 실행 이벤트
        private void InitForm_Shown(object sender, EventArgs e)
        {

            // 프로젝트 버전 체크
            if (initManager.SetProjectVersionCheck())
            {
                // 사용자 IE 버전 확인
                if (initManager.SetIEVersionRegistryInit(targetApplication, ieEmulation))
                {
                    // 롤 챔피언 Json 초기화
                    if (initManager.SetChampionJsonCreateInit(this.path))
                    {
                        Process.Start("https://jaeho0613.tistory.com/162");
                        timer.Start();
                    }
                }
            }
            else
            {
                MessageBox.Show("*[바탕화면]에 다운로드 했습니다!");
                Application.Exit();
            }
        }

        // UI Animation
        private void FadeOut(object sender, EventArgs e)
        {
            if (Opacity <= 0)
            {
                timer.Stop();
                this.Dispose();
                this.Close();
            }
            else
                Opacity -= 0.05;
        }

        // UI Init Check
        //private void IsInit(Label label, bool isInit, string msg)
        //{
        //    if (isInit)
        //    {
        //        label.Text = msg;
        //        label.ForeColor = Color.Green;
        //    }
        //    else
        //    {
        //        label.Text = msg;
        //        label.ForeColor = Color.DarkRed;
        //    }
        //}
    }
}
