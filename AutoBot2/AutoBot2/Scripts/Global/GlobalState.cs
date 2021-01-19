/// <summary>
/// 로그인 상태, 오토 클릭 상태 클레스
/// </summary>
public class GlobalState
{
    // Login Check
    public static bool isLogin;

    // Option
    // - 매칭 수락 딜레이
    public static bool isAcceptDelay;

    // - 챔피언 선택 시간
    public static bool isPickTurn;

    // - 챔피언 자동 룬 완성
    public static bool isAutoRune;

    // - 멀티 서치
    public static bool isMultiSearch;

    // 현재 프로젝트 버전
    public static string Version = "2.3";
}
