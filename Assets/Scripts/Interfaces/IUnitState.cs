using System;

public interface IUnitState
{
    public event Action Executed;

    public void Enter();
}