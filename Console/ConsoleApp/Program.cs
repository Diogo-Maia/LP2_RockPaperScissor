namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller c = new Controller();
            View ui = new View();

            if (c.CheckVars(args)) c.StartGame(ui);
        }
    }
}
