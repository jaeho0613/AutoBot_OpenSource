class GlobalApiEndPoint
{
    #region KakaoAPI
    // API KEY
    private const string KAKAO_KEY_REST_API = ""; // My API KEY
    private const string KAKAO_KEY_SEND_MATHINGMESSAGE = ""; // Message Key
    private const string KAKAO_KEY_SEND_GAMESTARTMESSAGE = ""; // Message Key
    private const string KAKAO_KEY_SEND_TESTMESSAGE = ""; // Message Key
    private const string KAKAO_KEY_SEND_PICKCHAMPION = ""; // Message Key

    // Redirect Url
    private const string KAKAO_URL_REDIRECT = "https://jaeho0613.tistory.com/oauth";

    // Token Url
    public const string KAKAO_URL_USERTOKEN = "https://kauth.kakao.com/oauth/authorize?client_id=" + KAKAO_KEY_REST_API + "&redirect_uri=" + KAKAO_URL_REDIRECT + "&response_type=code";
    public const string KAKAO_URL_ACCESSTOKEN = "https://kauth.kakao.com/oauth/token?grant_type=authorization_code&client_id=" + KAKAO_KEY_REST_API + "&redirect_uri=" + KAKAO_URL_REDIRECT + "&code=";

    // SendMessage Url
    public const string KAKAO_URL_SEND_MATCHINGMESSAGE = "https://kapi.kakao.com/v2/api/talk/memo/send?template_id=" + KAKAO_KEY_SEND_MATHINGMESSAGE;
    public const string KAKAO_URL_SEND_GAMESTARTMESSAGE = "https://kapi.kakao.com/v2/api/talk/memo/send?template_id=" + KAKAO_KEY_SEND_GAMESTARTMESSAGE;
    public const string KAKAO_URL_SEND_TESTMESSAGE = "https://kapi.kakao.com/v2/api/talk/memo/send?template_id=" + KAKAO_KEY_SEND_TESTMESSAGE;
    public const string KAKAO_URL_SEND_PICKCHAMPION = "https://kapi.kakao.com/v2/api/talk/memo/send?template_id=" + KAKAO_KEY_SEND_PICKCHAMPION;
    public const string KAKAO_URL_SEND_PICKTURNMESSAGE = "https://kapi.kakao.com/v2/api/talk/memo/default/send";

    // Unlink Url
    public const string KAKAO_URL_UNLINK = "https://kapi.kakao.com/v1/user/unlink";

    // User Data
    public const string KAKAO_URL_USERDATA = "https://kapi.kakao.com/v2/user/me";
    #endregion KakaoAPI

    #region RiotAPI

    // 라이엇 버전
    public const string RIOT_VERSION_ROOT = "https://ddragon.leagueoflegends.com/api/versions.json";

    // 룬 페이지 관련
    private const string RUNEPAGE_ENDPOINT_ROOT = "/lol-perks/v1/";
    public const string RUNE_PAGE_CURRENT = RUNEPAGE_ENDPOINT_ROOT + "currentpage";
    public const string RUNE_PAGE_PAGES = RUNEPAGE_ENDPOINT_ROOT + "pages";

    // 소환사 데이터
    private const string SUMMONER_ENDPOINT_ROOT = "/lol-summoner/v1/";
    public const string SUMMONER_CURRENT_DATA = SUMMONER_ENDPOINT_ROOT + "current-summoner";
    public const string SUMMONER_SUMMONERID_DATA = SUMMONER_ENDPOINT_ROOT + "summoners/";

    // 게임 상태
    private const string LOBBY_TYPE_ENDPOINT_ROOT = "/lol-gameflow/v1/";
    public const string LOBBY_MATCHMAKING_STATE = LOBBY_TYPE_ENDPOINT_ROOT + "gameflow-phase";

    // 게임 수락, 거절
    private const string MATCHMAKING_ENDPOINT_ROOT = "/lol-matchmaking/v1/";
    public const string MATCHMAKING_CLICK = MATCHMAKING_ENDPOINT_ROOT + "ready-check/accept";
    public const string MATCHMAKING_DECLINE = MATCHMAKING_ENDPOINT_ROOT + "ready-check/decline";

    // 게임 매칭 타입
    private const string MATCHMAKING_TYPE_ENDPOINT_ROOT = "/lol-lobby-team-builder/v1/";
    public const string MATCHMAKING_TYPE = MATCHMAKING_TYPE_ENDPOINT_ROOT + "matchmaking";

    // 챔피언 선택
    private const string CHAMPSELECT_ENDPOINT_ROOT = "/lol-champ-select/v1/";
    public const string CHAMPSELECT_CURRENT_DATA = CHAMPSELECT_ENDPOINT_ROOT + "current-champion";
    public const string CHAMPSELECT_MATCH_DATA = CHAMPSELECT_ENDPOINT_ROOT + "session";

    // 클라이언트
    private const string CLIENT_ENDPOINT_ROOT = "/riotclient/";
    public const string CLIENT_UXSHOW = CLIENT_ENDPOINT_ROOT + "ux-show";

    #endregion RiotAPI
}
