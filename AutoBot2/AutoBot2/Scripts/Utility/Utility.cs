using System;
using System.Drawing;
using System.IO;
using System.Net;

class Utility
{
    /// <summary>
    /// 웹 이미지 다운
    /// </summary>
    /// <param name="url">다운 받을 URL</param>
    /// <returns></returns>
    public static Bitmap WebImageView(string url)
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

    ////지연 함수... 
    //public static void DelaySystem(int MS)
    //{
    //    /* 함수명 : DelaySystem * 1000ms = 1초 
    //     * * 전달인자 : 얼마나 지연시킬것인가에 대한 변수 * 
    //    */
    //    DateTime dtAfter = DateTime.Now;
    //    TimeSpan dtDuration = new TimeSpan(0, 0, 0, 0, MS);
    //    DateTime dtThis = dtAfter.Add(dtDuration);
    //    while (dtThis >= dtAfter)
    //    {
    //        //DoEvent () 를 사용 해서 지연 시간 동안
    //        //버튼 클릭 이벤트 및 다른 윈도우 이벤트를 받을 수 있게끔 하는 역할 
    //        //없으면 지연 동안 다른 이벤트를 받지 못함... 
    //        System.Windows.Forms.Application.DoEvents();
    //        //현재 시간 얻어 오기... 
    //        dtAfter = DateTime.Now;
    //    }
    //}
}
