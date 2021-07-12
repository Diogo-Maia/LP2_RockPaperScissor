using LP2_RockPaperScissor.Common;

namespace LP2_RockPaperScissor.UnityApp
{
    /// <summary>
    /// Classe Controller, implementa a interface IController
    /// </summary>
    public class Controller : IController
    {
        /// <summary>
        /// Dimensões horizontal e vertical da grelha ed simulação
        /// </summary>
        private int xdim, ydim;
        /// <summary>
        /// Taxa de troca, reprodução e seleção
        /// </summary>
        private double swap_rate_exp, repr_rate_exp,
            selc_rate_exp;

        /// <summary>
        /// Variável do tipo GameManager
        /// </summary>
        private GameManager game;

        /// <summary>
        /// Método CheckVars
        /// </summary>
        /// <param name="args">Array de strings que guarda valor inserido</param>
        /// <returns>Retorna um valor null</returns>
        public string CheckVars(string[] args)
        {
            if (args.Length > 5)
                return "Too much Arguments";

            if (!int.TryParse(args[0], out xdim))
                return "X needs to be a integer";

            if (xdim < 2)
                return "X needs to be above or equal to 2 " + xdim;

            if (!int.TryParse(args[1], out ydim))
                return "Y needs to be a integer";

            if (ydim < 2)
                return "Y needs to be abover or equal to 2 " + ydim;

            if (!double.TryParse(args[2], out swap_rate_exp))
                return "Swap rate needs to be a double";

            if (swap_rate_exp < -1.0 || swap_rate_exp > 1.0)
                return "Swap rate needs to be between 1 and -1 " 
                    + swap_rate_exp;

            if (!double.TryParse(args[3], out repr_rate_exp))
                return "Reproduction rate needs to be a double";

            if (repr_rate_exp < -1.0 || repr_rate_exp > 1.0)
                return "Reproduction rate needs to be between 1 and -1 " 
                    + repr_rate_exp;

            if (!double.TryParse(args[4], out selc_rate_exp))
                return "Selection rate needs to be a double"; ;

            if (selc_rate_exp < -1.0 || selc_rate_exp > 1.0)
                return "Selection rate needs to be between 1 and -1 " 
                    + selc_rate_exp;

            return null;
        }

        /// <summary>
        /// Método StartGame, corre quando a simulação é iniciada
        /// </summary>
        /// <param name="ui"></param>
        public void StartGame(IView ui)
        {
            game = new GameManager(xdim, ydim,
                swap_rate_exp, repr_rate_exp, selc_rate_exp);

            game.Start(ui);
        }
    }
}