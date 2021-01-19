using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using agi = HtmlAgilityPack;

namespace AutoBot2.Scripts.Init
{
    class InitManager
    {
        public InitManager()
        {
        }
        
        /// <summary>
        /// 메인 클라이언트 초기화
        /// </summary>
        public bool SetProcessInit()
        {
            try
            {
                GlobalClientData.clientProcess = null;

                Process[] processes = Process.GetProcessesByName(GlobalClientData.CLIENT_NAME);
                //Console.WriteLine("프로세스 배열 : " + processes.Length);
                if (processes.Length > 0)
                {
                    GlobalClientData.clientProcess = processes[0];
                    return true;
                }
                else
                {
                    return false;
                }

                //Console.WriteLine(GlobalClientData.clientProcess.ProcessName);
                //Console.WriteLine(GlobalClientData.clientProcess.MainWindowHandle.GetType());
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 가져온 프로세스(롤 클라이언트)의 lockfile 가져오기
        /// </summary>
        public bool SetClientPathInit()
        {
            try
            {
                GlobalClientData.LeaguePath = Path.GetDirectoryName(GlobalClientData.clientProcess.MainModule.FileName);
                var lockFilePath = Path.Combine(GlobalClientData.LeaguePath, "lockfile");

                using (var fileStream = new FileStream(lockFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var reader = new StreamReader(fileStream))
                {
                    var text = reader.ReadToEnd();
                    string[] items = text.Split(':');
                    GlobalClientData.ToKen = items[3];
                    GlobalClientData.Port = ushort.Parse(items[2]);
                    GlobalClientData.ApiUrl = "https://127.0.0.1:" + GlobalClientData.Port.ToString() + "/";

                    //Console.WriteLine($"Token : {GlobalClientData.ToKen}");
                    //Console.WriteLine($"Port : {GlobalClientData.Port}");
                    //Console.WriteLine($"ApiUri : {GlobalClientData.ApiUrl}");

                    return true;
                }
            }
            catch
            {
                Console.WriteLine("롤 클라이언트 접속하는중...");
                return false;
            }
        }

        /// </summary>
        /// 초기 챔피언 json 초기화
        /// </summary>
        public bool SetChampionJsonCreateInit(string path)
        {
            try
            {
                JObject championID = new JObject();

                string version = SetRiotVerionCheckInit();

                WebRequest request = WebRequest.Create("http://ddragon.leagueoflegends.com/cdn/" + version + "/data/en_US/champion.json");
                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();

                string sResult = new StreamReader(stream).ReadToEnd();
                var jResult = JObject.Parse(sResult);
                var jdata = jResult["data"];

                foreach (var j in jdata)
                {
                    foreach (var a in j)
                    {
                        championID.Add(a["key"].ToString(), a["name"].ToString());
                    }
                }

                ChampionData.ChampionJsonData = championID;

                response.Dispose();
                stream.Close();

                return true;
            }
            catch
            {
                MessageBox.Show("챔피언 목록 초기화에 실패했습니다..!");
                Application.Exit();
                return false;
            }
        }

        /// </summary>
        /// 초기 WebBrowser Version 초기화
        /// </summary>
        public bool SetIEVersionRegistryInit(string appName, int ieval)
        {
            RegistryKey registryKey = null;
            try
            {
                registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);

                if (registryKey == null)
                {
                    MessageBox.Show("웹 브라우저 버전 초기화에 실패했습니다..!");
                    Application.Exit();
                    return false;
                }

                string FindAppkey = Convert.ToString(registryKey.GetValue(appName));

                if (FindAppkey == ieval.ToString())
                {
                    registryKey.Close();
                    return true;
                }

                registryKey.SetValue(appName, unchecked((int)ieval), RegistryValueKind.DWord);

                FindAppkey = Convert.ToString(registryKey.GetValue(appName));

                if (FindAppkey == ieval.ToString())
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("웹 브라우저 버전 초기화에 실패했습니다..!");
                    Application.Exit();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("웹 브라우저 버전 초기화에 실패했습니다..!");
                Application.Exit();
                return false;
            }
            finally
            {
                // 키 메모리 해제
                if (registryKey != null)
                {
                    registryKey.Close();
                }
            }
        }

        /// </summary>
        /// 프로젝트 버전 체크
        /// </summary>
        public bool SetProjectVersionCheck()
        {
            try
            {
                agi.HtmlDocument versionPageDocumnet = new agi.HtmlDocument();

                using (WebClient versionClient = new WebClient())
                {
                    versionClient.Encoding = Encoding.UTF8;
                    var versionString = versionClient.DownloadString("https://jaeho0613.tistory.com/162");
                    versionPageDocumnet.LoadHtml(versionString);

                    var fileblock = versionPageDocumnet.DocumentNode.SelectSingleNode("//figure[@class='fileblock']"); // SingleNode (최상위 1개만)

                    string fileData = fileblock.InnerText.ToString(); // 파일 정보
                                                                      //Console.WriteLine("0------------");
                                                                      //Console.WriteLine(fileblock.InnerHtml);
                                                                      //Console.WriteLine(fileData);
                                                                      //Console.WriteLine("0------------");

                    string[] temp = fileData.Split('_');
                    //Console.WriteLine(a[2].Substring(0, a[2].IndexOf(".zip")));

                    string checkVersion = temp[2].Substring(0, temp[2].IndexOf(".zip"));
                    //Console.WriteLine("1------------");
                    //Console.WriteLine(checkVersion);
                    //Console.WriteLine("1------------");

                    if (GlobalState.Version.Equals(checkVersion))
                    {
                        return true;
                    }
                    else
                    {
                        if (MessageBox.Show($"버전 정보가 다릅니다.\n\n*최신 버전 : {checkVersion}\n*현재 버전 : {GlobalState.Version}\n\n최신 버전을 받으시겠습니까?"
                                            , ""
                                            , MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Console.WriteLine("다운로드");

                            string localpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                            string fileName = "AutoBot_Version_" + checkVersion + ".zip";
                            string downloadUrl = fileblock.SelectSingleNode("//figure[@class='fileblock']//a[@href]").GetAttributeValue("href", string.Empty);

                            //Console.WriteLine("바탕 화면 경로 : " + localpath);
                            //Console.WriteLine("파일 이름 : " + fileName);
                            //Console.WriteLine("다운 로드 경로 : " + downloadUrl);

                            WebClient myWebClient = new WebClient();
                            myWebClient.DownloadFileAsync(new Uri(downloadUrl), localpath + "/" + fileName);
                            return false;
                        }
                        else
                        {
                            //Console.WriteLine("다운로드 안하겠다.");
                            return true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("버전 초기화중 오류가 발생했습니다.");
                Application.Exit();
                return false;
            }

        }

        /// </summary>
        /// 롤 클라이언트 버전 체크
        /// </summary>
        private string SetRiotVerionCheckInit()
        {
            try
            {
                WebRequest request = WebRequest.Create(GlobalApiEndPoint.RIOT_VERSION_ROOT);
                using (WebResponse response = request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                {
                    string sResult = new StreamReader(stream).ReadToEnd();
                    var jResult = JArray.Parse(sResult);

                    string version = jResult[0].ToString();
                    //Console.WriteLine(version);

                    return version;
                }
            }
            catch
            {
                MessageBox.Show("클라이언트 버전 체크에 실패했습니다...!");
                Application.Exit();
                return null;
            }
        }
    }
}
