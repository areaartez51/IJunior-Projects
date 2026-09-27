using System;
using UnityEngine;

public class StateMove : IUnitState
{
    private Vector3 _targetPosition;

    private Coroutine _coroutine;
    private Mover _mover;

    public event Action Executed;

    public StateMove(Vector3 targetPosition, Mover mover)
    {
        _targetPosition = targetPosition;
        _mover = mover;
    }

    public void Enter()
    {
        _mover.Executed += ChangeState;
        _mover.StartMove(_targetPosition);
    }

    private void ChangeState()
    {
        _mover.Executed -= ChangeState;
        Executed?.Invoke();
    }
}
