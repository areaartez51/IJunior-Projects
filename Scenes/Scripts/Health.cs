using System;
using UnityEngine;

namespace Platformer
{
    public class Health : MonoBehaviour, IDamagable
    {
        [SerializeField] private int _maxValue = 100;
        [SerializeField] private int _minValue = 0;

        [SerializeField] private int _currentHitPoint;

        public event Action<int, int> Changed;

        private void Awake()
        {
            _currentHitPoint = _maxValue;
        }

        private void Start()
        {
            Changed?.Invoke(_currentHitPoint, _maxValue);
        }

        public void TakeDamage(int damageValue)
        {
            int negativeEffect = -1;

            Change(negativeEffect * Math.Abs(damageValue));

            if (_currentHitPoint <= 0)
                Destroy(gameObject);
        }

        public void TakeHeal(int healValue)
        {
            Change(Math.Abs(healValue));
        }

        private void Change(int value)
        {
            _currentHitPoint = Mathf.Clamp(_currentHitPoint + value, _minValue, _maxValue);

            Changed?.Invoke(_currentHitPoint, _maxValue);
        }
    }
}

