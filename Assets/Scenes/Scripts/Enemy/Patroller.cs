using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Patroller : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;

    private EnemyMover _enemyMover;

    private int _currentWayPoint = 0;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }

    public void Patrolling()
    {
        StartCoroutine(TartgetMove());
    }

    private IEnumerator TartgetMove()
    {
        while (enabled)
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
