using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json.Linq; // dll 추가

namespace KAKAO_API
{
    public partial class Form1 : Form
    {
        private KakaoLoginPage kakaoLoginPage;
        private KakaoManager kakaoManager;

        public Form1()
        {
            InitializeComponent();

            Btn_Login.Click += Btn_Login_Click; // 클릭 이벤트 추가
            Btn_Logout.Click += Btn_Logout_Click; // 클릭 이벤트 추가
            Btn_UserData.Click += Btn_UserData_Click; // 클릭 이벤트 추가
            Btn_TemplateSendMessage.Click += Btn_TemplateSendMessage_Click; // 클릭 이벤트 추가
            Btn_DefaultSendMessage.Click += Btn_DefaultSendMessage_Click; // 클릭 이벤트 추가

            this.Load += KakaoMain_Load; // 로드 이벤트 추가

            kakaoManager = new KakaoManager();

            Console.WriteLine(KakaoApiEndPoint.KakaoLogInUrl);
        }

        private void KakaoMain_Load(object sender, EventArgs e)
        {
            Console.WriteLine("폼 로드");

            //WebBrowserVersionSetting();
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            Console.WriteLine("로그인 버튼");
            kakaoLoginPage = new KakaoLoginPage();
            kakaoLoginPage.ShowDialog();
        }

        private void Btn_Logout_Click(object sender, EventArgs e)
        {
            Console.WriteLine("로그아웃 버튼");
            kakaoManager.KakaoTalkLogOut();
        }

        private void Btn_TemplateSendMessage_Click(object sender, EventArgs e)
        {
            Console.WriteLine("템플릿 메시지 보내기 버튼");
            kakaoManager.KakaoTemplateSendMessage(KakaoApiEndPoint.KakaoSendMessageKey);
        }

        private void Btn_DefaultSendMessage_Click(object sender, EventArgs e)
        {
            Console.WriteLine("커스텀 메시지 보내기 버튼");

            JObject SendJson = new JObject();
            JObject LinkJson = new JObject();

            LinkJson.Add("web_url", "https://developers.kakao.com");
            LinkJson.Add("mobile_web_url", "https://developers.kakao.com");

            SendJson.Add("object_type", "text");
            SendJson.Add("text", "커스텀 메시지 입니다.\n\n https://jaeho0613.tistory.com/ \n\n");
            SendJson.Add("link", LinkJson);
            SendJson.Add("button_title", "안녕");

            Console.WriteLine(SendJson);

            kakaoManager.KakaoDefaultSendMessage(SendJson);
        }

        private void Btn_UserData_Click(object sender, EventArgs e)
        {
            Console.WriteLine("유저 데이터");
            kakaoManager.KakaoUserData();

            Ptb_UserImg.Image = KakaoData.UserImg;
            Label_UserName.Text = KakaoData.UserNickName;
        }

        private void WebBrowserVersionSetting()
        {
            RegistryKey registryKey = null; // 레지스트리 변경에 사용 될 변수

            int browserver = 0;
            int ie_emulation = 0;
            var targetApplication = Process.GetCurrentProcess().ProcessName + ".exe"; // 현재 프로그램 이름

            // 사용자 IE 버전 확인
            using (WebBrowser wb = new WebBrowser())
            {
                browserver = wb.Version.Major;
                if (browserver >= 11)
                    ie_emulation = 11001;
                else if (browserver == 10)
                    ie_emulation = 10001;
                else if (browserver == 9)
                    ie_emulation = 9999;
                else if (browserver == 8)
                    ie_emulation = 8888;
                else
                    ie_emulation = 7000;
            }

            try
            {
                registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);

                // IE가 없으면 실행 불가능
                if (registryKey == null)
                {
                    MessageBox.Show("웹 브라우저 버전 초기화에 실패했습니다..!");
                    Application.Exit();
                    return;
                }

                string FindAppkey = Convert.ToString(registryKey.GetValue(targetApplication));

                // 이미 키가 있다면 종료
                if (FindAppkey == ie_emulation.ToString())
                {
                    registryKey.Close();
                    return;
                }

                // 키가 없으므로 키 셋팅
                registryKey.SetValue(targetApplication, unchecked((int)ie_emulation), RegistryValueKind.DWord);

                // 다시 키를 받아와서
                FindAppkey = Convert.ToString(registryKey.GetValue(targetApplication));

                // 현재 브라우저 버전이랑 동일 한지 판단
                if (FindAppkey == ie_emulation.ToString())
                {
                    return;
                }
                else
                {
                    MessageBox.Show("웹 브라우저 버전 초기화에 실패했습니다..!");
                    Application.Exit();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("웹 브라우저 버전 초기화에 실패했습니다..!");
                Application.Exit();
                return;
            }
            finally
            {
                // 키 메모리 해제
                if (registryKey != null)
                {
                    registryKey.Close();
                }
            }
        }
    }
}
