using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using RestSharp;

class KakaoManager
{
    public KakaoManager()
    {
    }

    public bool GetUserToKen(WebBrowser webBrowser)
    {
        string wUrl = webBrowser.Url.ToString();
        string userToken = wUrl.Substring(wUrl.IndexOf("=") + 1);

        if (wUrl.CompareTo(KakaoApiEndPoint.KakaoRedirectUrl + "?code=" + userToken) == 0)
        {
            Console.WriteLine("유저 토큰 얻기 성공");
            KakaoData.userToken = userToken;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool GetAccessToKen()
    {
        var client = new RestClient(KakaoApiEndPoint.KakaoHostOAuthUrl);

        var request = new RestRequest(KakaoApiEndPoint.KakaoOAuthUrl, Method.POST);
        request.AddParameter("grant_type", "authorization_code");
        request.AddParameter("client_id", KakaoApiEndPoint.KakaoRestApiKey);
        request.AddParameter("redirect_uri", KakaoApiEndPoint.KakaoRedirectUrl);
        request.AddParameter("code", KakaoData.userToken);

        var restResponse = client.Execute(request);
        var json = JObject.Parse(restResponse.Content);

        KakaoData.accessToken = json["access_token"].ToString();

        return true;
    }

    public void KakaoTalkLogOut()
    {
        var client = new RestClient(KakaoApiEndPoint.KakaoHostApiUrl);

        var request = new RestRequest(KakaoApiEndPoint.KakaoUnlinkUrl, Method.POST);
        request.AddHeader("Authorization", "bearer " + KakaoData.accessToken);

        if (client.Execute(request).IsSuccessful)
        {
            Console.WriteLine("로그아웃 성공");
        }
        else
        {
            Console.WriteLine("로그아웃 실패");
        }
    }

    /// <summary>
    /// 템플릿 메시지 보내기
    /// </summary>
    /// <param name="templateNum">템플릿 string 값</param>
    public void KakaoTemplateSendMessage(string templateNum)
    {
        var client = new RestClient(KakaoApiEndPoint.KakaoHostApiUrl);

        var request = new RestRequest(KakaoApiEndPoint.KakaoTemplateMessageUrl, Method.POST);
        request.AddHeader("Authorization", "bearer " + KakaoData.accessToken);
        request.AddParameter("template_id", templateNum);

        if (client.Execute(request).IsSuccessful)
        {
            Console.WriteLine("메시지 보내기 성공");
        }
        else
        {
            Console.WriteLine("메시지 보내기 실패");
        }
    }

    /// <summary>
    /// 커스텀 메시지 보내기
    /// </summary>
    /// <param name="sendMessageObject">템플릿 JObject 값</param>
    public void KakaoDefaultSendMessage(JObject sendMessageObject)
    {
        var client = new RestClient(KakaoApiEndPoint.KakaoHostApiUrl);

        var request = new RestRequest(KakaoApiEndPoint.KakaoDefaultMessageUrl, Method.POST);
        request.AddHeader("Authorization", "bearer " + KakaoData.accessToken);
        request.AddParameter("template_object", sendMessageObject);

        if (client.Execute(request).IsSuccessful)
        {
            Console.WriteLine("메시지 보내기 성공");
        }
        else
        {
            Console.WriteLine("메시지 보내기 실패");
        }
    }

    public void KakaoUserData()
    {
        var client = new RestClient(KakaoApiEndPoint.KakaoHostApiUrl);

        var request = new RestRequest(KakaoApiEndPoint.KakaoUserDataUrl, Method.GET);
        request.AddHeader("Authorization", "bearer " + KakaoData.accessToken);

        var restResponse = client.Execute(request);
        var json = JObject.Parse(restResponse.Content);

        // 프로필 사진이 없을 경우 예외 처리
        if (json["properties"]["profile_image"] != null)
        {
            string UserImgUrl = json["properties"]["profile_image"].ToString();
            KakaoData.UserImg = WebImageView(UserImgUrl);
        }

        KakaoData.UserNickName = json["properties"]["nickname"].ToString();

        Console.WriteLine(json);
    }

    // 웹 이미지 다운로드
    private static Bitmap WebImageView(string url)
    {
        try
        {
            using (WebClient Downloader = new WebClient())
            using (Stream ImageStream = Downloader.OpenRead(url))
            {
                Bitmap DownloadImage = Bitmap.FromStream(ImageStream) as Bitmap;
                Console.WriteLine("이미지 다운 성공");
                return DownloadImage;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("이미지 다운 실패");
            return null;
        }
    }
}
