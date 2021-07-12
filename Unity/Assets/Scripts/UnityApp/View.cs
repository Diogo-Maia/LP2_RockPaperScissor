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
        /// Array que guarda informação das posições no mapa
        /// </summary>
        public Place[,] map;
        /// <summary>
        /// Dimensões horizontal e vertical da grelha de simulação
        /// </summary>
        public int xdim, ydim;

        /// <summary>
        /// Método MapView
        /// </summary>
        /// <param name="map">Array que guarda a informação das posições na
        /// grelha de simulação</param>
        /// <param name="xdim">Dimensão horizontal da grelha de simulação
        /// </param>
        /// <param name="ydim">Dimensão vertical da grelha de simulação
        /// </param>
        public void MapView(Place[,] map, int xdim, int ydim)
        {
            this.map = map;
            this.xdim = xdim;
            this.ydim = ydim;
        }
    }
}