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

        public string CheckVars(string[] args)
        {
            if (args.Length > 5) 
                return "Too much Arguments";

            if (!int.TryParse(args[0], NumberStyles.Any,
                CultureInfo.InvariantCulture, out xdim)) 
                return "X needs to be a integer";

            if (xdim < 2) 
                return "X needs to be above or equal to 2";

            if (!int.TryParse(args[1], NumberStyles.Any,
                CultureInfo.InvariantCulture, out ydim)) 
                return "Y needs to be a integer";

            if (ydim < 2) 
                return "Y needs to be abover or equal to 2";

            if (!double.TryParse(args[2], NumberStyles.Any,
                CultureInfo.InvariantCulture, out swap_rate_exp)) 
                return "Swap rate needs to be a double";

            if (swap_rate_exp < -1.0 || swap_rate_exp > 1.0)
                return "Swap rate needs to be between 1 and -1";

            if (!double.TryParse(args[3], NumberStyles.Any,
                CultureInfo.InvariantCulture, out repr_rate_exp)) 
                return "Reproduction rate needs to be a double";

            if (repr_rate_exp < -1.0 || repr_rate_exp > 1.0)
                return "Reproduction rate needs to be between 1 and -1";

            if (!double.TryParse(args[4], NumberStyles.Any,
                CultureInfo.InvariantCulture, out selc_rate_exp)) 
                return "Selection rate needs to be a double"; ;

            if (selc_rate_exp < -1.0 || selc_rate_exp > 1.0)
                return "Selection rate needs to be between 1 and -1";

            return null;
        }

        public void StartGame(IView ui)
        {
            game = new GameManager(xdim, ydim,
                swap_rate_exp, repr_rate_exp, selc_rate_exp);

            game.Start(ui);
        }
    }
}
