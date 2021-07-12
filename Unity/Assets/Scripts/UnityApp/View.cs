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
        /// Array que guarda informa��o das posi��es no mapa
        /// </summary>
        public Place[,] map;
        /// <summary>
        /// Dimens�es horizontal e vertical da grelha de simula��o
        /// </summary>
        public int xdim, ydim;

        /// <summary>
        /// M�todo MapView
        /// </summary>
        /// <param name="map">Array que guarda a informa��o das posi��es na
        /// grelha de simula��o</param>
        /// <param name="xdim">Dimens�o horizontal da grelha de simula��o
        /// </param>
        /// <param name="ydim">Dimens�o vertical da grelha de simula��o
        /// </param>
        public void MapView(Place[,] map, int xdim, int ydim)
        {
            this.map = map;
            this.xdim = xdim;
            this.ydim = ydim;
        }
    }
}