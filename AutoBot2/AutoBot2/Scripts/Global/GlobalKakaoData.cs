using System.Drawing;
/// <summary>
/// 카카오톡 토큰 클레스
/// </summary>
public class GlobalKakaoData
{
    // ToKen
    public static string userToken { get; set; }
    public static string accessToken { get; set; }
    public static string header { get; set; }

    // User NickName
    public static string UserNickName { get; set; }
    // User Img
    public static Bitmap UserImg { get; set; }
}