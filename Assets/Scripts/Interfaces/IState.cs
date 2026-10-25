using System;

public interface IState
{
    public void Enter(Action<IRequest> receivedData);
    public void Exit();
}