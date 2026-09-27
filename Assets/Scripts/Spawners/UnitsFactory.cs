using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsFactory : Spawner<Unit>
{
    [SerializeField]
    private BaceStorage _baceStorage;

    [SerializeField]
    private float _timeBuilding = 3f;

    [SerializeField]
    private float _radius = 3f;

    private Coroutine _spawnCoroutine;

    public void Spawn(Action<Unit> onSpawned)
    {
        _spawnCoroutine = StartCoroutine(BuildingUnit(onSpawned));
    }

    public List<Unit> StartSpawn(int count = 1)
    {
        List<Unit> units = new List<Unit>();

        for (int i = 0; i < count; i++)
        {
            units.Add(CreateObject());
        }

        return units;
    }

    protected override Unit CreateObject()
    {
        Unit scv = PoolObject.GetObject();
        scv.Init(_baceStorage);
        scv.Destroyer += ObjectRequestedReturn;
        scv.transform.position = UserUtils.GetSpawnPosition(_radius);

        return scv;
    }

    protected override void ObjectRequestedReturn(IPoolable scv)
    {
        scv.Destroyer -= ObjectRequestedReturn;
        PoolObject.ReturnPoolObject((Unit)scv);
    }

    private void OnDisable()
    {
        Reset();
    }

    private IEnumerator BuildingUnit(Action<Unit> onSpawned)
    {
        yield return new WaitForSeconds(_timeBuilding);

        Unit unit = CreateObject();
        onSpawned?.Invoke(unit);
    }
}
