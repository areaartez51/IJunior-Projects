using System;
using UnityEngine;

public class StateMove : IState
{
    private readonly Vector3 _position;
    private readonly IMover _mover;
    private readonly IRequest _context;

    private event Action<IRequest> _receivedData;

    public StateMove(IMover mover, Vector3 position, IRequest context)
    {
        _mover = mover;
        _position = position;
        _context = context;
    }

    public void Enter(Action<IRequest> receivedData)
    {
        _receivedData = receivedData;
        _mover.StartMove(_position, HandleData);
    }

    public void Exit()
    {
        _receivedData = null;
    }

    private void HandleData() => _receivedData?.Invoke(_context);
}
