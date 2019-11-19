using MatrixRain.Core.Common;
using System;
using System.Runtime.InteropServices;

namespace MatrixRain.Core.Operations.Console
{
    public class ConsoleOperation
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int MAXIMIZE_CODE = 3;
        private const string CONSOLE_TITLE = "Matrix";

        private static IntPtr _thisConsole;

        public ConsoleOperation()
        {
            _thisConsole = GetConsoleWindow();
        }

        public void Initialize()
        {
            System.Console.Title = CONSOLE_TITLE;
            System.Console.ForegroundColor = ConsoleColors.DarkGreen;
            System.Console.CursorVisible = false;
            System.Console.SetWindowSize(System.Console.LargestWindowWidth, System.Console.LargestWindowHeight);
            System.Console.Clear();
        }

        public void Show()
        {
            ShowWindow(_thisConsole, MAXIMIZE_CODE);
        }
    }
}
