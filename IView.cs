namespace LP2_RockPaperScissor.Common
{
    /// <summary>
    /// Interface IView, desenha o mapa
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Método que desenha a grelha
        /// </summary>
        /// <param name="map">Array que guarda as posições do mapa</param>
        /// <param name="xdim">Dimensão horizontal da grelha</param>
        /// <param name="ydim">Dimensão vertical da grelha</param>
        void MapView(Place[,] map, int xdim, int ydim);
    }
}
