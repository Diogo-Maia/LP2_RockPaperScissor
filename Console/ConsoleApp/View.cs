using System;
using LP2_RockPaperScissor.Common;

namespace ConsoleApp
{
    class View : IView
    {
        public void MapView(Place[,] map, int xdim, int ydim)
        {
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
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
        }
    }
}
