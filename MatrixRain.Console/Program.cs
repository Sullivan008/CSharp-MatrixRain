using MatrixRain.Core.Operations.Console;

namespace MatrixRain.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConsoleOperation consoleOperation = new ConsoleOperation();

            consoleOperation.Initialize();
            consoleOperation.Show();

        }
    }
}
