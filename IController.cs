namespace LP2_RockPaperScissor.Common
{
    /// <summary>
    /// Interface IController, guarda as variáveis e inicia o UI
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// Método que verifica as variáveis
        /// </summary>
        /// <param name="args">Array de strings</param>
        /// <returns>Retorna uma string </returns>
        string CheckVars(string[] args);

        /// <summary>
        /// Método StartGame, inicia a simulação
        /// </summary>
        /// <param name="ui">Variável do UI</param>
        void StartGame(IView ui);
    }
}