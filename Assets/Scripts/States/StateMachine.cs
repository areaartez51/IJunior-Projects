public class StateMachine
{
    private readonly IListeningReceiver _unit;

    private IState _currentState;

    public StateMachine(IListeningReceiver unit)
    {
        _unit = unit;
    }

    public void Init(IState defaultState = null)
    {
        DefaulteState(defaultState);
    }

    private void DefaulteState(IState defaultState = null)
    {
        if (defaultState == null)
            _currentState = new StateWaite(_unit);
        else
            _currentState = defaultState;

        _currentState.Enter(NextTask);
    }

    private void NextTask(IRequest context)
    {
        ITask task = context.GetTask();
        
        if (task == null) 
            DefaulteState();
        else
            Transition(task, context);
    }

    private void Transition(ITask task, IRequest context)
    {
        _currentState?.Exit();
        task.Execution(_currentState, context, NextTask);
    }
}
