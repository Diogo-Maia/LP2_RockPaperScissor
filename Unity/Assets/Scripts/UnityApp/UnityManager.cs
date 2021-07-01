using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LP2_RockPaperScissor.Common;
namespace Unity
{
    public class UnityManager : MonoBehaviour
    {
        public GameManager xdim, ydim, swap_rate_exp, repr_rate_exp,
            selc_rate_exp;

        public UnityManager(GameManager xdim, GameManager ydim,
            GameManager swap_rate_exp, GameManager repr_rate_exp,
            GameManager selc_rate_exp)
        {
            this.xdim = xdim;
            this.ydim = ydim;
            this.swap_rate_exp = swap_rate_exp;
            this.repr_rate_exp = repr_rate_exp;
            this.selc_rate_exp = selc_rate_exp;
        }


        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        void Stop()
        {

        }

        public void Quit()
        {
            Application.Quit();
            Debug.Log("Exit Game");
        }
    }
}