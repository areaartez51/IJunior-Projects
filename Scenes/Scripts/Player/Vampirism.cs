using System;
using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class Vampirism : MonoBehaviour
    {
        [SerializeField] private NearestEnemyDetector _nearestEnemyDetector;
        [SerializeField] private int _healthDose = 1;
        [SerializeField] private int _timeWorkSkill = 6;
        [SerializeField] private int _cooldownSkill = 4;

        private Coroutine _coroutine;
        private InputReader _inputReader;
        private Enemy _target;

        private bool _isWork = false;
        private bool _isCooldown = false;

        public event Action<int, int> Initialized;
        public event Action<int> ChangedStatusSkill;
        public event Action<int> UsedVampirism;

        private void Awake()
        {
            _inputReader = GetComponent<InputReader>();
            Initialized?.Invoke(_timeWorkSkill, _cooldownSkill);
        }

        private void OnEnable()
        {
            _inputReader.SpellActivated += UseSkill;
            _nearestEnemyDetector.NewEnemyAppeared += DefineGoal;
        }

        private void OnDisable()
        {
            _inputReader.SpellActivated -= UseSkill;
            _nearestEnemyDetector.NewEnemyAppeared -= DefineGoal;
        }

        private void DefineGoal(Enemy enemy)
        {
            _target = enemy;
        }

        private void UseSkill()
        {
            if (!_isCooldown && !_isWork)
            {
                _coroutine = StartCoroutine(StartSkill());
            }
        }

        private IEnumerator StartSkill()
        {
            _isWork = true;
            _nearestEnemyDetector.gameObject.SetActive(_isWork);

            int time = _timeWorkSkill;

            WaitForSeconds wait = new WaitForSeconds(1f);

            ChangedStatusSkill?.Invoke(_timeWorkSkill);

            while (time > 0)
            {
                SuckOutHp();

                UsedVampirism?.Invoke(_healthDose);

                time--;

                yield return wait;
            }

            _isWork = false;
            _nearestEnemyDetector.gameObject.SetActive(_isWork);

            StartCoroutine(RecoverSkill());
        }

        private IEnumerator RecoverSkill()
        {
            _isCooldown = true;

            int time = _cooldownSkill;

            WaitForSeconds wait = new WaitForSeconds(1f);

            ChangedStatusSkill?.Invoke(_cooldownSkill);

            while (time > 0)
            {
                time--;

                yield return wait;
            }

            _isCooldown = false;
        }

        private void SuckOutHp()
        {
            if (_target != null)
            {
                _target.TakeDamage(_healthDose);
            }
        }
    }
}

