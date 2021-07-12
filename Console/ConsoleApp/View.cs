using System;
using LP2_RockPaperScissor.Common;

namespace ConsoleApp
{
    /// <summary>
    /// Classe View que implementa a interface IView e desenha a grelha de 
    /// simulação
    /// </summary>
    class View : IView
    {
        /// <summary>
        /// Método MapView desenha as células da grelha
        /// </summary>
        /// <param name="map">Mapa onde as posições são guardadas</param>
        /// <param name="xdim">Dimensão horizontal grelha de simulação</param>
        /// <param name="ydim">Dimensões vertical da grelha de simulação</param>
        public void MapView(Place[,] map, int xdim, int ydim)
        {
            Console.Clear();
            // Desenha as cores de cada specie com a suua cor correspondente
            // na grelhas
            for (int x = 0; x < xdim; x++)
            {
                for (int y = 0; y < ydim; y++)
                {
                    switch (map[x, y].GetSpecie())
                    {
                        case Species.Rock:
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("■ ");
                            break;
                        case Species.Paper:
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("■ ");
                            break;
                        case Species.Scissor:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("■ ");
                            break;
                        case Species.Empty:
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("■ ");
                            break;
                    }
                    
                }
                Console.WriteLine();
            }
            // Pausa a thread
            System.Threading.Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
