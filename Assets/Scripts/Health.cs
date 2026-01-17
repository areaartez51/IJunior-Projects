using System;
using UnityEngine;

namespace UI
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxValue = 10;

        private int _currentValue;

        public event Action<int, int> HealthChanged;

        private void Awake()
        {
            _currentValue = _maxValue;
        }

        private void Start() 
        {
            HealthChanged?.Invoke(_currentValue, _maxValue);
        }

        public void TakeDamage(int damageValue)
        {
            int negativeEffect = -1;

            HealthChanger(negativeEffect* damageValue);
        }

        public void HealItself(int healValue)
        {
            HealthChanger(healValue);
        }

        private void HealthChanger(int value)
        {
            _currentValue = Mathf.Clamp(_currentValue + value, 0, _maxValue);

            HealthChanged?.Invoke(_currentValue, _maxValue);
        }
    }
}
