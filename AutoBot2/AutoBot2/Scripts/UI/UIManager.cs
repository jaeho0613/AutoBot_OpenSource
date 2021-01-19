using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoBot2.Scripts.UI
{
    /// <summary>
    /// AutoClick에 필요한 초기화 클레스
    /// </summary>
    class UIManager
    {
        public IntPtr clientPtr = IntPtr.Zero; // 클라이언트 포인터
        private Point clientPoint = Point.Empty; // 클라이언트 위치
        private int clientHeightSize = 0; // 클라이언트 높이

        public UIManager()
        {
        }

        /// <summary>
        /// 버튼 활성화, 비활성화 이벤트
        /// </summary>
        /// <param name="isCheck">비교 Bool값</param>
        /// <param name="iconButton">변경될 UI 버튼</param>
        public void BtnClickEvent(ref bool isCheck, IconButton iconButton)
        {
            if (isCheck == true)
            {
                isCheck = false;
                iconButton.ForeColor = Color.White;
                iconButton.IconColor = Color.White;
                iconButton.IconChar = FontAwesome.Sharp.IconChar.Square;
            }
            else
            {
                isCheck = true;
                iconButton.ForeColor = Color.GreenYellow;
                iconButton.IconColor = Color.GreenYellow;
                iconButton.IconChar = FontAwesome.Sharp.IconChar.CheckSquare;
            }
        }

        // UI Show
        public void ShowSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        // 클라이언트 핸들 
        public void InitClientPtr()
        {
            try
            {
                //Console.WriteLine("InitClientPtr");
                clientPtr = GlobalClientData.clientProcess.MainWindowHandle;
                //Console.WriteLine(clientPtr.ToString());
                if (clientPtr.ToInt32() == 0)
                {
                    clientPtr = GlobalClientData.clientProcess.MainWindowHandle;
                    //Console.WriteLine(clientPtr.ToString());
                }
            }
            catch
            {
                StatusDisplay status = new StatusDisplay("클라이언트 초기화 오류!", StatusDisplay.enumType.Warning);
            }
        }

        // 클라이언트 위치 초기화
        public bool InitClientRect()
        {
            try
            {
                //Console.WriteLine("InitClientRect");
                GlobalUserDll.GetWindowRect(clientPtr, ref GlobalClientData.clientRect);
                return true;
            }
            catch
            {
                StatusDisplay status = new StatusDisplay("클라이언트 위치찾기 오류!", StatusDisplay.enumType.Warning);
                return false;
            }
        }

        // 클라이언트 높이
        public int GetClientHeight()
        {
            //Console.WriteLine("높이 : " + (GlobalClientData.clientRect.Bottom - GlobalClientData.clientRect.Top));
            return clientHeightSize = GlobalClientData.clientRect.Bottom - GlobalClientData.clientRect.Top;
        }

        // 클라이언트 위치값
        public Point GetClientPoint(int mainWidth)
        {
            return clientPoint = new Point(GlobalClientData.clientRect.Left - mainWidth, GlobalClientData.clientRect.Top);
        }

    }
}
