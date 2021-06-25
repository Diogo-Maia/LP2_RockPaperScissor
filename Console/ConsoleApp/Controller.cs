using System;
using LP2_RockPaperScissor.Common;
using System.Globalization;

namespace ConsoleApp
{
    class Controller : IController
    {
        private int xdim, ydim;
        private double swap_rate_exp, repr_rate_exp, selc_rate_exp;

        private GameManager game;

        public bool CheckVars(string[] args)
        {
            if (args.Length > 5) return false;

            if (!int.TryParse(args[0], NumberStyles.Any,
                CultureInfo.InvariantCulture, out xdim)) return false;
            if (!int.TryParse(args[1], NumberStyles.Any,
                CultureInfo.InvariantCulture, out ydim)) return false;

            if (!double.TryParse(args[2], NumberStyles.Any,
                CultureInfo.InvariantCulture, out swap_rate_exp)) return false;
            if (!double.TryParse(args[3], NumberStyles.Any,
                CultureInfo.InvariantCulture, out repr_rate_exp)) return false;
            if (!double.TryParse(args[4], NumberStyles.Any,
                CultureInfo.InvariantCulture, out selc_rate_exp)) return false;

            return true;
        }

        public void StartGame(IView ui)
        {
            game = new GameManager(xdim, ydim,
                swap_rate_exp, repr_rate_exp, selc_rate_exp);

            game.Start(ui);
        }
    }
}
