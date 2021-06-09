using System;

namespace LP2_RockPaperScissor.Common
{
    class GameManager
    {
        private int xdim, ydim;
        private double swap_rate_exp, repr_rate_exp, selc_rate_exp;

        private Place[,] map;
        private IView ui;

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

        public void Start(IView ui)
        {
            this.ui = ui;

            FillMap();
            ui.MapView(map, xdim, ydim);
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
    }
}
