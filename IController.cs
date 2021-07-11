﻿namespace LP2_RockPaperScissor.Common
{
    /// <summary>
    /// Interface IController, guarda as variáveis e inicia o UI
    /// </summary>
    public interface IController
    {
        string CheckVars(string[] args);
        void StartGame(IView ui);
    }
}