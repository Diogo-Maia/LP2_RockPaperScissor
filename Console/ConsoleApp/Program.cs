using LP2_RockPaperScissor.Common;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Checker check = new Checker();
            View ui = new View();

            if (check.CheckVars(args)) check.StartGame(ui);
        }
    }
}
