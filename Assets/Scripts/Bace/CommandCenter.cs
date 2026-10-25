using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(UnitsFactory), typeof(TaskDistributor), typeof(BoxCollider))]
public class CommandCenter : MonoBehaviour, IPoolable, IBuil, IBase
{
    [SerializeField] private Transform _unitSpawnPosition;
    [SerializeField] private Hologram _preafabHologram;
    [SerializeField] private Radar _radar;

    private readonly float _colliderSeze = 5f;

    private UnitsFactory _unitsFactory;
    private TaskDistributor _taskDistributor;
    private DataStorageScanner _dataStorageScanner;
    private BaseStorage _baseStorage;

    private int _unitPrice;
    private int _basePrice;

    private Coroutine _coroutine;

    private BaseConfig _baseConfig;
    private Hologram _hologram;

    private BoxCollider _boxCollider;
    private Rigidbody _rb;

    private IBaseFactory _baseFactory;

    public ITaskDistributor TaskDistributor => _taskDistributor;

    public event Action<IPoolable> Destroyer;

    public void ReturnToPool() => Destroyer?.Invoke(this);

    public void Init(Network network, UnitConfig unitConfig, BaseConfig baseConfig, RadarConfig radarConfig, IBaseFactory baseFactory)
    {
        _boxCollider = GetComponent<BoxCollider>();
        _rb = GetComponent<Rigidbody>();

        _rb.isKinematic = true;

        _boxCollider.isTrigger = true;
        _boxCollider.center = new Vector3(0, (_colliderSeze / 2), 0);
        _boxCollider.size = new Vector3(_colliderSeze, _colliderSeze, _colliderSeze);

        _hologram = Instantiate(_preafabHologram);
        _hologram.Init(transform.position);

        _unitPrice = unitConfig.Price;
        _basePrice = baseConfig.Price;

        _baseStorage = new();
        _dataStorageScanner = new DataStorageScanner();

        _taskDistributor = GetComponent<TaskDistributor>();
        _unitsFactory = GetComponent<UnitsFactory>();

        _baseConfig = baseConfig;
        _baseFactory = baseFactory;

        RequestBuilder requestBuilder = new(_baseStorage, _baseFactory, transform.position);

        _radar.Init(radarConfig, _dataStorageScanner, network);
        _dataStorageScanner.Init(network);
        _taskDistributor.Init(requestBuilder);
        _unitsFactory.Init(unitConfig, _taskDistributor);
    }

    public IHologram GetHologram()
    {
        _hologram.Show();

        return _hologram;
    }

    public void StartWork()
    {
        _taskDistributor.StartWork();
        _coroutine = StartCoroutine(Work());
    }

    public void StartSpawnUnits()
    {
        _unitsFactory.StartSpawn(_unitSpawnPosition, _baseConfig.StartCountUnit, _taskDistributor.Add);
    }

    private IEnumerator Work()
    {
        while (true)
        {
            AddTask();
            Create();
            yield return new WaitForSeconds(1f);
        }
    }

    private void AddTask()
    {
        if (_taskDistributor.CountListeners != _taskDistributor.CountTasks)
        {
            if (_dataStorageScanner.TryGetFreeObj(out ICrystal crystal))
            {
                _taskDistributor.Publish(crystal);
            }
        }
    }

    private void Create()
    {
        if (_hologram.Placed)//Переделать if убрать их реализовать StateMachine
        {
            if(_taskDistributor.CountUnit > 1)
            {
                if (_baseStorage.TryBuy(_basePrice))
                {
                    _taskDistributor.Publish(_hologram);
                }
            }
        }
        else
        {
            if (!_unitsFactory.IsBuilding)
            {
                if (_baseStorage.TryBuy(_unitPrice))
                {
                    _unitsFactory.Spawn(_unitSpawnPosition);
                }
            }
        }
    }
}