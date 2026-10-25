using System;
using UnityEngine;

public class StateBuild : IState
{
    private readonly IRequest _context;
    private readonly IBaseFactory _baseFactory;
    private readonly Vector3 _position;

    private readonly ITaskReceiver _unit;

    private event Action<IRequest> _receivedData;

    public StateBuild(IBaseFactory baseFactory, Vector3 position, ITaskReceiver unit, IRequest context)
    {
        _context = context;
        _baseFactory = baseFactory;
        _position = position;
        _unit = unit;
    }

    public void Enter(Action<IRequest> receivedData)
    {
        _receivedData = receivedData;
        _baseFactory.Spawn(_position, StartWork);
    }

    public void Exit()
    {
        _receivedData = null;
    }

    private void StartWork(IBase bace)
    {
        bace.StartWork();

        _unit.ChangeTaskDistributor(bace.TaskDistributor);
        HandleData();
    }

    private void HandleData() => _receivedData?.Invoke(_context);
}
