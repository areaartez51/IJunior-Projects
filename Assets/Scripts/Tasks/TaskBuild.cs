using System;

public sealed class TaskBuild : ITask
{
    private readonly IHologram _hologram;
    private readonly IBaseFactory _factory;
    private readonly ITaskReceiver _unit;

    public TaskBuild(IBaseFactory factory, ITaskReceiver unit, IHologram hologram)
    {
        _factory = factory;
        _hologram = hologram;
        _unit = unit;
    }

    public void Execution(IState currentstate, IRequest context, Action<IRequest> receivedData)
    {
        currentstate = new StateBuild(_factory, _hologram.Position, _unit, context);
        _hologram.ResetObj();
        currentstate.Enter(receivedData);
    }
}
