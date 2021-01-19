using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace RIOT_API
{
    public partial class Form1 : Form
    {
        RiotClientManager clientManager;

        public Form1()
        {
            InitializeComponent();

            clientManager = new RiotClientManager();

            this.Btn_Using.Click += new System.EventHandler(this.Btn_Using_Click);
            this.Btn_RunePage.Click += new System.EventHandler(this.Btn_RunePage_Click);
            this.Btn_ClientInit.Click += new System.EventHandler(this.Btn_ClientInit_Click);

            clientManager.LeagueClosed += () =>
            {
                Console.WriteLine("클라이언트 종료");
            };
        }

        // 기본 Http 메시지
        private async void Btn_Using_Click(object sender, EventArgs e)
        {
            // HttpMessage로 받기
            //var message = await clientManager.UsingApiEventHttpMessage(TextBox_Method.Text, TextBox_Url.Text);
            //var sMessage = message.Content.ReadAsStringAsync().Result;
            //TextBox_OutPut.Text = sMessage;

            // JObject로 받기
            var message = await clientManager.UsingApiEventJObject(TextBox_Method.Text, TextBox_Url.Text);
            TextBox_OutPut.Text = message.ToString();
        }

        // 룬페이지 설정
        private async void Btn_RunePage_Click(object sender, EventArgs e)
        {
            // 룬페이지 추가
            var jObject = RunePage();

            var message = await clientManager.UsingApiEventHttpMessage(TextBox_Method.Text, "/lol-perks/v1/pages", jObject);
        }

        // 클라이언트 연결
        private void Btn_ClientInit_Click(object sender, EventArgs e)
        {
            try
            {
                Process[] processes = Process.GetProcessesByName(ClientData.CLIENT_NAME);
                ClientData.clientProcess = processes[0];

                ClientData.LeaguePath = Path.GetDirectoryName(ClientData.clientProcess.MainModule.FileName);
                var lockFilePath = Path.Combine(ClientData.LeaguePath, "lockfile");

                using (var fileStream = new FileStream(lockFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var reader = new StreamReader(fileStream))
                {
                    var text = reader.ReadToEnd();
                    string[] items = text.Split(':');
                    ClientData.ToKen = items[3];
                    ClientData.Port = ushort.Parse(items[2]);
                    ClientData.ApiUrl = "https://127.0.0.1:" + ClientData.Port.ToString() + "/";

                    Console.WriteLine($"Token : {ClientData.ToKen}");
                    Console.WriteLine($"Port : {ClientData.Port}");
                    Console.WriteLine($"ApiUri : {ClientData.ApiUrl}");
                }

                clientManager.Connect();

                TextBox_OutPut.Text = "클라이언트 찾기 완료";

            }
            catch
            {
                TextBox_OutPut.Text = "클라이언트 찾기 실패";
            }
        }

        // 테스트 룬 페이지
        private JObject RunePage()
        {
            JObject jObject = new JObject();
            JArray jArray = new JArray();

            jArray.Add("8214");
            jArray.Add("8226");
            jArray.Add("8210");
            jArray.Add("8237");
            jArray.Add("8345");
            jArray.Add("8347");
            jArray.Add("5008");
            jArray.Add("5008");
            jArray.Add("5002");

            jObject.Add("primaryStyleId", "8200");
            jObject.Add("subStyleId", "8300");
            jObject.Add("selectedPerkIds", jArray);
            jObject.Add("name", "테스트룬");

            TextBox_OutPut.Text = jObject.ToString();

            return jObject;
        }
    }
}
