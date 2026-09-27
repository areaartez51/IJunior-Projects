using System.Collections.Generic;
using System;

public class StateMachine
{
    private IUnitState _currentState;
    private StateWaite _waiteState;

    private Queue<IUnitState> _states;

    public event Action TaskExecuted;

    public StateMachine()
    {
        _waiteState = new StateWaite();

    }

    public void NextState()
    {
        _currentState.Executed -= NextState;

        Transition();
    }

    public void GetTask(Queue<IUnitState> states)
    {
        _states = states;
        Transition();
    }

    private void Transition()
    {
        if (_states.Count > 0)
        {
            _currentState = _states.Dequeue();
            _currentState.Executed += NextState;
            _currentState.Enter();
        }
        else 
        {
            TaskExecuted?.Invoke();
        }
    }
}
