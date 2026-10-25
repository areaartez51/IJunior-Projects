using System;

public interface ITask
{
    public void Execution(IState currentstate, IRequest context, Action<IRequest> receivedData);
}
