using UnityEngine;

namespace Platformer
{
    public abstract class HealthView  : MonoBehaviour
    {
        [SerializeField] protected Health Health;

        private void OnEnable() 
        {
            Health.Changed += UpdateView;
        }

        private void OnDisable() 
        {
            Health.Changed -= UpdateView;
        }

        protected abstract void UpdateView(int currentValue, int maxValue);
    }
}