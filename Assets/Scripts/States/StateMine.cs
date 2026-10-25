using System;

public class StateMine: IState
{
    private readonly ICrystal _crystal;
    private readonly IRequest _context;

    private readonly IUnitMiner _unitMiner;
    private readonly IUnitStorage _unitStorage;

    private event Action<IRequest> _receivedData;

    public StateMine(ICrystal crystal, IUnitMiner unitMiner, IUnitStorage unitStorage, IRequest context)
    {
        _crystal = crystal;
        _context = context;

        _unitMiner = unitMiner;
        _unitStorage = unitStorage;
    }

    public void Enter(Action<IRequest> receivedData)
    {
        _receivedData = receivedData;
        _unitMiner.TryStartMine(_crystal, _unitStorage, HandleData);
    }

    public void Exit()
    {
        _receivedData = null;
    }

    private void HandleData() => _receivedData?.Invoke(_context);
}