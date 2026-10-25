public interface IRequest
{
    public bool HighPriority { get; }
    public ITask GetTask();
}
