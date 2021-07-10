using LP2_RockPaperScissor.Common;
using UnityEngine;

namespace LP2_RockPaperScissor.UnityApp
{
    public class View : MonoBehaviour, IView
    {
        public Place[,] map;
        public int xdim, ydim;

        public void MapView(Place[,] map, int xdim, int ydim)
        {
            this.map = map;
            this.xdim = xdim;
            this.ydim = ydim;
        }
    }
}