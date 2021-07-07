﻿using System;
using System.Collections.Generic;

namespace LP2_RockPaperScissor.Common
{
    public class GameManager
    {
        private readonly int xdim, ydim;
        private readonly double swap_rate_exp, repr_rate_exp, selc_rate_exp;

        private readonly Place[,] map;
        private Random rdn;

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

        public void Start(IView ui)
        {
            FillMap();
            GameLoop(ui);
        }

        private void GameLoop(IView ui)
        {
            while (true)
            {
                ExecuteEvents(GenerateEvents());

                ui.MapView(map, xdim, ydim);
            }
        }

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

        private void ExecuteEvents(List<Events> events)
        {
            Random rdn = new Random();
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

        private List<Events> FisherYates(List<Events> toShuffle)
        {
            List<Events> shuffle = new List<Events>();
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
