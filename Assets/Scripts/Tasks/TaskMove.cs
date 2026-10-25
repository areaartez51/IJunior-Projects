using System;
using UnityEngine;

public sealed class TaskMove : ITask
{
    private readonly IMover _mover;
    private readonly Vector3 _position;

    public TaskMove(IMover mover, Vector3 position)
    {
        _mover = mover;
        _position = position;
    }

    public void Execution(IState currentstate, IRequest context, Action<IRequest> receivedData)
    {
        currentstate = new StateMove(_mover, _position, context);
        currentstate.Enter(receivedData);
    }
}
