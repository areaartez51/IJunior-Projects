using UnityEngine;

namespace Platformer
{
    public abstract class HealthView  : MonoBehaviour
    {
        [SerializeField] protected Health Health;

        private void OnEnable() 
        {
            Health.HealthChanged += UpdateView;
        }

        private void OnDisable() 
        {
            Health.HealthChanged -= UpdateView;
        }

        protected abstract void UpdateView(int currentValue, int maxValue);
    }
}