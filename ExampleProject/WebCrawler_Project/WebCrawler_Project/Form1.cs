using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using hap = HtmlAgilityPack;

namespace WebCrawler_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> title = new List<string>();
            List<string> num = new List<string>();

            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string html = wc.DownloadString("http://ncov.mohw.go.kr/");

            hap.HtmlDocument mydoc = new hap.HtmlDocument();
            mydoc.LoadHtml(html);

            var htmlNode = mydoc.DocumentNode.SelectSingleNode("//ul[@class='liveNum']");

            var numNode = htmlNode.SelectNodes("li");
            foreach (var item in numNode)
            {
                var titleDam = item.SelectSingleNode("strong[@class='tit']").InnerText;
                var numDam = item.SelectSingleNode("span[@class='num']").InnerText;
                Console.WriteLine($"타이틀 : {titleDam}");
                Console.WriteLine($"인원 : {numDam}");

                numDam = Regex.Replace(numDam, @"\D", "");

                title.Add(titleDam);
                num.Add(numDam);
            }

            label1.Text = title[0];
            label2.Text = title[1];
            label3.Text = title[2];
            label4.Text = title[3];

            label5.Text = num[0];
            label6.Text = num[1];
            label7.Text = num[2];
            label8.Text = num[3];
        }
    }
}
