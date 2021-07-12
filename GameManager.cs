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
        /// Dimensões da grelha
        /// </summary>
        private readonly int xdim, ydim;
        /// <summary>
        /// Taxa de eventos
        /// </summary>
        private readonly double swap_rate_exp, repr_rate_exp, selc_rate_exp;

        /// <summary>
        /// Array de posições do mapa
        /// </summary>
        private readonly Place[,] map;
        /// <summary>
        /// Variável do tipo random
        /// </summary>
        private Random rdn;

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
            rdn = new Random();
        }

        /// <summary>
        /// Método Start, inicia a simulação
        /// </summary>
        /// <param name="ui">Variável do UI</param>
        public void Start(IView ui)
        {
            FillMap();
            GameLoop(ui);
        }

        /// <summary>
        /// Método que faz o loop da simulação
        /// </summary>
        /// <param name="ui">Variável do UI</param>
        private void GameLoop(IView ui)
        {
            while (true)
            {
                ExecuteEvents(GenerateEvents());

                ui.MapView(map, xdim, ydim);
            }
        }

        /// <summary>
        /// Método FillMap, prenche o mapa
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
        /// Método PlaceSpecie, coloca uma espécie random em cada célula
        /// </summary>
        /// <returns>Retorna uma espécie random</returns>
        private Species PlaceSpecie()
        {
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
        /// <returns>Retorna uma lista de eventos baralhados</returns>
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

            return FisherYates(events);
        }

        /// <summary>
        /// Método que executa os eventos da lista de eventos baralhados
        /// </summary>
        /// <param name="events">Lista de eventos baralhados</param>
        private void ExecuteEvents(List<Events> events)
        {
            int r_x;
            int r_y;
            foreach (Events e in events)
            {
                r_x = rdn.Next(0, xdim);
                r_y = rdn.Next(0, ydim);
                switch (e)
                {
                    case Events.Swap:
                        map[r_x, r_y].Swap(map, r_x, r_y, xdim, ydim);
                        break;
                    case Events.Reproduction:
                        map[r_x, r_y].Reproduction(map, r_x, r_y, xdim, ydim);
                        break;
                    case Events.Selection:
                        map[r_x, r_y].Selection(map, r_x, r_y, xdim, ydim);
                        break;
                }
            }
        }

        /// <summary>
        /// Método que baralha uma lista de eventos
        /// </summary>
        /// <param name="toShuffle"></param>
        /// <returns>Retorna uma lista de eventos baralhados</returns>
        private List<Events> FisherYates(List<Events> toShuffle)
        {
            List<Events> shuffle = new List<Events>();
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
        /// Método Poisson, escolhe um número random
        /// </summary>
        /// <param name="lambda"></param>
        /// <returns>Retorna um número random</returns>
        private int Poisson(double lambda)
        {
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
