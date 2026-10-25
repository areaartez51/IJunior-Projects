public interface IBase
{
    public ITaskDistributor TaskDistributor { get; }
    public void StartWork();
}
