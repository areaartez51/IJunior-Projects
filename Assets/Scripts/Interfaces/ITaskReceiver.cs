public interface ITaskReceiver
{
    public void ReceiveTask(IRequest request);
    public IUnitTools GetUnitTools();
    public void ChangeTaskDistributor(ITaskDistributor taskDistributor);
}
