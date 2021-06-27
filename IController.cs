namespace LP2_RockPaperScissor.Common
{
    public interface IController
    {
        string CheckVars(string[] args);
        void StartGame(IView ui);
    }
}