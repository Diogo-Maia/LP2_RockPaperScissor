using UnityEngine;
using UnityEngine.UI;
using LP2_RockPaperScissor.Common;

namespace LP2_RockPaperScissor.UnityApp
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private RawImage rawImage;

        private View v;

        private Texture2D texture;

        // Start is called before the first frame update
        void Start()
        {
            v = GetComponent<View>();
        }

        // Update is called once per frame
        void Update()
        {
            if (v.map != null) 
            {
                if (texture != null)
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
                else CreateTexture();
            }
        }

        private void CreateTexture()
        {
            texture = new Texture2D(v.xdim, v.ydim);
            texture.filterMode = FilterMode.Point;
        }
    }
}


