using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace AutoBot2
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int Major = Environment.OSVersion.Version.Major;
            int Minor = Environment.OSVersion.Version.Minor;

            bool isNew = true;

            Mutex mutex = new Mutex(true, "jMutex", out isNew);

            // 중복 실행 예외 처리
            if (isNew == false)
            {
                MessageBox.Show("중복 실행은 금지 합니다.");
                Application.Exit();

                return;
            }

            // ssl/tls 보안 설정 예외 처리
            if (Major < 10)
            {
                Console.WriteLine("ssl/tls 보안 설정 예외 처리");
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls
                    | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            }

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var targetApplication = Process.GetCurrentProcess().ProcessName + ".exe";

                int browserver = 7;
                int ie_emulation = 11999;

                // 사용자 IE 버전 확인
                using (WebBrowser wb = new WebBrowser())
                {
                    browserver = wb.Version.Major;

                    if (browserver >= 11)
                        ie_emulation = 11001;
                    else if (browserver == 10)
                        ie_emulation = 10001;
                    else if (browserver == 9)
                        ie_emulation = 9999;
                    else if (browserver == 8)
                        ie_emulation = 8888;
                    else
                        ie_emulation = 7000;
                }
                try
                {
                    Application.Run(new InitForm(targetApplication, ie_emulation));
                }
                catch (Exception ex1)
                {
                    Console.WriteLine("실행 오류 :" + ex1);
                    MessageBox.Show("이미 프로그램이 실행중입니다!");
                    Application.Exit();
                }
            }
            catch (Exception ex2)
            {
                Console.WriteLine("레지스트리 패치 오류 : " + ex2);
                MessageBox.Show("이미 프로그램이 실행중입니다!");
                Application.Exit();
            }
            finally
            {
                mutex.ReleaseMutex();
            }

            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}