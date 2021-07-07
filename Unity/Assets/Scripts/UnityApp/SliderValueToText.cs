using UnityEngine;
using UnityEngine.UI;

namespace LP2_RockPaperScissor.UnityApp
{
    public class SliderValueToText : MonoBehaviour
    {
        [SerializeField]
        private Slider sliderUI;

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
}
