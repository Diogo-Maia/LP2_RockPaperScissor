using UnityEngine;
using UnityEngine.UI;
using LP2_RockPaperScissor.Common;

namespace LP2_RockPaperScissor.UnityApp
{
    /// <summary>
    /// Classe Map, implementa MonoBehaviour
    /// </summary>
    public class Map : MonoBehaviour
    {
        /// <summary>
        /// Variável do tipo RawImage, usada para desenhar a grelha no canvas
        /// do unity
        /// </summary>
        [SerializeField] private RawImage rawImage;

        /// <summary>
        /// Variàvel do tipo View
        /// </summary>
        private View v;

        /// <summary>
        /// Variável do tipo Texture2D, usada para desenhar a grelha no canvas
        /// do unity
        /// </summary>
        private Texture2D texture;

        /// <summary>
        /// Variavel do tipo bool, usada para ver se pode mostrar o mapa ou nao
        /// </summary>
        private bool signal;

        /// <summary>
        /// Método Start, inicia a simulação
        /// </summary>
        // Start is called before the first frame update
        void Start()
        {
            v = GetComponent<View>();
            signal = false;
        }

        /// <summary>
        /// Método Update, atualiza cada frame da simulação
        /// </summary>
        // Update is called once per frame
        void Update()
        {
            if (v.map != null && signal)
            {
                if (texture != null && signal)
                {
                    for (int x = 0; x < v.map.GetLength(0); x++)
                    {
                        for (int y = 0; y < v.map.GetLength(1); y++)
                        {
                            switch (v.map[x, y].GetSpecie())
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
            }
        }

        /// <summary>
        /// Método CreateTexture, desenha a textura numa RawImage do unity UI
        /// </summary>
        public void CreateTexture(int x, int y)
        {
            ResetTexture();
            texture = new Texture2D(x, y)
            {
                filterMode = FilterMode.Point
            };
        }

        /// <summary>
        /// Método ResetTexture, dá reset na textura
        /// </summary>
        public void ResetTexture()
        {
            rawImage.texture = new Texture2D(1, 1);
            texture = null;
        }

        /// <summary>
        /// Metodo SetSignal, altera o valor do signal
        /// </summary>
        /// <param name="signal"></param>
        public void SetSignal(bool signal)
        {
            this.signal = signal;
        }
    }
}


