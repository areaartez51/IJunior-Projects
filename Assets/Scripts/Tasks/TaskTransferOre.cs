using System;

public sealed class TaskTransferOre : ITask
{
    private readonly IUnitStorage _unitStorage;
    private readonly IStorageBase _storageBase;


    public TaskTransferOre(IUnitStorage unitStorage, IStorageBase storageBase)
    {
        _unitStorage = unitStorage;
        _storageBase = storageBase;
    }

    public void Execution(IState currentstate, IRequest context, Action<IRequest> receivedData)
    {
        currentstate = new StateTransferOre(_unitStorage, _storageBase, context);
        currentstate.Enter(receivedData);
    }
}
