using AutoBot2.Scripts.KakaoTalk;
using System;
using System.Windows.Forms;

namespace AutoBot2
{
    public partial class KakaoLoginPageForm : Form
    {
        KakaoTalkManager kakaoTalkManager;

        // 창 꺼질 때 실행 될 델리게이트
        public delegate void LoginDelegate();
        public event LoginDelegate LoginEvent;

        public KakaoLoginPageForm()
        {
            InitializeComponent();

            kakaoTalkManager = new KakaoTalkManager();
        }

        private void KakaoLoginPageForm_Load(object sender, EventArgs e)
        {
            // 카카오톡 로그인 API URL
            webBrowser1.Navigate(GlobalApiEndPoint.KAKAO_URL_USERTOKEN);
        }

        // 종료 이벤트
        private void BtnWebExit_Click(object sender, EventArgs e)
        {
            // Access 토큰 얻기
            if (kakaoTalkManager.GetAccessToken())
            {
                // 유저 데이터 얻기 (이름, 프로필 사진)
                if (kakaoTalkManager.UsingApiEvent(KakaoTalkManager.HttpMethod.Get, GlobalApiEndPoint.KAKAO_URL_USERDATA))
                {
                    // 로그인 이벤트 실행
                    LoginEvent();
                }
            }

            // 메모리 해제
            this.Dispose();
            this.Close();
        }

        // 브라우저 주소값이 변경시 발생 이벤트
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // 유저 토큰 얻기
            if (kakaoTalkManager.GetUserToKen(webBrowser1))
            {
                BtnWebExit_Click(sender, e);
            }
        }
    }
}
