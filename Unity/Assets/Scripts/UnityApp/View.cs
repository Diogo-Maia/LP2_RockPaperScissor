using LP2_RockPaperScissor.Common;
using UnityEngine;

namespace LP2_RockPaperScissor.UnityApp
{
    /// <summary>
    /// Classe View, implementa MonoBehaviour e a interface IView
    /// </summary>
    public class View : MonoBehaviour, IView
    {
        /// <summary>
        /// Array que guarda informacao das posicoes no mapa
        /// </summary>
        public Place[,] map;
        /// <summary>
        /// Dimensoes horizontal e vertical da grelha de simulacao
        /// </summary>
        public int xdim, ydim;

        /// <summary>
        /// Metodo MapView
        /// </summary>
        /// <param name="map">Array que guarda a informacao das posicoes na
        /// grelha de simulcao</param>
        /// <param name="xdim">Dimensao horizontal da grelha de simulacao
        /// </param>
        /// <param name="ydim">Dimensao vertical da grelha de simulacao
        /// </param>
        public void MapView(Place[,] map, int xdim, int ydim)
        {
            this.map = map;
            this.xdim = xdim;
            this.ydim = ydim;
        }
    }
}