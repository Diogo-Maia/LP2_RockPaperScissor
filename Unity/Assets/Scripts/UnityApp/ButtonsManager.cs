using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using LP2_RockPaperScissor.UnityApp;
using TMPro;
using System;

namespace LP2_RockPaperScissor.UnityApp
{
    /// <summary>
    /// Classe Buttons Manager, implementa MonoBehaviour
    /// </summary>
    public class ButtonsManager : MonoBehaviour
    {
        /// <summary>
        /// Dimens�o horizontal da grelha de simula��o
        /// </summary>
        [SerializeField] private TextMeshProUGUI xdim;
        /// <summary>
        /// Dimens�o vertical da grelha de simula��o
        /// </summary>
        [SerializeField] private TextMeshProUGUI ydim;
        /// <summary>
        /// Taxa de troca
        /// </summary>
        [SerializeField] private Slider swap;
        /// <summary>
        /// Taxa de reprodu��o
        /// </summary>
        [SerializeField] private Slider repr;
        /// <summary>
        /// Taxa de sele��o
        /// </summary>
        [SerializeField] private Slider sele;

        /// <summary>
        /// Vari�vel de tipo view para UI
        /// </summary>
        [SerializeField] private View ui;
        
        /// <summary>
        /// Vari�vel de tipo GameObject para texto pausa do but�o pausa
        /// </summary>
        [SerializeField] private GameObject pauseText;
        /// <summary>
        /// Vari�vel de tipo GameObject para texto continue do but�o pausa
        /// </summary>
        [SerializeField] private GameObject continueText;

        /// <summary>
        /// Vari�vel do tipo Controller
        /// </summary>
        private Controller c;
        /// <summary>
        /// Array de argumentos
        /// </summary>
        private string[] args;

        /// <summary>
        /// Declara uma Thread 
        /// </summary>
        private Thread thread;

        /// <summary>
        /// Booleano que vai ser usado para colocar a simul��o em pausa
        /// </summary>
        private bool isPaused;

        /// <summary>
        /// M�todo Start, primeiro m�todo a correr quando se inicia a simula��o
        /// </summary>
        private void Start()
        {
            c = new Controller();
            isPaused = false;
            pauseText.SetActive(true);
            continueText.SetActive(false);
        }

        /// <summary>
        /// M�todo OnStartClick, corre quando se clica no but�o Start
        /// </summary>
        public void OnStartClick()
        {
            args = 
                ToArray(xdim.text, ydim.text, swap.value, repr.value, sele.value);
            string result = c.CheckVars(args);
            if (result == null)
            {
                thread = new Thread(StartGame);
                thread.Start();
            }
        }

        /// <summary>
        /// M�todo ToArray, converte os valores das taxas para strings
        /// </summary>
        /// <param name="x">Posi��o em x</param>
        /// <param name="y">Posi��o em y</param>
        /// <param name="swap">Valor de taxa de troca</param>
        /// <param name="repr">Valor de taxa de reprodu��o</param>
        /// <param name="sele">Valor de taxa de sele��o</param>
        /// <returns></returns>
        private string[] ToArray(string x, string y, double swap, double repr,
            double sele) => new string[] { x, y, Convert.ToString(swap),
                Convert.ToString(repr), Convert.ToString(sele) };

        /// <summary>
        /// M�todo StartGame, inicia a simula��o
        /// </summary>
        private void StartGame()
        {
            c.StartGame(ui);
        }

        /// <summary>
        /// M�todo OnPauseClick, corre quando se clica no but�o Pause
        /// </summary>
        public void OnPauseClick()
        {
            // Verifica se a simula��o est� pausada
            if (!isPaused)
            {
                thread.Suspend();
                pauseText.SetActive(false);
                continueText.SetActive(true);
                Time.timeScale = 0;
                isPaused = true;
            }
            else
            {
                thread.Resume();
                pauseText.SetActive(true);
                continueText.SetActive(false);
                Time.timeScale = 1;
                isPaused = false;
            }
            
        }
        /// <summary>
        /// M�todo OnStopClick, para a simula��o quando se clica no but�o Stop
        /// </summary>
        public void OnStopClick()
        {
            thread.Abort();
        }

        /// <summary>
        /// M�todo OnQuitClick, fecha a aplica��o quando se clica no but�o Quit
        /// </summary>
        public void OnQuitClick()
        {
            Application.Quit();
        }
    }
}

