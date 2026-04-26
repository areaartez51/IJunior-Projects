using System.Collections;
using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(EnemyMover))]

    public class StatePatrolling : MonoBehaviour, IState
    {
        [SerializeField] private Point[] _wayPoints;

        private EnemyMover _enemyMover;
        private Coroutine _coroutine;

        private int _currentWayPoint = 0;

        private void Awake()
        {
            _enemyMover = GetComponent<EnemyMover>();
        }

        public void Enter()
        {
            if (gameObject.activeInHierarchy && _wayPoints != null)
            {
                _coroutine = StartCoroutine(TartgetMove());
            }
        }

        public void Exit()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        private IEnumerator TartgetMove()
        {
            while (true)
            {
                ChangeTargetPoint();
                _enemyMover.Move(_wayPoints[_currentWayPoint].transform.position.x);

                yield return null;
            }
        }

        private void ChangeTargetPoint()
        {
            if (transform.position.x == _wayPoints[_currentWayPoint].transform.position.x)
            {
                _currentWayPoint = (_currentWayPoint + 1) % _wayPoints.Length;
            }
        }
    }
}

