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

    private Controller c;
    private string[] args;

    private Thread thread;

    private void Start()
    {
        c = new Controller();
        thread = new Thread(StartGame);
    }

    public void OnStartClick()
    {
        args = ToArray(xdim.text, ydim.text, swap.value, repr.value, sele.value);
        string result = c.CheckVars(args);
        if (result == null)
            thread.Start();
        else Debug.Log(result);
    }

    private string[] ToArray(string x, string y, double swap, double repr, double sele)
    {
        return new string[] { x, y, Convert.ToString(swap), Convert.ToString(repr), Convert.ToString(sele) };
    }

    private void StartGame()
    {
        Debug.Log("");
        c.StartGame(ui);
    }
}

