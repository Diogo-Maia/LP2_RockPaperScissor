using System;
using LP2_RockPaperScissor.Common;
using System.Globalization;

namespace ConsoleApp
{
    /// <summary>
    /// Classe Controller que implementa a interface IController
    /// </summary>
    class Controller : IController
    {
        /// <summary>
        /// Dimensões horizontal e vertical da grelha de simulação
        /// </summary>
        private int xdim, ydim;
        /// <summary>
        /// Taxas dos eventos, respectivamente, de troca, reprodução e seleção
        /// </summary>
        private double swap_rate_exp, repr_rate_exp, selc_rate_exp;

        /// <summary>
        /// Variável do tipo GameManager
        /// </summary>
        private GameManager game;

        /// <summary>
        /// Método para verificar se o valor inserido está dentro dos limites
        /// impostos
        /// </summary>
        /// <param name="args">Array que guarda os valores inseridos</param>
        /// <returns>Retorna um valor null</returns>
        public string CheckVars(string[] args)
        {
            // Verifica se são inseridos mais que 5 argumentos
            if (args.Length > 5)
                return "Too much Arguments";

            // Verifica se argumento é um int
            if (!int.TryParse(args[0], NumberStyles.Any,
                CultureInfo.InvariantCulture, out xdim))
                return "X needs to be a integer";

            // Verifica se foi inserido valor menor que 2
            if (xdim < 2)
                return "X needs to be above or equal to 2";

            // Verifica se argumento é um int
            if (!int.TryParse(args[1], NumberStyles.Any,
                CultureInfo.InvariantCulture, out ydim))
                return "Y needs to be a integer";

            // Verifica se foi inserido valor menor que 2
            if (ydim < 2)
                return "Y needs to be abover or equal to 2";

            // Verifica se argumento é um double
            if (!double.TryParse(args[2], NumberStyles.Any,
                CultureInfo.InvariantCulture, out swap_rate_exp))
                return "Swap rate needs to be a double";

            // Verifica se foi inserido valor entre -1 e 1
            if (swap_rate_exp < -1.0 || swap_rate_exp > 1.0)
                return "Swap rate needs to be between 1 and -1";

            // Verifica se argumento é um int
            if (!double.TryParse(args[3], NumberStyles.Any,
                CultureInfo.InvariantCulture, out repr_rate_exp))
                return "Reproduction rate needs to be a double";

            // Verifica se foi inserido valor entre -1 e 1
            if (repr_rate_exp < -1.0 || repr_rate_exp > 1.0)
                return "Reproduction rate needs to be between 1 and -1";

            // Verifica se argumento é um int
            if (!double.TryParse(args[4], NumberStyles.Any,
                CultureInfo.InvariantCulture, out selc_rate_exp))
                return "Selection rate needs to be a double"; ;

            // Verifica se foi inserido valor entre -1 e 1
            if (selc_rate_exp < -1.0 || selc_rate_exp > 1.0)
                return "Selection rate needs to be between 1 and -1";

            return null;
        }

        /// <summary>
        /// Classe que inicia a simulação
        /// </summary>
        /// <param name="ui">Variável do UI</param>
        public void StartGame(IView ui)
        {
            game = new GameManager(xdim, ydim,
                swap_rate_exp, repr_rate_exp, selc_rate_exp);

            game.Start(ui);
        }
    }
}
