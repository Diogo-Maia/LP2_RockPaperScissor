using UnityEngine;
using UnityEngine.UI;
using System.Threading;
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
        /// Dimensao horizontal da grelha de simulacao
        /// </summary>
        [SerializeField] private TextMeshProUGUI xdim;
        /// <summary>
        /// Dimensao vertical da grelha de simulacao
        /// </summary>
        [SerializeField] private TextMeshProUGUI ydim;
        /// <summary>
        /// Taxa de troca
        /// </summary>
        [SerializeField] private Slider swap;
        /// <summary>
        /// Taxa de reproducao
        /// </summary>
        [SerializeField] private Slider repr;
        /// <summary>
        /// Taxa de selecao
        /// </summary>
        [SerializeField] private Slider sele;

        /// <summary>
        /// Variavel de tipo view para UI
        /// </summary>
        [SerializeField] private View ui;
        
        /// <summary>
        /// Variavel de tipo GameObject para texto pausa do butao pausa
        /// </summary>
        [SerializeField] private GameObject pauseText;
        /// <summary>
        /// Variavel de tipo GameObject para texto continue do butao pausa
        /// </summary>
        [SerializeField] private GameObject continueText;
        /// <summary>
        /// Variavel de tipo Text para mostrar os erros
        /// </summary>
        [SerializeField] private Text log;

        /// <summary>
        /// Variavel de tipo Map usada para dar reset na textura
        /// </summary>
        private Map map;
        /// <summary>
        /// Variavel do tipo Controller
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
        /// Booleano que vai ser usado para colocar a simulcao em pausa
        /// </summary>
        private bool isPaused;
        /// <summary>
        /// Metodo Start, primeiro metodo a correr quando se inicia a simulacao
        /// </summary>
        private void Start()
        {
            c = new Controller();

            map = GetComponent<Map>();

            isPaused = false;

            pauseText.SetActive(true);
            continueText.SetActive(false);
        }

        /// <summary>
        /// Metodo OnStartClick, corre quando se clica no butao Start
        /// </summary>
        public void OnStartClick()
        {
            args = 
                ToArray
                (xdim.text, ydim.text, swap.value, repr.value, sele.value);
            string result = c.CheckVars(args);
            if (result == null)
            {
                thread = new Thread(StartGame);
                map.CreateTexture
                    (Convert.ToInt32(xdim.text), Convert.ToInt32(ydim.text));
                map.SetSignal(true);
                thread.Start();
            }
            else log.text = result;
        }

        /// <summary>
        /// Metodo ToArray, converte os valores das taxas para strings
        /// </summary>
        /// <param name="x">Posicao em x</param>
        /// <param name="y">Posicao em y</param>
        /// <param name="swap">Valor de taxa de troca</param>
        /// <param name="repr">Valor de taxa de reproducao</param>
        /// <param name="sele">Valor de taxa de selecao</param>
        /// <returns></returns>
        private string[] ToArray(string x, string y, double swap, double repr,
            double sele) => new string[] { x, y, Convert.ToString(swap),
                Convert.ToString(repr), Convert.ToString(sele) };

        /// <summary>
        /// Metodo StartGame, inicia a simulacao
        /// </summary>
        private void StartGame()
        {
            c.StartGame(ui);
        }

        /// <summary>
        /// Metodo OnPauseClick, corre quando se clica no butao Pause
        /// </summary>
        public void OnPauseClick()
        {
            // Verifica se a simulacao esta na pausa
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
        /// Metodo OnStopClick, para a simulacao quando se clica no butao Stop
        /// </summary>
        public void OnStopClick()
        {
            map.SetSignal(false);
            map.ResetTexture();
            thread.Abort();
        }

        /// <summary>
        /// Metodo OnQuitClick, fecha a aplicacao quando se clica no butao Quit
        /// </summary>
        public void OnQuitClick()
        {
            Application.Quit();
        }
    }
}

