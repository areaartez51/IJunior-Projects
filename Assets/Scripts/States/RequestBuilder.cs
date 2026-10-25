using System.Collections.Generic;
using UnityEngine;

public class RequestBuilder
{
    private readonly Vector3 _positionBase;
    private readonly IStorageBase _storageBase;
    private readonly IBaseFactory _baseFactory;

    private IMover _mover;
    private IUnitMiner _unitMiner;
    private IUnitStorage _unitStorage;

    private ITaskReceiver _unit;

    public RequestBuilder(IStorageBase storageBase, IBaseFactory baseFactory, Vector3 positionBase)
    {
        _storageBase = storageBase;
        _baseFactory = baseFactory;
        _positionBase = positionBase;
    }

    public void PrepareMutableData(ITaskReceiver unit)
    {
        _unit = unit;

        IUnitTools unitTools = unit.GetUnitTools();

        _mover = unitTools.Mover;
        _unitMiner = unitTools.Miner;
        _unitStorage = unitTools.Storage;
    }

    public Request Create(ICrystal mineObj)
    {
        Queue<ITask> _tasks = new();

        _tasks.Enqueue(new TaskMove(_mover, mineObj.Position));
        _tasks.Enqueue(new TaskMine(mineObj, _unitMiner, _unitStorage));
        _tasks.Enqueue(new TaskMove(_mover, _positionBase));
        _tasks.Enqueue(new TaskTransferOre(_unitStorage, _storageBase));

        return new Request(_tasks);
    }

    public Request Create(IHologram hologram)
    {
        Queue<ITask> _tasks = new();

        _tasks.Enqueue(new TaskMove(_mover, hologram.Position));
        _tasks.Enqueue(new TaskBuild(_baseFactory, _unit, hologram));

        return new Request(_tasks);
    }
}
