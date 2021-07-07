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
            //System.Threading.Thread.Sleep(100);
            /*Tmap = new Texture2D(xdim, ydim);
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    switch (map[x, y].GetSpecie())
                    {
                        case Species.Rock:
                            //Map[x, y] = Color.blue;
                            Tmap.SetPixel(x, y, Color.blue);
                            break;
                        case Species.Paper:
                            //Map[x, y] = Color.green;
                            Tmap.SetPixel(x, y, Color.green);
                            break;
                        case Species.Scissor:
                            //Map[x, y] = Color.red;
                            Tmap.SetPixel(x, y, Color.red);
                            break;
                        case Species.Empty:
                            //Map[x, y] = Color.black;
                            Tmap.SetPixel(x, y, Color.black);
                            break;
                    }
                    Tmap.Apply();
                    rawImage.texture = Tmap;
                }
            }*/
        }
    }
}