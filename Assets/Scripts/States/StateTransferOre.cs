using System;

public class StateTransferOre : IState
{
    private readonly IRequest _context;
    private readonly IUnitStorage _unitStorage;
    private readonly IStorageBase _storageBace;

    private event Action<IRequest> _receivedData;

    public StateTransferOre(IUnitStorage unitStorage, IStorageBase storageBace, IRequest context)
    {
        _unitStorage = unitStorage;
        _storageBace = storageBace;
        _context = context;
    }

    public void Enter(Action<IRequest> receivedData)
    {
        _receivedData = receivedData;
        _storageBace.GetOre(_unitStorage.GiveOre());

        HandleData();
    }

    public void Exit()
    {
        _receivedData = null;
    }

    private void HandleData() => _receivedData?.Invoke(_context);
}
