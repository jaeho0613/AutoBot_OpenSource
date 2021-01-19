using System.Diagnostics;

class GlobalClientData
{
    public const string CLIENT_NAME = "LeagueClientUx";
    public const string GAME_CLIENT_NAME = "League of Legends";

    // 프로세스 위치 값
    public struct Rect
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }
    }
    public static Rect clientRect;

    // 메인 프로세스
    public static Process clientProcess = null;

    // 게임 프로세스
    public static Process gameClientProcess = null;

    public static string LeaguePath { get; set; } // 롤 클라이언트 실행 경로
    public static string ToKen { get; set; } // 롤 클라이언트 토큰
    public static ushort Port { get; set; } // 롤 클라이언트 포트
    public static string ApiUrl { get; set; } // 롤 클라이언트 ApiUrl

}
