using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using LP2_RockPaperScissor.UnityApp;
using TMPro;
using System;

/// <summary>
/// Classe Buttons Manager, implementa MonoBehaviour
/// </summary>
public class ButtonsManager : MonoBehaviour
{
    /// <summary>
    /// Dimensão horizontal da grelha de simulação
    /// </summary>
    [SerializeField] private TextMeshProUGUI xdim;
    /// <summary>
    /// Dimensão vertical da grelha de simulação
    /// </summary>
    [SerializeField] private TextMeshProUGUI ydim;
    /// <summary>
    /// Taxa de troca
    /// </summary>
    [SerializeField] private Slider swap;
    /// <summary>
    /// Taxa de reprodução
    /// </summary>
    [SerializeField] private Slider repr;
    /// <summary>
    /// Taxa de seleção
    /// </summary>
    [SerializeField] private Slider sele;

    /// <summary>
    /// Variável de tipo view para UI
    /// </summary>
    [SerializeField] private View ui;
    
    /// <summary>
    /// Variável de tipo GameObject para texto pausa do butão pausa
    /// </summary>
    [SerializeField] private GameObject pauseText;
    /// <summary>
    /// Variável de tipo GameObject para texto continue do butão pausa
    /// </summary>
    [SerializeField] private GameObject continueText;

    /// <summary>
    /// Variável do tipo Controller
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
    /// Booleano que vai ser usado para colocar a simulção em pausa
    /// </summary>
    private bool isPaused;

    /// <summary>
    /// Método Start, primeiro método a correr quando se inicia a simulação
    /// </summary>
    private void Start()
    {
        c = new Controller();
        isPaused = false;
        pauseText.SetActive(true);
        continueText.SetActive(false);
    }

    /// <summary>
    /// Método OnStartClick, corre quando se clica no butão Start
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
    /// Método ToArray, converte os valores das taxas para strings
    /// </summary>
    /// <param name="x">Posição em x</param>
    /// <param name="y">Posição em y</param>
    /// <param name="swap">Valor de taxa de troca</param>
    /// <param name="repr">Valor de taxa de reprodução</param>
    /// <param name="sele">Valor de taxa de seleção</param>
    /// <returns></returns>
    private string[] ToArray(string x, string y, double swap, double repr,
        double sele) => new string[] { x, y, Convert.ToString(swap),
            Convert.ToString(repr), Convert.ToString(sele) };

    /// <summary>
    /// Método StartGame, inicia a simulação
    /// </summary>
    private void StartGame()
    {
        c.StartGame(ui);
    }

    /// <summary>
    /// Método OnPauseClick, corre quando se clica no butão Pause
    /// </summary>
    public void OnPauseClick()
    {
        // Verifica se a simulação está pausada
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
    /// Método OnStopClick, para a simulação quando se clica no butão Stop
    /// </summary>
    public void OnStopClick()
    {
        thread.Abort();
    }

    /// <summary>
    /// Método OnQuitClick, fecha a aplicação quando se clica no butão Quit
    /// </summary>
    public void OnQuitClick()
    {
        Application.Quit();
    }
}

