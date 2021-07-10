using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using LP2_RockPaperScissor.UnityApp;
using TMPro;
using System;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI xdim;
    [SerializeField] private TextMeshProUGUI ydim;
    [SerializeField] private Slider swap;
    [SerializeField] private Slider repr;
    [SerializeField] private Slider sele;

    [SerializeField] private View ui;
    
    [SerializeField] private GameObject pauseText;
    [SerializeField] private GameObject continueText;

    private Controller c;
    private string[] args;

    private Thread thread;

    private bool isPaused;

    private void Start()
    {
        c = new Controller();
        isPaused = false;
        pauseText.SetActive(true);
        continueText.SetActive(false);
    }

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

    private string[] ToArray(string x, string y, double swap, double repr,
        double sele) => new string[] { x, y, Convert.ToString(swap),
            Convert.ToString(repr), Convert.ToString(sele) };

    private void StartGame()
    {
        c.StartGame(ui);
    }

    public void OnPauseClick()
    {
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

    public void OnStopClick()
    {
        thread.Abort();
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }
}

