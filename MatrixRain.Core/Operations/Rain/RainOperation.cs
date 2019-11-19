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

            for(int i = 0; i < _width; i++)
            {
                _yAxisFirstSection[i] = _random.Next(_height);
                _yAxisSecondSection[i] =
                    _random.Next(heightSecondSection * (i % 11 != 10 ? 2 : 1),
                                 heightFirstSection * (i % 11 != 10 ? 2 : 1));
            }
        }
    }
}
