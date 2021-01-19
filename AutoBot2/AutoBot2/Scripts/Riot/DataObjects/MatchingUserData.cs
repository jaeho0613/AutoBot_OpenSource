using System.Collections.Generic;

public class MatchingUserData
{
    public MatchingUserData()
    {
    }

    // 소환사 Id, 소환사 닉네임
    public Dictionary<int, string> userSummonerDictionary = new Dictionary<int, string>();

    // 소환사 라인
    public string[] userSelectLines;

    // 매칭 타입
    public string queueType = string.Empty;

    // 매칭 팀 종류
    public string myTeam = string.Empty;

    // 매칭 픽 
    public int myPickCount = 0;

    // 미칭 픽 (밴픽 순서 포함)
    public int CelId = 0;

    // 매칭 선택 챔피언
    public string currentChampion = string.Empty;
}
