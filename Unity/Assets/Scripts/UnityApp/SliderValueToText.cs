using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderValueToText : MonoBehaviour
{
    public Slider sliderUI;
    private TMPro.TextMeshProUGUI textSliderValue;

    void Start()
    {
        textSliderValue = GetComponent<TMPro.TextMeshProUGUI>();
        ShowSliderValue();
    }

    public void ShowSliderValue()
    {
        string sliderMessage = " " + sliderUI.value;
        textSliderValue.text = sliderMessage;
    }
}