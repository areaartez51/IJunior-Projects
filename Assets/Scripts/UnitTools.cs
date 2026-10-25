public class UnitTools : IUnitTools
{
    private readonly IMover _mover;
    private readonly IUnitMiner _unitMiner;
    private readonly IUnitStorage _unitStorage;
    private readonly ITaskDistributor _taskDistributor;

    public IMover Mover => _mover;
    public IUnitMiner Miner => _unitMiner;
    public IUnitStorage Storage => _unitStorage;
    public ITaskDistributor TaskDistributor => _taskDistributor;

    public UnitTools(IMover mover, IUnitMiner unitMiner, IUnitStorage unitStorage)
    {
        _mover = mover;
        _unitMiner = unitMiner;
        _unitStorage = unitStorage;
    }
}
