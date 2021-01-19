using AutoBot2.Scripts.Init;
using AutoBot2.Scripts.KakaoTalk;
using AutoBot2.Scripts.Riot;
using AutoBot2.Scripts.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoBot2
{
    public partial class MainForm : Form
    {
        KakaoTalkManager kakaoTalkManager; // 카카오톡 관련 매니저
        RiotClientManager riotClientManager; // 라이엇 클라이언트 관련 매니저
        UIManager uiManager; // UI 관련 매니저
        MatchingUserData matchingUserData; // 유저 데이터
        KakaoLoginPageForm kakaoLoginPageForm; // 카카오톡 로그인 페이지
        StatusDisplay status; // 알람 Form
        RiotRuneManager riotRuneManager; // 룬 설정 매니저
        InitManager initManager;

        delegate void EventDelegate(); // 크로스 쓰레드 방지
        EventDelegate endGameDelegate; // 클라이언트 종료 이벤트

        Point mousePoint; // 마우스 클릭 폼 움직임 변수
        int mainWidth; // Main Form 가로 길이

        bool isAccept; // 수락 여부
        bool isSendMessage; // 메세지 보냈는지
        bool isPickMessage; // 픽 차례 메시지
        bool isAutoClick; // 오토 클릭 체크 여부
        bool isAutoRune; // 오토 룬 설정
        bool isMinimize; // 최소화 상태
        bool isMultiSearch; // 멀티 서치 설정

        #region ** 기본 초기화 **

        public MainForm()
        {
            InitializeComponent();

            // 생성
            kakaoTalkManager = new KakaoTalkManager();
            riotClientManager = new RiotClientManager();
            matchingUserData = new MatchingUserData();
            riotRuneManager = new RiotRuneManager();
            uiManager = new UIManager();
            initManager = new InitManager();

            // 프로그램 너비 길이
            mainWidth = PanelMainMenu.Width; 

            endGameDelegate = new EventDelegate(GameClientExitEvent); // 크로스 쓰레드 방지 이벤트

            // 프로그램 마우스 이동 이벤트
            this.PanelStateLayer.MouseDown += new MouseEventHandler(this.PanelStateLayer_MouseDown);
            this.PanelStateLayer.MouseMove += new MouseEventHandler(this.PanelStateLayer_MouseMove);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // SubMenu 비활성화
            PanelKakaoSubMenu.Visible = false;
            PanelOptionSubMenu.Visible = false;

            // 타이머 설정
            TimerAutoClick.Interval = 500;
            TimerAutoClick.Stop();

            TimerFormRect.Interval = 50;
            TimerFormRect.Stop();

            TimerClientInit.Interval = 500;
            TimerClientInit.Start();

            // 프로세스(롤 클라이언트) 종료 이벤트
            riotClientManager.LeagueClosed += () =>
            {
                // 크로스 쓰레드 방지
                this.Invoke((MethodInvoker)delegate
                {
                    //Console.WriteLine("클라이언트 종료");

                    // 타이머 설정
                    TimerClientInit.Start();
                    TimerFormRect.Stop();

                    // 프로그램 옵션 변수 초기화
                    OptionDataInit();

                    // 클라이언트 변수 초기화
                    GlobalClientData.clientProcess = null;
                    riotClientManager.isClientConnect = false;
                    riotClientManager.currentSummonerName = null;

                    // 마우스 폼 이동 이벤트
                    this.PanelStateLayer.MouseDown += new MouseEventHandler(this.PanelStateLayer_MouseDown);
                    this.PanelStateLayer.MouseMove += new MouseEventHandler(this.PanelStateLayer_MouseMove);

                    // UI 변경
                    LabelClientConnect.Text = "클라이언트 연결 끊김";
                    LabelClientConnect.ForeColor = Color.DarkRed;
                });
            };

            // 첫 실행시 오토클릭 활성화
            BtnAutoClick_Click(sender, e);
        }

        #endregion ** 기본 초기화 **

        #region ** Timer Event **

        // 클라이언트 초기화 타이머
        private async void TimerClientInit_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine("클라이언트 찾는중...");

            // 클라이언트 찾는 로직
            try
            {
                // 클라이언트가 연결되지 않으면 클라이언트 연결
                if (GlobalClientData.clientProcess == null)
                {
                    if (initManager.SetProcessInit())
                    {
                        //Console.WriteLine("클라이언트 찾는중..");

                        // 롤 클라이언트 핸들이 0이면 초기화
                        if (GlobalClientData.clientProcess.MainWindowHandle == IntPtr.Zero)
                        {
                            //Console.WriteLine("프로세스 요청 대기...");
                            GlobalClientData.clientProcess = null;
                            return;
                        }

                        // 롤 클라이언트 연결 로직
                        if (initManager.SetClientPathInit())
                        {
                            if (riotClientManager.Connect())
                            {
                                // 클라이언트 UX활성화
                                await riotClientManager.UsingApiEventHttpMessage(HttpMethod.Post, GlobalApiEndPoint.CLIENT_UXSHOW);

                                // UI 변경
                                LabelClientConnect.Text = "클라이언트 연결됨";
                                LabelClientConnect.ForeColor = Color.DarkGreen;

                                // 폼 마우스 이동 이벤트
                                this.PanelStateLayer.MouseDown -= new MouseEventHandler(this.PanelStateLayer_MouseDown);
                                this.PanelStateLayer.MouseMove -= new MouseEventHandler(this.PanelStateLayer_MouseMove);

                                // MainForm Size 조절
                                uiManager.InitClientPtr();
                                uiManager.InitClientRect();

                                // 클라이언트 연결 여부
                                riotClientManager.isClientConnect = true;

                                // 프로그램 UI 사이즈 조절
                                Size = new Size(mainWidth, uiManager.GetClientHeight());
                                PanelStateLayer.Height = Convert.ToInt32(this.Size.Height * 0.11f);

                                // 타이머 실행
                                TimerFormRect.Start();
                                TimerClientInit.Stop();
                            }
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("클라이언트 찾기 실패");
            }
        }

        // 자동 클릭 타이머
        private async void TimerAutoClick_Tick(object sender, EventArgs e)
        {
            // 클라이언트가 연결 되지 않았으면 리턴
            if (riotClientManager.isClientConnect != true)
            {
                //Console.WriteLine("AutoClick : 클라이언트 연결 끊김");
                return;
            }

            // AutoClick 로직
            try
            {
                //Console.WriteLine("AutoClick");

                // 현제 매칭 상태 찾기
                using (var jResult = await riotClientManager.UsingApiEventHttpMessage(HttpMethod.Get, GlobalApiEndPoint.LOBBY_MATCHMAKING_STATE))
                {
                    string sResult = JsonConvert.DeserializeObject(await jResult.Content.ReadAsStringAsync()).ToString();
                    //Console.WriteLine($"게임 상태 : {sResult}");
                    switch (sResult)
                    {
                        case "Reconnect":
                        case "None":
                        case "Lobby":
                        case "Matchmaking":
                            // 매칭 데이터 변수 초기화
                            if (matchingUserData.userSummonerDictionary.Count > 0)
                            {
                                //Console.WriteLine("Event : userSummonerDictionary 초기화!");
                                matchingUserData.userSummonerDictionary.Clear();
                            }
                            // 각 옵션 bool 변수 초기화
                            if (isAccept || isSendMessage || isPickMessage || isAutoRune || isMultiSearch)
                            {
                                //Console.WriteLine("Event : 상태 초기화!");
                                OptionDataInit();
                            }
                            break;
                        case "ReadyCheck":
                            // 수락 상태 전이면~
                            if (!isAccept)
                            {
                                //Console.WriteLine("Event : 수락 버튼 누르기!");
                                // 매칭 딜레이 옵션
                                if (GlobalState.isAcceptDelay)
                                {
                                    TimerAutoClick.Stop();
                                    Thread.Sleep(9900);
                                    TimerAutoClick.Start();
                                }

                                // 수락 버튼 클릭
                                await riotClientManager.UsingApiEventHttpMessage(HttpMethod.Post, GlobalApiEndPoint.MATCHMAKING_CLICK);

                                // 수락 체크
                                isAccept = true;
                            }
                            break;
                        case "ChampSelect":

                            // 로그인 상태 && 매칭 정보 메시지를 보내지 않았다면
                            if (GlobalState.isLogin && !isSendMessage)
                            {
                                //Console.WriteLine("Event : 매칭 정보 메시지 보내기!");

                                // 매칭 완료 메시지 보내기
                                kakaoTalkManager.UsingApiEvent(KakaoTalkManager.HttpMethod.Post, GlobalApiEndPoint.KAKAO_URL_SEND_MATCHINGMESSAGE);

                                // 딕셔너리 초기화가 됐을 때
                                if (matchingUserData.userSummonerDictionary.Count == 0)
                                {
                                    await MatchMakingDataSetting();
                                    var messageJson = kakaoTalkManager.SendMessageJsonData(); // 기본 메시지 Json 얻기

                                    // 보낼 메시지 내용 입력
                                    messageJson.Add("text", $"매칭 타입 : {matchingUserData.queueType}\n" +
                                                            $"진영 : {matchingUserData.myTeam}\n" +
                                                            $"라인 : {matchingUserData.userSelectLines[matchingUserData.myPickCount]}\n" +
                                                            $"픽 순서 : {matchingUserData.myPickCount + 1}픽");

                                    // 매칭 데이터 메시지 보내기
                                    kakaoTalkManager.UsingApiEvent(KakaoTalkManager.HttpMethod.Post, GlobalApiEndPoint.KAKAO_URL_SEND_PICKTURNMESSAGE, messageJson);
                                }

                                isSendMessage = true;
                            }

                            // 멀티 서치
                            else if (GlobalState.isMultiSearch && !isMultiSearch)
                            {
                                //Console.WriteLine("Event : 멀티 서치!");

                                // 멀티 서치 체크
                                isMultiSearch = true;

                                // op.gg 멀티 서치 url
                                string localPath = "https://www.op.gg/multi/query=";

                                // 매칭 데이터가 null 이면~
                                if (matchingUserData.userSummonerDictionary.Count == 0)
                                {
                                    //Console.WriteLine("Event : 멀티 서치 하기전 딕셔너리 초기화!");
                                    await MatchMakingDataSetting();
                                }

                                // 매칭 데이터의 소환사 아이다 값만 추출
                                foreach (var item in matchingUserData.userSummonerDictionary.Values)
                                {
                                    //Console.WriteLine(item);
                                    localPath += item + "%2C";
                                }

                                // 멀티 서치 홈페이지 실행
                                Process.Start(localPath);
                            }

                            // 픽 순서 체크
                            else if (GlobalState.isLogin && GlobalState.isPickTurn && !isPickMessage)
                            {
                                //Console.WriteLine("Event : 픽 시간 보내기!");

                                CurrentPickCheck();
                            }

                            // 룬 설정
                            else if (GlobalState.isAutoRune && !isAutoRune)
                            {
                                //Console.WriteLine("Event : 오토 룬 설정");

                                // 현재 픽한 챔피언 요청 (챔피언 별 Int값으로 return)
                                var message = await riotClientManager.UsingApiEventHttpMessage(HttpMethod.Get, GlobalApiEndPoint.CHAMPSELECT_CURRENT_DATA);
                                var championNum = Convert.ToInt32(await message.Content.ReadAsStringAsync());

                                // 0 = 봇, 을 제외한
                                if (championNum > 0)
                                {
                                    //Console.WriteLine("Event : 오토 룬 설정중....!");

                                    isAutoRune = true;

                                    // 챔피언 Json파일에서 현재 챔피언 추출
                                    var champion = ChampionData.ChampionJsonData[championNum.ToString()];
                                    matchingUserData.currentChampion = champion.ToString();

                                    // 크롤링할 페이지 URL
                                    string opggUrl = "https://www.op.gg/champion/" + champion + "/statistics/";

                                    // 크롤링 데이터 얻기
                                    var json = riotRuneManager.GetRuneDataSetting(opggUrl);

                                    // 데이터를 얻었다면~
                                    if (json != null)
                                    {
                                        // 룬 데이터 설정
                                        json.Add("name", champion);

                                        // 현재 접속된 소환사 룬 페이지 데이터 얻기 (룬 페이지가 없거나, 룬 페이지가 꽉 찼을 때 예외 처리)
                                        var currentRuneMessage = await riotClientManager.UsingApiEventHttpMessage(HttpMethod.Get, GlobalApiEndPoint.RUNE_PAGE_PAGES);
                                        var currentRune = JArray.Parse(await currentRuneMessage.Content.ReadAsStringAsync());
                                        var currentId = currentRune[0]["id"].ToString();

                                        // 룬 페이지 지우기 (54~51 롤 기본 룬 페이지)
                                        if (Convert.ToInt32(currentId) > 54)
                                        {
                                            await riotClientManager.UsingApiEventHttpMessage(HttpMethod.Delete, GlobalApiEndPoint.RUNE_PAGE_PAGES + "/" + currentId);
                                        }

                                        // 1초 중지
                                        Thread.Sleep(1000);

                                        // 룬 페이지 업데이트
                                        await riotClientManager.UsingApiEventHttpMessage(HttpMethod.Post, GlobalApiEndPoint.RUNE_PAGE_PAGES, json);
                                    }
                                    else
                                    {
                                        status = new StatusDisplay($"{champion}룬 설정중 오류가 발생했습니다...!", StatusDisplay.enumType.Error);
                                    }
                                }
                            }

                            // 챔피언 스왑 판별
                            else if (isAutoRune)
                            {
                                //Console.WriteLine("Event : 스왑 판별");

                                // 현재 챔피언 데이터 얻기
                                var message1 = await riotClientManager.UsingApiEventHttpMessage(HttpMethod.Get, GlobalApiEndPoint.CHAMPSELECT_CURRENT_DATA);
                                var championNum1 = Convert.ToInt32(await message1.Content.ReadAsStringAsync());
                                var champion = ChampionData.ChampionJsonData[championNum1.ToString()];

                                // 현재 챔피언이 이전과 동일한지 판별
                                if (!champion.ToString().Equals(matchingUserData.currentChampion))
                                {
                                    isAutoRune = false;
                                }
                            }
                            break;
                        case "InProgress":
                            Console.WriteLine("Event : 게임 시작");
                            GameClientStartEvent();
                            break;
                    }
                }
            }
            catch
            {

            }
        }

        // 프로그램 위치 타이머
        private void TimerFormRect_Tick(object sender, EventArgs e)
        {
            if (uiManager.InitClientRect())
            {
                this.Location = uiManager.GetClientPoint(mainWidth);
            }
        }

        #endregion ** Timer Event **

        #region ** 버튼 클릭 이벤트 **

        #region ** AutoClick Event **
        // 타이머 시작
        private void BtnAutoClick_Click(object sender, EventArgs e)
        {
            if (TimerAutoClick.Enabled.Equals(true))
            {
                //Console.WriteLine("Timer STOP");
                isAutoClick = false;
                TimerAutoClick.Stop();
                BtnAutoClick.Height -= 20;
                BtnAutoClick.BackColor = Color.Transparent;
                BtnAutoClick.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            }
            else
            {
                //Console.WriteLine("Timer START");
                isAutoClick = true;
                TimerAutoClick.Start();
                BtnAutoClick.Height += 20;
                BtnAutoClick.BackColor = Color.DarkGreen;
                BtnAutoClick.IconChar = FontAwesome.Sharp.IconChar.Eye;
            }
        }

        #endregion ** AutoClick Event **

        #region ** KakaoBtn Event **

        private void BtnKakao_Click(object sender, EventArgs e)
        {
            uiManager.ShowSubMenu(PanelKakaoSubMenu);
        }

        private void BtnKakaoLogin_Click(object sender, EventArgs e)
        {
            if (!GlobalState.isLogin)
            {
                kakaoLoginPageForm = new KakaoLoginPageForm();
                kakaoLoginPageForm.LoginEvent += new KakaoLoginPageForm.LoginDelegate(KakaoUserDataSetting);
                kakaoLoginPageForm.ShowDialog();
            }
            else
            {
                status = new StatusDisplay("중복 로그인은 할 수 없습니다.", StatusDisplay.enumType.Warning);
            }
        }

        private void BtnKakaoLogout_Click(object sender, EventArgs e)
        {
            if (GlobalState.isLogin)
            {
                if (kakaoTalkManager.UsingApiEvent(KakaoTalkManager.HttpMethod.Post, GlobalApiEndPoint.KAKAO_URL_UNLINK))
                {
                    PictureUserImg.Image = null;
                    LabelUserName.Text = "unKnown";

                    LabelState.ForeColor = Color.DarkRed;
                    PictureState.ForeColor = Color.DarkRed;

                    LabelState.Text = "로그아웃";
                }
            }
            else
            {
                status = new StatusDisplay("중복 로그아웃은 할 수 없습니다.", StatusDisplay.enumType.Warning);
            }
        }

        private void BtnKakaoSendMessage_Click(object sender, EventArgs e)
        {
            if (GlobalState.isLogin)
            {
                kakaoTalkManager.UsingApiEvent(KakaoTalkManager.HttpMethod.Post, GlobalApiEndPoint.KAKAO_URL_SEND_TESTMESSAGE);
            }
            else
            {
                status = new StatusDisplay("로그인을 해야 사용이 가능합니다.", StatusDisplay.enumType.Warning);
            }
        }

        #endregion ** KakaoBtn Event **

        #region ** OptionBtn Event **

        private void BtnOption_Click(object sender, EventArgs e)
        {
            uiManager.ShowSubMenu(PanelOptionSubMenu);
        }

        private void BtnOptionAcceptDelay_Click(object sender, EventArgs e)
        {
            uiManager.BtnClickEvent(ref GlobalState.isAcceptDelay, BtnOptionAcceptDelay);
        }

        private void BtnOptionPickTurn_Click(object sender, EventArgs e)
        {
            if (GlobalState.isLogin)
            {
                uiManager.BtnClickEvent(ref GlobalState.isPickTurn, BtnOptionPickTurn);
            }
            else
            {
                status = new StatusDisplay("카카오톡 로그인 후 이용 가능 합니다!", StatusDisplay.enumType.Warning);
            }
        }

        private void BtnOptionAutoRune_Click(object sender, EventArgs e)
        {
            uiManager.BtnClickEvent(ref GlobalState.isAutoRune, BtnOptionAutoRune);
        }

        private void BtnOptionMultiSearch_Click(object sender, EventArgs e)
        {
            uiManager.BtnClickEvent(ref GlobalState.isMultiSearch, BtnOptionMultiSearch);
        }

        #endregion ** OptionBtn Event **

        #endregion ** 버튼 클릭 Event **

        #region ** 부가 Event **

        // 픽 순서 로직
        private async void CurrentPickCheck()
        {
            try
            {
                switch (matchingUserData.queueType)
                {
                    case "단일모드":
                    case "칼바람":
                    case "일반":
                    case "커스텀":
                        isPickMessage = true;
                        break;
                    case "솔랭":
                    case "자랭":
                        //Console.WriteLine("솔랭,자랭");
                        var mResult = await riotClientManager.UsingApiEventJobject(HttpMethod.Get, GlobalApiEndPoint.CHAMPSELECT_MATCH_DATA);

                        //Console.WriteLine();
                        //Console.WriteLine("--------------------");
                        //Console.WriteLine("큐 타입 : " + matchingUserData.queueType);
                        //Console.WriteLine("--------------------");
                        //Console.WriteLine("CelId : " + matchingUserData.CelId);
                        //Console.WriteLine("--------------------");
                        //Console.WriteLine(mResult["actions"]);
                        //Console.WriteLine("--------------------");

                        switch (matchingUserData.CelId)
                        {
                            // [2] 1번
                            case 0:
                                kakaoTalkManager.UsingApiEvent(KakaoTalkManager.HttpMethod.Post, GlobalApiEndPoint.KAKAO_URL_SEND_PICKCHAMPION);
                                isPickMessage = true;
                                break;
                            // [3] 2번
                            case 5:
                            case 6:
                                //Console.WriteLine("mResult actions 2" + mResult["actions"][2]["completed"].ToString());
                                if (mResult["actions"][2]["completed"].ToString().Equals("True"))
                                {
                                    kakaoTalkManager.UsingApiEvent(KakaoTalkManager.HttpMethod.Post, GlobalApiEndPoint.KAKAO_URL_SEND_PICKCHAMPION);
                                    isPickMessage = true;
                                }
                                break;
                            // [4] 3번
                            case 1:
                            case 2:
                                //Console.WriteLine("mResult actions 3 0" + mResult["actions"][3][0]["completed"].ToString());
                                //Console.WriteLine("mresult actions 3 1" + mResult["actions"][3][1]["completed"].ToString());
                                if (mResult["actions"][3][0]["completed"].ToString().Equals("True") && mResult["actions"][3][1]["completed"].ToString().Equals("True"))
                                {
                                    kakaoTalkManager.UsingApiEvent(KakaoTalkManager.HttpMethod.Post, GlobalApiEndPoint.KAKAO_URL_SEND_PICKCHAMPION);
                                    isPickMessage = true;
                                }
                                break;
                            // [5] 4번
                            case 7:
                            case 8:
                                //Console.WriteLine("mResult actions 4 0" + mResult["actions"][4][0]["completed"].ToString());
                                //Console.WriteLine("mResult actions 4 1" + mResult["actions"][4][1]["completed"].ToString());
                                if (mResult["actions"][4][0]["completed"].ToString().Equals("True") && mResult["actions"][4][1]["completed"].ToString().Equals("True"))
                                {
                                    kakaoTalkManager.UsingApiEvent(KakaoTalkManager.HttpMethod.Post, GlobalApiEndPoint.KAKAO_URL_SEND_PICKCHAMPION);
                                    isPickMessage = true;
                                }
                                break;
                            // [6] 5번
                            case 3:
                            case 4:
                                //Console.WriteLine("mResult actions 5 0" + mResult["actions"][5][0]["completed"].ToString());
                                //Console.WriteLine("mResult actions 5 1" + mResult["actions"][5][1]["completed"].ToString());
                                if (mResult["actions"][5][0]["completed"].ToString().Equals("True") && mResult["actions"][5][1]["completed"].ToString().Equals("True"))
                                {
                                    kakaoTalkManager.UsingApiEvent(KakaoTalkManager.HttpMethod.Post, GlobalApiEndPoint.KAKAO_URL_SEND_PICKCHAMPION);
                                    isPickMessage = true;
                                }
                                break;
                            // [7] 6번
                            case 9:
                                //Console.WriteLine("mResult actions 6 0" + mResult["actions"][6][0]["completed"].ToString());
                                //Console.WriteLine("mResult actions 6 1" + mResult["actions"][6][1]["completed"].ToString());
                                if (mResult["actions"][6][0]["completed"].ToString().Equals("True") && mResult["actions"][6][1]["completed"].ToString().Equals("True"))
                                {
                                    kakaoTalkManager.UsingApiEvent(KakaoTalkManager.HttpMethod.Post, GlobalApiEndPoint.KAKAO_URL_SEND_PICKCHAMPION);
                                    isPickMessage = true;
                                }
                                break;
                        }
                        break;
                    default:
                        //Console.WriteLine("처리되지 않은 모드");
                        isPickMessage = true;
                        break;
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine("CurrentPickCheck Error : " + e);
            }
        }

        // 매칭 데이터 셋팅
        private async Task MatchMakingDataSetting()
        {
            try
            {
                // 현재 접속 소환사 데이터가 없으면
                if (riotClientManager.currentSummonerName == null)
                {
                    // 소환사 데이터 얻기
                    CurrentSummonerNameSetting();
                }

                // 매칭 상태 데이터 
                var mResult = await riotClientManager.UsingApiEventJobject(HttpMethod.Get, GlobalApiEndPoint.CHAMPSELECT_MATCH_DATA);
                var tResult = await riotClientManager.UsingApiEventJobject(HttpMethod.Get, GlobalApiEndPoint.MATCHMAKING_TYPE);

                int teamCount = mResult["myTeam"].Count(); // 매칭 인원 수

                string[] userSelectLine = new string[teamCount]; // 매칭된 라인
                string queueType = tResult["queueId"].ToString(); // 매칭 타입
                int myPickCount = 0;

                //Console.WriteLine();
                //Console.WriteLine("---------------");
                //Console.WriteLine($"팀 인원 수 : {teamCount}");
                //Console.WriteLine("---------------");
                //Console.WriteLine(mResult.ToString());
                //Console.WriteLine("---------------");
                //Console.WriteLine(tResult.ToString());
                //Console.WriteLine("---------------");
                //Console.WriteLine();

                // 팀 인원 수 만큼 반복 (소환사 id, 소환사 이름, 라인 얻음)
                for (int i = 0; i < teamCount; i++)
                {
                    int summonerId; // 소환사 id
                    string summonerName; // 소환사 이름

                    summonerId = Convert.ToInt32(mResult["myTeam"][i]["summonerId"]); // id값

                    // 소환사 id가 0이면 Bot(컴퓨터) 이므로 그것을 제외함
                    if (summonerId != 0)
                    {
                        // 소환사 정보 찾기
                        var summonerJson = await riotClientManager.UsingApiEventJobject(HttpMethod.Get, GlobalApiEndPoint.SUMMONER_SUMMONERID_DATA + summonerId);

                        // 소환사 이름
                        summonerName = summonerJson["displayName"].ToString();

                        // 만약 접속한 소환사 이름이랑 같으면 몇픽인지 계산
                        if (summonerName.Equals(riotClientManager.currentSummonerName))
                        {
                            myPickCount = i;
                            matchingUserData.CelId = Convert.ToInt32(mResult["myTeam"][i]["cellId"]);
                        }

                        // 소환사 이름 데이터 저장
                        matchingUserData.userSummonerDictionary.Add(summonerId, summonerName);

                        // 각 소환사 라인 (영문 -> 한글)
                        switch (mResult["myTeam"][i]["assignedPosition"].ToString())
                        {
                            case "top":
                                userSelectLine[i] = "탑";
                                break;
                            case "middle":
                                userSelectLine[i] = "미드";
                                break;
                            case "jungle":
                                userSelectLine[i] = "정글";
                                break;
                            case "utility":
                                userSelectLine[i] = "서폿";
                                break;
                            case "bottom":
                                userSelectLine[i] = "원딜";
                                break;
                            default:
                                userSelectLine[i] = "없음";
                                break;
                        }
                    }
                }

                //큐 타입
                switch (queueType)
                {
                    case "420":
                        matchingUserData.queueType = "솔랭";
                        break;
                    case "430":
                        matchingUserData.queueType = "일반";
                        break;
                    case "440":
                        matchingUserData.queueType = "자랭";
                        break;
                    case "450":
                        matchingUserData.queueType = "칼바람";
                        break;
                    case "-1":
                        matchingUserData.queueType = "커스텀";
                        break;
                    case "1020":
                        matchingUserData.queueType = "단일모드";
                        break;
                    default:
                        matchingUserData.queueType = "????";
                        break;
                }

                // 팀 타입
                // - 블루팀 (0 ~ 4)
                if (matchingUserData.CelId < 5)
                {
                    matchingUserData.myTeam = "블루팀(아랫 진영)";
                    matchingUserData.myPickCount = myPickCount;
                }
                // - 레드팀 (5 ~ 9)
                else if (matchingUserData.CelId >= 5)
                {
                    matchingUserData.myTeam = "레드팀(윗 진영)";
                    matchingUserData.myPickCount = myPickCount;
                }

                // 소환사 라인 데이터 저장
                matchingUserData.userSelectLines = userSelectLine;
            }
            catch
            {
                Console.WriteLine("매칭 데이터 오류");
            }
        }

        // 접속 중인 소환사 이름 셋팅 (제귀함수 *수정요망)
        private async void CurrentSummonerNameSetting()
        {
            try
            {
                var summonerJson = await riotClientManager.UsingApiEventJobject(HttpMethod.Get, GlobalApiEndPoint.SUMMONER_CURRENT_DATA);
                riotClientManager.currentSummonerName = summonerJson["displayName"].ToString();

                //Console.WriteLine(riotClientManager.currentSummonerName);
            }
            catch
            {
                //Console.WriteLine("소환사 이름 찾기 실패");
                CurrentSummonerNameSetting();
            }

        }

        // 게임 시작 이벤트
        private void GameClientStartEvent()
        {
            // 게임 클라이언트 찾기
            GlobalClientData.gameClientProcess = Process.GetProcessesByName(GlobalClientData.GAME_CLIENT_NAME)[0];
            GlobalClientData.gameClientProcess.EnableRaisingEvents = true;
            GlobalClientData.gameClientProcess.Exited += GameClientProcess_Exited;

            // 로그인 상태면 게임 시작 메시지 보내기
            if (GlobalState.isLogin)
            {
                kakaoTalkManager.UsingApiEvent(KakaoTalkManager.HttpMethod.Post, GlobalApiEndPoint.KAKAO_URL_SEND_GAMESTARTMESSAGE);
            }

            // AutoClick 중지
            TimerAutoClick.Stop();
        }

        // 게임 클라이언트 종료 이벤트 대리자
        private void GameClientProcess_Exited(object sender, EventArgs e)
        {
            //Console.WriteLine("게임 클라이언트 종료 이벤트");
            this.Invoke(endGameDelegate);
        }

        // 게임 클라이언트 종료 이벤트 실행 로직
        private void GameClientExitEvent()
        {
            // 오토체크 이벤트
            this.AutoClickCheck();

            // 프로세스 메모리 초기화
            GlobalClientData.gameClientProcess = null;
        }

        // AutoClick 활성 여부 체크
        private void AutoClickCheck()
        {
            if (isAutoClick)
            {
                TimerAutoClick.Start();
            }
            else
            {
                TimerAutoClick.Stop();
            }
        }

        // 종료 이벤트
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 개발자 홈페이지
        private void BtnHomePage_Click(object sender, EventArgs e)
        {
            Process.Start("https://jaeho0613.tistory.com/162");
        }

        // 로그인 유저 데이터 세팅
        private void KakaoUserDataSetting()
        {
            PictureUserImg.Image = GlobalKakaoData.UserImg;
            LabelUserName.Text = GlobalKakaoData.UserNickName;

            LabelState.ForeColor = Color.DarkGreen;
            PictureState.ForeColor = Color.DarkGreen;

            LabelState.Text = "로그인";
        }

        // 최소화 버튼
        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            if (!isMinimize)
            {
                isMinimize = true;
                PanelMainMenu.Width = 55;
                mainWidth = 55;
                Height = 30;
                BtnHomePage.Visible = false;
                PictureUserImg.Visible = false;
                LabelClientConnect.Visible = false;
            }
            else
            {
                isMinimize = false;
                PanelMainMenu.Width = 160;
                mainWidth = 160;
                Height = uiManager.GetClientHeight();
                BtnHomePage.Visible = true;
                PictureUserImg.Visible = true;
                LabelClientConnect.Visible = true;
            }
        }

        // 폼 드레그 기능
        private void PanelStateLayer_MouseDown(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("PanelStateLayer_MouseDown");
            mousePoint = new Point(e.X, e.Y);
        }

        // 폼 드레그 기능
        private void PanelStateLayer_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                //Console.WriteLine("PanelStateLayer_MouseMove");
                Location = new Point(Left - (mousePoint.X - e.X), Top - (mousePoint.Y - e.Y));
            }
        }

        // 옵션 체크 변수 초기화 
        private void OptionDataInit()
        {
            //Console.WriteLine("Event : 상태 초기화!");
            isAccept = false;
            isSendMessage = false;
            isPickMessage = false;
            isAutoRune = false;
            isMultiSearch = false;
        }

        #endregion ** 부가 Event **

    }
}