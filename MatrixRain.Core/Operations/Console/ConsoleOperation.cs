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

        private readonly Random _random;

        private char GetRandomChar { get { return GenerateRandomChar(); } }

        public int ConsoleWidth { get { return System.Console.WindowWidth; } }

        public int ConsoleHeight { get { return System.Console.WindowHeight; } }

        public ConsoleColor SetConsoleForeground { set => System.Console.ForegroundColor = value; }

        public ConsoleColor GetConsoleForeground { get => System.Console.ForegroundColor; }

        public ConsoleOperation()
        {
            _thisConsole = GetConsoleWindow();

            _random = new Random();
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

        public void SetCursorPosition(int xAxisPosition, int yAxisPosition)
        {
            System.Console.SetCursorPosition(xAxisPosition, yAxisPosition);
        }

        public void WriteCharacter(bool isRandom = false, bool isWhiteSpace = false)
        {
            if (isRandom && !isWhiteSpace)
            {
                System.Console.Write(GetRandomChar);
            }
            else if (!isRandom && isWhiteSpace)
            {
                System.Console.Write(' ');
            }
        }

        #region PRIVATE Helper Methods
        private char GenerateRandomChar()
        {
            int randomCharKeyCode = _random.Next(10);

            if (randomCharKeyCode <= 2)
            {
                return (char)('0' + _random.Next(10));
            }

            if (randomCharKeyCode <= 4)
            {
                return (char)('a' + _random.Next(27));
            }

            if (randomCharKeyCode <= 6)
            {
                return (char)('A' + _random.Next(27));
            }

            return (char)(_random.Next(32, 255));
        }
        #endregion
    }
}
