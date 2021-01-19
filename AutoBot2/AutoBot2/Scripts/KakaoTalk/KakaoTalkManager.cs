using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace AutoBot2.Scripts.KakaoTalk
{
    class KakaoTalkManager
    {
        private HttpWebRequest request;

        private HttpWebResponse response;

        private Stream stream;

        public KakaoTalkManager()
        {
        }

        public enum HttpMethod
        {
            Get,
            Post,
            Put,
            Delete
        }

        // 에셋 토큰 얻기
        public bool GetAccessToken()
        {
            try
            {
                request = (HttpWebRequest)WebRequest.Create(GlobalApiEndPoint.KAKAO_URL_ACCESSTOKEN + GlobalKakaoData.userToken);
                response = (HttpWebResponse)request.GetResponse();

                stream = response.GetResponseStream();
                string sResult = new StreamReader(stream).ReadToEnd();
                var jResult = JObject.Parse(sResult);

                GlobalKakaoData.accessToken = jResult["access_token"].ToString();
                GlobalKakaoData.header = "Bearer " + GlobalKakaoData.accessToken;

                GlobalState.isLogin = true;

                StatusDisplay status = new StatusDisplay("로그인 성공!", StatusDisplay.enumType.Success);

                response.Dispose();
                stream.Dispose();

                return true;
            }
            catch
            {
                StatusDisplay status = new StatusDisplay("로그인을 하지 않았습니다.", StatusDisplay.enumType.Warning);
                if (response != null)
                {
                    response.Dispose();
                    stream.Dispose();
                }

                return false;
            }
        }

        public bool GetUserToKen(WebBrowser webBrowser)
        {
            string wUrl = webBrowser.Url.ToString();
            string originUrl = webBrowser.Url.ToString();
            wUrl = wUrl.Substring(wUrl.IndexOf("=") + 1);

            GlobalKakaoData.userToken = wUrl;

            // Url == 토큰 번호 
            if (originUrl.CompareTo("https://jaeho0613.tistory.com/oauth?code=" + GlobalKakaoData.userToken) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 사용할 이벤트 (메세지 전달, 연결 끊기, 유저 정보)
        /// </summary>
        /// <param name="UrlEndPoint">이벤트 URL값 전달</param>
        /// <param name="httpMethod">이벤트 전달 타입 (Post, Get..)</param>
        public bool UsingApiEvent(HttpMethod httpMethod, string UrlEndPoint, object data = null)
        {
            var json = data == null ? "" : JsonConvert.SerializeObject(data);
            StatusDisplay status;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(UrlEndPoint);
                request.Headers.Add("Authorization", GlobalKakaoData.header);
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = httpMethod.ToString();

                switch (UrlEndPoint)
                {
                    // 카카오톡 로그아웃
                    case GlobalApiEndPoint.KAKAO_URL_UNLINK:
                        GlobalState.isLogin = false;
                        response = (HttpWebResponse)request.GetResponse();
                        status = new StatusDisplay("로그아웃 성공!", StatusDisplay.enumType.Success);
                        break;

                    // 카카오톡 보내기
                    case GlobalApiEndPoint.KAKAO_URL_SEND_GAMESTARTMESSAGE:
                    case GlobalApiEndPoint.KAKAO_URL_SEND_MATCHINGMESSAGE:
                    case GlobalApiEndPoint.KAKAO_URL_SEND_TESTMESSAGE:
                    case GlobalApiEndPoint.KAKAO_URL_SEND_PICKCHAMPION:
                        response = (HttpWebResponse)request.GetResponse();
                        status = new StatusDisplay("메세지를 보냈습니다!", StatusDisplay.enumType.Success);
                        break;

                    // 매칭 픽 메시지 보내기
                    case GlobalApiEndPoint.KAKAO_URL_SEND_PICKTURNMESSAGE:
                        byte[] sendData = Encoding.UTF8.GetBytes("template_object=" + json);
                        request.ContentLength = sendData.Length;
                        stream = request.GetRequestStream();
                        stream.Write(sendData, 0, sendData.Length);
                        stream.Close();
                        response = (HttpWebResponse)request.GetResponse();
                        break;

                    // 유저 이미지, 이름 가져오기
                    case GlobalApiEndPoint.KAKAO_URL_USERDATA:
                        response = (HttpWebResponse)request.GetResponse();
                        stream = response.GetResponseStream();
                        string sResultJson = new StreamReader(stream).ReadToEnd();
                        var jResult = JObject.Parse(sResultJson);

                        if (jResult["properties"]["profile_image"] != null)
                        {
                            string UserImgUrl = jResult["properties"]["profile_image"].ToString();
                            GlobalKakaoData.UserImg = Utility.WebImageView(UserImgUrl);
                        }

                        GlobalKakaoData.UserNickName = jResult["properties"]["nickname"].ToString();

                        break;
                }

                if (stream != null)
                {
                    stream.Dispose();
                }
                if (response != null)
                {
                    response.Dispose();
                }

                return true;
            }
            catch
            {
                status = new StatusDisplay("'로그인','모두 동의 체크'의 오류 입니다!", StatusDisplay.enumType.Error);
                if (response != null)
                {
                    response.Dispose();
                    stream.Dispose();
                }
                return false;
            }
        }

        /// <summary>
        /// "text" : "message text" 추가해줘야함
        /// </summary>
        public JObject SendMessageJsonData()
        {
            JObject jObject = new JObject();
            JObject linkObject = new JObject();

            linkObject.Add("web_url", "https://developers.kakao.com");
            linkObject.Add("mobile_web_url", "https://developers.kakao.com");

            jObject.Add("object_type", "text");
            jObject.Add("link", linkObject);
            jObject.Add("button_title", "AutoBot" + GlobalState.Version);

            return jObject;
        }
    }
}