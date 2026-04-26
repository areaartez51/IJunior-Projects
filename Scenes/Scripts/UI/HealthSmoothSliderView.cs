using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class HealthSmoothSliderView : HealthSliderView
    {
        [SerializeField] private float _smoothSpeed = 2f;
        
        private Coroutine _coroutine;
        private float _currentSliderValue;

        protected override void UpdateView(int currentValue, int maxValue)
        {
            StopMoveCoroutine();

            _currentSliderValue = Slider.value;

            float currentPercentHealth = CalculateCurrentPercentHealth(currentValue, maxValue);

            _coroutine = StartCoroutine(MoveSliderValue(currentPercentHealth));
        }

        private void StopMoveCoroutine()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        private IEnumerator MoveSliderValue(float currentPercentHealth)
        {
            float startTime = Time.time;
            float duration = Mathf.Abs(currentPercentHealth - _currentSliderValue) * _smoothSpeed;
            
            while (Time.time < startTime + duration)
            {
                float stepValue = (Time.time - startTime) / duration;

                Slider.value = Mathf.Lerp(_currentSliderValue, currentPercentHealth, stepValue);  
            
                yield return null;
            }
        }
    }
}