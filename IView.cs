namespace LP2_RockPaperScissor.Common
{
    /// <summary>
    /// Interface IView, desenha o mapa
    /// </summary>
    public interface IView
    {
        void MapView(Place[,] map, int xdim, int ydim);
    }
}
