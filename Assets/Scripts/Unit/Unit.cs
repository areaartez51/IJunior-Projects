using System;
using UnityEngine;

[RequireComponent(typeof(Mover), typeof(UnitMiner))]
public class Unit : MonoBehaviour, IPoolable, ITaskReceiver, IListeningReceiver
{
    [SerializeField] private Mineral _mineral;

    private Mover _mover;
    private UnitMiner _unitMiner;
    private UnitStorage _unitStorage;

    private UnitTools _unitTools;

    private ITaskDistributor _taskDistributor;

    private int _price;

    private StateMachine _stateMachine;

    public int Price => _price;

    public event Action<IPoolable> Destroyer;
    public event Action<IRequest> Listener;

    public void Init(UnitConfig unitConfig, ITaskDistributor taskDistributor)
    {
        _unitMiner = GetComponent<UnitMiner>();
        _mover = GetComponent<Mover>();

        _price = unitConfig.Price;

        _mover.Init(unitConfig.Speed, unitConfig.ArrivalThreshold);
        _unitMiner.Init(unitConfig.TimeMining);
        _unitStorage = new(_mineral);

        _taskDistributor = taskDistributor;

        _unitTools = new UnitTools(_mover, _unitMiner, _unitStorage);

        _stateMachine = new StateMachine(this);
        _stateMachine.Init();
    }

    public IUnitTools GetUnitTools()
    {
        return _unitTools;
    }

    public void ReceiveTask(IRequest request)
    {
        Listener?.Invoke(request);
    }

    public void ListeningReceiver(Action<IRequest> listener)
    {
        Listener = listener;
        _taskDistributor.AddListener(this);
    }

    public void ReturnToPool() => Destroyer?.Invoke(this);

    public void ChangeTaskDistributor(ITaskDistributor taskDistributor)
    {
        _taskDistributor = taskDistributor;
    }
}
