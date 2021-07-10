using UnityEngine;
using UnityEngine.UI;

namespace LP2_RockPaperScissor.UnityApp
{
    public class SliderValueToText : MonoBehaviour
    {
        [SerializeField]
        private Slider sliderUI;

        private TMPro.TextMeshProUGUI textSliderValue;
        private string sliderMessage;

        void Start()
        {
            textSliderValue = GetComponent<TMPro.TextMeshProUGUI>();
            ShowSliderValue();
        }

        public void ShowSliderValue()
        {
            sliderMessage = " " + sliderUI.value;
            textSliderValue.text = sliderMessage;
        }
    }
}
