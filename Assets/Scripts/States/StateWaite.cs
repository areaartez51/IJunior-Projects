using System;

public class StateWaite : IState
{
    private readonly IListeningReceiver _unit;

    private event Action<IRequest> _receivedData;

    public StateWaite(IListeningReceiver unit) 
    {
        _unit = unit; 
    }

    public void Enter(Action<IRequest> receivedData)
    {
        _receivedData = receivedData;
        _unit.ListeningReceiver(HandleData);
    }

    public void Exit()
    {
        _receivedData = null;
    }

    private void HandleData(IRequest context) => _receivedData?.Invoke(context);
}