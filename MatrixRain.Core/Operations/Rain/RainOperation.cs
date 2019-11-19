using MatrixRain.Core.Common;
using MatrixRain.Core.Operations.Console;
using System;

namespace MatrixRain.Core.Operations.Rain
{
    public class RainOperation
    {
        private readonly int _width;
        private readonly int _height;

        private readonly int[] _yAxisFirstSection;
        private readonly int[] _yAxisSecondSection;

        private readonly ConsoleOperation _consoleOperation;
        private readonly Random _random;

        public RainOperation(ConsoleOperation consoleOperation)
        {
            _consoleOperation = consoleOperation ?? throw new ArgumentException(nameof(consoleOperation));

            _width = _consoleOperation.ConsoleWidth;
            _height = _consoleOperation.ConsoleHeight;

            _yAxisFirstSection = new int[_width];
            _yAxisSecondSection = new int[_width];

            _random = new Random();
        }

        public void MatrixInitialize()
        {
            int heightFirstSection = _height / 2;
            int heightSecondSection = heightFirstSection / 2;

            for (int i = 0; i < _width; i++)
            {
                _yAxisFirstSection[i] = _random.Next(_height);
                _yAxisSecondSection[i] =
                    _random.Next(heightSecondSection * (i % 11 != 10 ? 2 : 1),
                                 heightFirstSection * (i % 11 != 10 ? 2 : 1));
            }
        }

        public void Draw()
        {
            while (true)
            {
                DrawCharacters();
            }
        }

        #region PRIVATE Helper Methods
        private void DrawCharacters()
        {
            for (int i = 0; i < _width; ++i)
            {
                if (i % 11 == 10)
                {
                    _consoleOperation.SetConsoleForeground = ConsoleColors.DarkGray;
                }
                else
                {
                    _consoleOperation.SetConsoleForeground = ConsoleColors.DarkGreen;
                }

                _consoleOperation.SetCursorPosition(i,
                    GetYAxisPosition(_yAxisFirstSection[i] - 2 - (_yAxisSecondSection[i] / 40 * 2), _height));

                _consoleOperation.WriteCharacter(true, false);

                if (_consoleOperation.GetConsoleForeground == ConsoleColors.DarkGreen)
                {
                    _consoleOperation.SetConsoleForeground = ConsoleColors.Green;
                }
                else if (_consoleOperation.GetConsoleForeground == ConsoleColors.DarkGray)
                {
                    _consoleOperation.SetConsoleForeground = ConsoleColors.White;
                }

                _consoleOperation.SetCursorPosition(i, GetYAxisPosition(_yAxisFirstSection[i] + 1, _height));
                _consoleOperation.WriteCharacter(true, false);

                _yAxisFirstSection[i] = GetYAxisPosition(_yAxisFirstSection[i] + 1, _height);

                _consoleOperation.SetCursorPosition(i,
                    GetYAxisPosition(_yAxisFirstSection[i] - _yAxisSecondSection[i], _height));
                _consoleOperation.WriteCharacter(false, true);

                _consoleOperation.SetConsoleForeground = ConsoleColors.Green;
            }
        }

        private int GetYAxisPosition(int yAxisPosition, int height)
        {
            yAxisPosition %= height;

            return yAxisPosition < 0 ? (yAxisPosition + height) : yAxisPosition;
        }
        #endregion
    }
}
