using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthSliderView : HealthView
    {
        [SerializeField] private Slider _slider;

        protected override void UpdateView(int currentValue, int maxValue)
        {
            _slider.value = CalculateCurrentPercentHealth(currentValue, maxValue);
        } 

        private float CalculateCurrentPercentHealth(int currentValue, int maxValue)
        {
            return currentValue / (float)maxValue;
        } 
    }
}