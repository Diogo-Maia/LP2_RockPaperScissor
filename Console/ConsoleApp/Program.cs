using System;

namespace ConsoleApp
{
    /// <summary>
    /// Classe Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Método Main, inicia a simulação
        /// </summary>
        /// <param name="args">Array de strings</param>
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
