namespace LP2_RockPaperScissor.Common
{
    public interface IController
    {
        bool CheckVars(string[] args);
        void StartGame(IView ui);
    }
}