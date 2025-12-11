using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class StatePatrolling : MonoBehaviour, IState
{
    [SerializeField] private Transform[] _wayPoints;

    private EnemyMover _enemyMover;
    private Coroutine _coroutine;

    private int _currentWayPoint = 0;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }

    public void Enter()
    {
        _coroutine = StartCoroutine(TartgetMove(true));
    }

    public void Exit()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator TartgetMove(bool isWork)
    {
        while (isWork)
        {
            ChangeTargetPoint();
            _enemyMover.Move(_wayPoints[_currentWayPoint].position.x);

            yield return null;
        }
    }

    private void ChangeTargetPoint()
    {
        if (transform.position.x == _wayPoints[_currentWayPoint].position.x)
        {
            _currentWayPoint = (_currentWayPoint + 1) % _wayPoints.Length;
        }
    }
}
