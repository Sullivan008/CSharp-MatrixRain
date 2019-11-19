using MatrixRain.Core.Operations.Console;
using MatrixRain.Core.Operations.Rain;

namespace MatrixRain.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConsoleOperation consoleOperation = new ConsoleOperation();
            
            consoleOperation.Initialize();
            consoleOperation.Show();

            RainOperation rainOperation = new RainOperation(consoleOperation);

            rainOperation.MatrixInitialize();
            rainOperation.Draw();
        }
    }
}
