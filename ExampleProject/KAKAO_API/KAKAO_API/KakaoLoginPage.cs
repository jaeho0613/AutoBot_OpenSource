using System;
using System.Windows.Forms;

namespace KAKAO_API
{
    public partial class KakaoLoginPage : Form
    {
        KakaoManager kakaoManager;

        public KakaoLoginPage()
        {
            InitializeComponent();

            kakaoManager = new KakaoManager();

            webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted; // 웹 브라우저 창이 로드 될 때 마다 발생 이벤트

            webBrowser1.Navigate(KakaoApiEndPoint.KakaoLogInUrl); // 웹 브라우저 처음 열릴 URL 설정
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if(kakaoManager.GetUserToKen(webBrowser1))
            {
                Console.WriteLine("토큰 얻기 종료");
                kakaoManager.GetAccessToKen();
                this.Close();
            }
        }
    }
}
