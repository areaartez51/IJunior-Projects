public interface IUnitTools
{
    public IMover Mover { get; }
    public IUnitMiner Miner { get; }
    public IUnitStorage Storage { get; }
    public ITaskDistributor TaskDistributor { get; }
}
