using System;
using UnityEditor.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Mover), typeof(UnitMiner))]
public class Unit : MonoBehaviour, IPoolable
{
    [SerializeField]
    private UnitStorage _unitStorage;

    private Mover _mover;
    private UnitMiner _unitMiner;

    private StateMachineFactory stateMachineFactory;

    private StateMachine _stateMachine = new StateMachine();

    public event Action<Unit> FreedomFromWork;

    public event Action<IPoolable> Destroyer;

    public void Init(BaceStorage baceStorage)
    {
        stateMachineFactory = new StateMachineFactory(_unitStorage, baceStorage, _mover, _unitMiner);
    }

    public void GetTask(ISearchable obj)
    {
        _stateMachine.TaskExecuted += EndWork;
        _stateMachine.GetTask(stateMachineFactory.CreateTask(obj));
    }

    public void ReturnToPool() => Destroyer?.Invoke(this);

    private void Awake()
    {
        _unitMiner = GetComponent<UnitMiner>();
        _mover = GetComponent<Mover>();
    }

    private void EndWork()
    {
        _stateMachine.TaskExecuted -= EndWork;
        FreedomFromWork?.Invoke(this);
    }
}
