using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Process_Test
{
    public partial class Form1 : Form
    {
        // 윈도우 프로세스 정보
        [DllImport("User32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

        // 프로세스 정보를 저장할 구조체
        public struct Rect
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
        }

        Process process = null; // 프로세스 변수
        Rect processRect; // 프로세스 크기 정보 변수
        IntPtr processIntPtr = IntPtr.Zero; // 프로세스 헨들러
        string processName = "notepad"; // 프로세스 아이디

        public Form1()
        {
            InitializeComponent();

            // 타이머 설정
            Timer_Size.Stop();
            Timer_Size.Interval = 100;
            Timer_Size.Tick += Timer_Size_Tick;

            Timer_Find.Start();
            Timer_Find.Interval = 100;
            Timer_Find.Tick += Timer_Find_Tick;
        }

        // 프로세스를 찾는 타이머 이벤트
        private void Timer_Find_Tick(object sender, EventArgs e)
        {
            Process[] process = Process.GetProcessesByName(processName);

            // 프로세스를 찾지 못하는 경우 예외 처리
            if (process.Length > 0)
            {
                // 찾았다면 타이머 종료
                Console.WriteLine("찾았습니다.");
                this.process = process[0];
                this.process.EnableRaisingEvents = true;
                this.process.Exited += Process_Exited;

                processIntPtr = this.process.MainWindowHandle;

                Timer_Find.Stop();
                Timer_Size.Start();
            }
            else
            {
                Console.WriteLine("찾지 못했습니다.");
            }
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            //기본 종료 이벤트
            process = null;
            processIntPtr = IntPtr.Zero;
            Timer_Find.Start();
            Timer_Size.Stop();

            // 크로스 쓰레드 방지
            //this.invoke((methodinvoker)delegate
            //{
            //    process = null; // 이전 프로세스 초기화
            //    processintptr = intptr.zero; // 이전 프로세스 정보 초기화
            //    timer_find.start(); // 프로세스 추적 타이머 시작
            //    timer_size.stop(); // 위치 타이머 정지
            //});
        }

        // 폼 사이즈 변경 이벤트
        private void Timer_Size_Tick(object sender, EventArgs e)
        {
            GetWindowRect(processIntPtr, ref processRect);

            Console.WriteLine("---------------");
            Console.WriteLine("Left : " + processRect.Left);
            Console.WriteLine("Right : " + processRect.Right);
            Console.WriteLine("Top : " + processRect.Top);
            Console.WriteLine("Bottom : " + processRect.Bottom);
            Console.WriteLine("---------------");

            // 크기 셋팅
            Size = new System.Drawing.Size(processRect.Right - processRect.Left, processRect.Bottom - processRect.Top);

            // 위치 셋팅
            this.Location = new System.Drawing.Point(processRect.Left, processRect.Top);

        }
    }
}
