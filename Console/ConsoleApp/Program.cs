using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller c = new Controller();
            View ui = new View();

            string status = c.CheckVars(args);

            if (status == null) c.StartGame(ui);
            else Console.WriteLine(status);
        }
    }
}
