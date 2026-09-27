using System.Collections.Generic;

public class StateMachineFactory
{
    private UnitStorage _unitStorage;
    private BaceStorage _baceStorage;
    private Mover _mover;
    private UnitMiner _unitMiner;

    public StateMachineFactory (UnitStorage unitStorage, BaceStorage baceStorage, Mover mover, UnitMiner unitMiner)
    {
        _unitStorage = unitStorage;
        _baceStorage = baceStorage;
        _mover = mover;
        _unitMiner = unitMiner;
    }

    public Queue<IUnitState> CreateTask<T>(T obj) where T : ISearchable
    {
        var states = new Queue<IUnitState>();

        if (obj is IResource mineral)
        {
            states.Enqueue(new StateMove(mineral.Position, _mover));
            states.Enqueue(new StateMine(mineral, _unitMiner));
            states.Enqueue(new StateReturnBase(_unitStorage, _baceStorage, _mover));
        }

        return states;
    }
}
