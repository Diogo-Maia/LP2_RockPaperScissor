using UnityEngine;
using UnityEngine.UI;

namespace LP2_RockPaperScissor.UnityApp
{
    /// <summary>
    /// Classe SliderValueToText, implementa MonoBehaviour, vai adicionar uma
    /// legenda com os valores a cada um dos sliders
    /// </summary>
    public class SliderValueToText : MonoBehaviour
    {
        /// <summary>
        /// Slider
        /// </summary>
        [SerializeField]
        private Slider sliderUI;

        /// <summary>
        /// Texto com o valor do slider
        /// </summary>
        private TMPro.TextMeshProUGUI textSliderValue;
        private string sliderMessage;

        /// <summary>
        /// Metodo Start, altera texto de cada valor selecionado no slider
        /// </summary>
        void Start()
        {
            textSliderValue = GetComponent<TMPro.TextMeshProUGUI>();
            ShowSliderValue();
        }

        /// <summary>
        /// Metodo ShowSliderValue, desenha o texto da legenda
        /// </summary>
        public void ShowSliderValue()
        {
            sliderMessage = " " + sliderUI.value;
            textSliderValue.text = sliderMessage;
        }
    }
}
