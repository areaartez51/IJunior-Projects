using System;
using UnityEngine;

namespace Platformer
{
    public class Health : MonoBehaviour, IDamagable
    {
        [SerializeField] private int _maxValue = 100;
        [SerializeField] private int _minValue = 0;

        private int _currentHitPoint;

        public event Action<int, int> HealthChanged;

        private void Awake()
        {
            _currentHitPoint = _maxValue;
        }

        private void Start()
        {
            HealthChanged?.Invoke(_currentHitPoint, _maxValue);
        }

        public void TakeDamage(int damageValue)
        {
            int negativeEffect = -1;

            Change(negativeEffect * Math.Abs(damageValue));

            if (_currentHitPoint <= 0)
                Destroy(gameObject);
        }

        public void AddHitPoint(int healValue)
        {
            Change(Math.Abs(healValue));
        }

        private void Change(int value)
        {
            _currentHitPoint = Mathf.Clamp(_currentHitPoint + value, _minValue, _maxValue);

            HealthChanged?.Invoke(_currentHitPoint, _maxValue);
        }
    }
}

