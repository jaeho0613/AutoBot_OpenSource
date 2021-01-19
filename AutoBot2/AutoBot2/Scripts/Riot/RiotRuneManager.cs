using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using agi = HtmlAgilityPack;

namespace AutoBot2.Scripts.Riot
{
    class RiotRuneManager
    {
        WebClient opggPageClient;
        agi.HtmlDocument championHtml;

        string mainHtmlNode = "//tbody[@class='tabItem ChampionKeystoneRune-1']//div[@class='perk-page__row']";
        string subHtmlNode = "//tbody[@class='tabItem ChampionKeystoneRune-1']//div[@class='fragment']";
        string opggPageString;
        JArray perkArray = new JArray();

        public List<string> runeStyleNum = new List<string>();
        public string currentRune = string.Empty;

        public RiotRuneManager()
        {
            opggPageClient = new WebClient();
            opggPageClient.Encoding = Encoding.UTF8;

            championHtml = new agi.HtmlDocument();
        }

        /// <summary>
        /// OP.GG 크롤링하여 JObject 리턴
        /// </summary>
        /// <param name="URL">op.gg url</param>
        /// <returns></returns>
        public JObject GetRuneDataSetting(string URL)
        {
            ListReset();

            opggPageString = opggPageClient.DownloadString(URL);
            championHtml.LoadHtml(opggPageString);

            //Console.WriteLine(opggPageString);

            if (MainRuneSetting() && SubRuneSetting())
            {
                JObject perk = new JObject();

                perk.Add("primaryStyleId", runeStyleNum[0]);
                perk.Add("subStyleId", runeStyleNum[1]);
                perk.Add("selectedPerkIds", perkArray);

                return perk;
            }
            else
            {
                return null;
            }

        }

        private void ListReset()
        {
            runeStyleNum.Clear();
            perkArray.Clear();
        }

        private bool MainRuneSetting()
        {
            try
            {
                var mainRune = championHtml.DocumentNode.SelectNodes(mainHtmlNode);

                for (int i = 0; i < mainRune.Count() / 2; i++)
                {
                    string damme = mainRune[i].InnerHtml.ToString();

                    if (damme.Contains("perk-page__item perk-page__item--mark"))
                    {
                        string node1 = damme.Substring(damme.IndexOf(".png") - 4, 4);
                        runeStyleNum.Add(node1);
                        //Console.WriteLine("-------------------------");
                        //Console.WriteLine($"{i}번째 룬 페이지 번호");
                        //Console.WriteLine(node1);
                        //Console.WriteLine("-------------------------");
                    }
                    else if (damme.Contains("perk-page__item--active"))
                    {
                        var node2 = damme.Substring(damme.IndexOf("perk-page__item--active"));
                        node2 = node2.Substring(node2.IndexOf(".png") - 4, 4);
                        perkArray.Add(node2);
                        //Console.WriteLine("-------------------------");
                        //Console.WriteLine($"{i}번째 메인 룬 번호");
                        //Console.WriteLine(node2);
                        //mainRuneNum.Add(node2);
                        //Console.WriteLine("-------------------------");

                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool SubRuneSetting()
        {
            try
            {
                var subRune = championHtml.DocumentNode.SelectNodes(subHtmlNode);

                for (int i = 0; i < subRune.Count() / 2; i++)
                {
                    var damme = subRune[i].InnerHtml.ToString();

                    if (damme.Contains("active"))
                    {
                        damme = damme.Substring(damme.IndexOf(".png") - 4, 4);
                        perkArray.Add(damme);
                        //Console.WriteLine(damme);
                        //subRuneNum.Add(damme);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
