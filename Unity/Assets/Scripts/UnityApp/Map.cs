using UnityEngine;
using UnityEngine.UI;
using LP2_RockPaperScissor.Common;

namespace LP2_RockPaperScissor.UnityApp
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private RawImage rawImage;

        private View v;

        private Texture2D Tmap;

        // Start is called before the first frame update
        void Start()
        {
            v = GetComponent<View>();
            Tmap = new Texture2D(100, 100);
        }

        // Update is called once per frame
        void LateUpdate()
        {
            if (v.map != null) 
            {
                Tmap = new Texture2D(v.xdim, v.ydim);
                for (int x = 0; x < v.map.GetLength(0); x++)
                {
                    for (int y = 0; y < v.map.GetLength(1); y++)
                    {
                        //Debug.Log(v.map[x, y].GetSpecie());
                        switch (v.map[x, y].GetSpecie())
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
                }
            }            
        }
    }
}


