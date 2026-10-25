using System;

public sealed class TaskMine : ITask
{
    private readonly ICrystal _crystal;
    private readonly IUnitMiner _unitMiner;
    private readonly IUnitStorage _storage;

    public TaskMine(ICrystal crystal, IUnitMiner unitMiner, IUnitStorage storage)
    {            
        _crystal = crystal;
        _unitMiner = unitMiner;
        _storage = storage;
    }               

    public void Execution(IState currentstate, IRequest context, Action<IRequest> receivedData)
    {
        currentstate = new StateMine(_crystal, _unitMiner, _storage, context);
        currentstate.Enter(receivedData);
    }
}
