using System;
using System.Collections.Generic;

namespace LP2_RockPaperScissor.Common
{
    /// <summary>
    /// Classe GameManager
    /// </summary>
    public class GameManager
    {
        /// <summary>
        /// Números inteiros que representam as dimensões horizontal e vertical 
        /// da grelha de simulação
        /// </summary>
        private int xdim, ydim;
        /// <summary>
        /// Números reais entre -1.0 e 1-0 que represetam, respectivamente, a 
        /// taxa dos eventos de troca, de reprodução e de seleção
        /// </summary>
        private double swap_rate_exp, repr_rate_exp, selc_rate_exp;

        /// <summary>
        /// Array das posições na grelha da simulação
        /// </summary>
        private Place[,] map;
        /// <summary>
        /// 
        /// </summary>
        private IView ui;

        /// <summary>
        /// Construtor da classe GameManager
        /// </summary>
        /// <param name="xdim">Dimensão horizontal da grelha</param>
        /// <param name="ydim">Dimensão vertical da grelha</param>
        /// <param name="swap_rate_exp">Taxa dos eventos de troca</param>
        /// <param name="repr_rate_exp">Taxa dos eventos de reprodução</param>
        /// <param name="selc_rate_exp">Taxa dos eventos de Seleção</param>
        public GameManager(int xdim, int ydim,
            double swap_rate_exp, double repr_rate_exp, double selc_rate_exp)
        {
            this.xdim = xdim;
            this.ydim = ydim;
            this.swap_rate_exp = swap_rate_exp;
            this.repr_rate_exp = repr_rate_exp;
            this.selc_rate_exp = selc_rate_exp;

            map = new Place[xdim, ydim];
        }

        /// <summary>
        /// Método Start
        /// </summary>
        /// <param name="ui"></param>
        public void Start(IView ui)
        {
            this.ui = ui;

            FillMap();
            ui.MapView(map, xdim, ydim);

            //Loop so cá está para ver o swap a funcionar
            while (true)
            {
                Console.Clear();
                //map[1, 1].Swap(map, 1, 1, xdim, ydim);
                map[1, 1].Reproduction(map, 1, 1, xdim, ydim);
                ui.MapView(map, xdim, ydim);
                System.Threading.Thread.Sleep(500);
            }
        }

        /// <summary>
        /// Método FillMap
        /// </summary>
        private void FillMap()
        {
            for (int x = 0; x < xdim; x++)
            {
                for (int y = 0; y < ydim; y++)
                {
                    map[x, y] = new Place(PlaceSpecie());
                }
            }
        }

        /// <summary>
        /// Método PlaceSpecie
        /// </summary>
        /// <returns></returns>
        private Species PlaceSpecie()
        {
            Random rdn = new Random();

            int i = rdn.Next(0, 4);

            return i switch
            {
                0 => Species.Rock,
                1 => Species.Paper,
                2 => Species.Scissor,
                _ => Species.Empty,
            };
        }

        /// <summary>
        /// Método GeneratEvents do tipo List<Events>
        /// </summary>
        /// <returns></returns>
        private List<Events> GenerateEvents()
        {
            double lambda = (xdim * ydim / 3.0) * Math.Pow(10, swap_rate_exp);
            List<Events> events = new List<Events>();
            for (int i = 0; i < Poisson(lambda); i++)
            {
                events.Add(Events.Swap);
            }
            lambda = (xdim * ydim / 3.0) * Math.Pow(10, repr_rate_exp);
            for (int i = 0; i < Poisson(lambda); i++)
            {
                events.Add(Events.Reproduction);
            }
            lambda = (xdim * ydim / 3.0) * Math.Pow(10, selc_rate_exp);
            for (int i = 0; i < Poisson(lambda); i++)
            {
                events.Add(Events.Selection);
            }

            return events;
        }

        /// <summary>
        /// Método FisherYates do tipo List<char>
        /// </summary>
        /// <param name="toShuffle"></param>
        /// <returns></returns>
        private List<char> FisherYates(List<char> toShuffle)
        {
            List<char> shuffle = new List<char>();
            Random rdn = new Random();
            List<int> n = new List<int>();

            for (int i = 0; i < toShuffle.Count; i++)
            {
                int j;
                do
                {
                    j = rdn.Next(0, toShuffle.Count);

                } while (n.Contains(j));

                n.Add(j);
                shuffle.Add(toShuffle[j]);
            }
            shuffle.Reverse();

            return shuffle;
        }

        /// <summary>
        /// Método Poisson,
        /// </summary>
        /// <param name="lambda"></param>
        /// <returns></returns>
        private int Poisson(double lambda)
        {
            Random rdn = new Random();
            double l = Math.Exp(-lambda);
            double p = 1.0;
            int k = 0;

            do
            {
                k++;
                p *= rdn.NextDouble();
            } while (p > l);

            return k - 1;
        }
    }
}
