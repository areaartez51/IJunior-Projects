using System.Collections;
using UnityEngine;

public class StateHarassment : MonoBehaviour, EnemyStateMachine
{
    private EnemyMover _enemyMover;
    private Coroutine _coroutine;

    Vector2 _target;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }

    public void Enter()
    {
        _coroutine = StartCoroutine(TartgetMove());
    }

    private IEnumerator TartgetMove()
    {
        while (enabled)
        {
            _enemyMover.Move(_target.x);

            yield return null;
        }
    }

    public void Exit()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    public void SetTargetPosition(Vector2 target)
    {
        _target = target;
    }
}
