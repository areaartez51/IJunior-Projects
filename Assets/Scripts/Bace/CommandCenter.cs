using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitsFactory))]
public class CommandCenter : Build
{
    [SerializeField]
    private Radar _rader;

    [SerializeField]
    private int _startCountUnit = 3;

    [SerializeField]
    private BaceStorage _baceStorage;

    [SerializeField]
    private UnitsManager _unitsManager;

    [SerializeField]
    private UnitsFactory _unitsFactory;

    private Queue<ISearchable> _unassembledResource = new Queue<ISearchable>();

    private Coroutine _spawnCoroutine;
    private float _timeUpdate = 1;

    private bool _sceneIsOn;

    private void OnEnable()
    {
        _sceneIsOn = true;
        _rader.UpdateDate += UpdateDate;
    }

    private void OnDisable()
    {
        _sceneIsOn = false;
        _rader.UpdateDate += UpdateDate;
    }

    private void Start()
    {
        StartSpawnUnits();
        _spawnCoroutine = StartCoroutine(UpdateDate());
    }

    private void UpdateDate(List<ISearchable> obj)
    {
        foreach (var mineral in obj)
        {
            _unassembledResource.Enqueue(mineral);
        }
    }

    private void TryGiveTask()
    {
        if (_unassembledResource.Count <= 0)
        {
            return;
        }

        if (_unitsManager.TryGiveTask(_unassembledResource.Dequeue()))
        {
        }
    }

    private void StartSpawnUnits()
    {
        List<Unit> units = _unitsFactory.StartSpawn(_startCountUnit);

        foreach (var unit in units)
        {
            _unitsManager.AddUnitInQueue(unit);
        }
    }

    private IEnumerator UpdateDate()
    {
        while (_sceneIsOn)
        {
            TryGiveTask();
            yield return new WaitForSeconds(_timeUpdate);
        }
    }
}