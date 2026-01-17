using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Slider))]

    public class HealthSliderView : HealthView
    {
        protected Slider Slider;

        private void Awake()
        {
            Slider = GetComponent<Slider>();
        }

        protected override void UpdateView(int currentValue, int maxValue)
        {
            Slider.value = CalculateCurrentPercentHealth(currentValue, maxValue);
        }

        protected float CalculateCurrentPercentHealth(int currentValue, int maxValue)
        {
            return currentValue / (float)maxValue;
        } 
    }
}