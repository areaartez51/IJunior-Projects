using System;
using Unity.VisualScripting;

public class StateMine : State, IUnitState
{
    private IResource _crystal;
    private UnitMiner _unitMiner;

    public event Action Executed;

    public StateMine(IResource crystal, UnitMiner unitMiner)
    {
        _crystal = crystal;
        _unitMiner = unitMiner;
    }

    public void Enter()
    {
        _unitMiner.Executed += ChangeState;
        _unitMiner.StartMine(_crystal);
    }

    private void ChangeState()
    {
        _unitMiner.Executed -= ChangeState;
        Executed?.Invoke();
    }
}