using System;
using UnityEngine;

public class StateReturnBase : IUnitState
{
    private UnitStorage _unitStorage;
    private BaceStorage _baceStorage;
    private Mover _mover;

    public event Action Executed;

    public StateReturnBase(UnitStorage unitStorage, BaceStorage baceStorage, Mover mover)
    {
        _unitStorage = unitStorage;
        _baceStorage = baceStorage;
        _mover = mover;
    }

    public void Enter()
    {
        _mover.Executed += ChangeState;
        _mover.StartMove(_baceStorage.Position);
    }

    private void ChangeState()
    {
        _mover.Executed -= ChangeState;
        _baceStorage.ReceiveMineral(_unitStorage.TransferOre());
        Executed?.Invoke();
    }
}
