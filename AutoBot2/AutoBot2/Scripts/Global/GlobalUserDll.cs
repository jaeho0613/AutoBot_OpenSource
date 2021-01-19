using System;
using System.Runtime.InteropServices;
using static GlobalClientData;

class GlobalUserDll
{
    //// 마우스 왼쪽 플레그
    //public const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
    //public const uint MOUSEEVENTF_LEFTUP = 0x0004;

    // 윈도우 프로세스
    [DllImport("User32.dll")]
    public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

    //// 마우스 이벤트
    //[DllImport("User32.dll")]
    //public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

    //// 이미지 스크린 저장 값
    //[DllImport("user32.dll")]
    //internal static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);

    //// 윈도우 최상위로 만들기
    //[DllImport("User32")]
    //public static extern int SetForegroundWindow(IntPtr hWnd);

    //// 메세지 전달
    //[DllImport("user32.dll", EntryPoint = "SendMessage")]
    //public static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int IParam);

    //// 폼 이동
    //[DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
    //public static extern void ReleaseCapture();

    //// 둥근 윈폼 만들기
    //[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
    // public static extern IntPtr CreateRoundRectRgn(int nLeftRect,
    //       int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

    //// 윈도우 프로세스 최상위 핸들
    //[DllImport("user32")]
    //public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);

    //// 윈도우 프로세스 최상위 핸들의 자식
    //[DllImport("user32.dll")]
    //public static extern int FindWindowEx(int hWnd1, int hWnd2, string lpsz1, string lpsz2);
}
