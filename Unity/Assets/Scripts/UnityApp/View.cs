using LP2_RockPaperScissor.Common;
using UnityEngine;
using UnityEngine.UI;

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
        /// Variavel do tipo RawImage, usada para desenhar a grelha no canvas
        /// do unity
        /// </summary>
        [SerializeField] private RawImage rawImage;

        /// <summary>
        /// Variavel do tipo Texture2D, usada para desenhar a grelha no canvas
        /// do unity
        /// </summary>
        private Texture2D texture;

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
            for (int x = 0; x < xdim; x++)
            {
                for (int y = 0; y < ydim; y++)
                {
                    switch (map[x, y].GetSpecie())
                    {
                        case Species.Rock:
                            texture.SetPixel(x, y, Color.blue);
                            break;
                        case Species.Paper:
                            texture.SetPixel(x, y, Color.green);
                            break;
                        case Species.Scissor:
                            texture.SetPixel(x, y, Color.red);
                            break;
                        case Species.Empty:
                            texture.SetPixel(x, y, Color.black);
                            break;
                    }
                    texture.Apply();
                    rawImage.texture = texture;
                }
            }

            
        }

        /// <summary>
        /// Metodo usado para criar uma textura
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void CreateTexture(int x, int y)
        {
            texture = new Texture2D(x, y)
            {
                filterMode = FilterMode.Point
            };
        }
    }
}