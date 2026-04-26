using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class VampirismSmoothSliderView : VampirismViewLogic
    {
        [SerializeField] private VampirismViewRecover _vampirismViewRecover;

        private Coroutine _coroutine;

        protected override void UpdateView(int maxValue)
        {
            base.UpdateView(maxValue);

            StopMoveCoroutine();
            _vampirismViewRecover.gameObject.SetActive(true);

            _coroutine = StartCoroutine(MoveSliderValue(StartValue, EndValue, maxValue));
        }

        private void StopMoveCoroutine()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        private IEnumerator MoveSliderValue(float startValue, float endValue, float maxTime)
        {
            float time = 0f;
            Slider.value = startValue;

            while (time < maxTime)
            {
                time += Time.deltaTime;
                float stepValue = Mathf.Clamp01(time / maxTime);

                Slider.value = Mathf.Lerp(startValue, endValue, stepValue);
                yield return null;
            }

            _vampirismViewRecover.gameObject.SetActive(false);
            Slider.value = endValue;
        }
    }
}