using System;
using System.Collections;
using UnityEngine;

public class UnitsFactory : Spawner<Unit>
{
    private ITaskDistributor _tasker;

    private bool _isBuilding;

    public bool IsBuilding => _isBuilding;

    private UnitConfig _unitConfig;

    private Coroutine _spawnCoroutine;

    public void Init(UnitConfig unitConfig, ITaskDistributor tasker)
    {
        _tasker = tasker;
        _unitConfig = unitConfig;
    }

    public void StartSpawn(Transform transform, int startCount, Action<Unit> IsBuilded = null)
    {
        for (int i = 0; i < startCount; i++)
        {
            Unit unit = CreateObject();

            unit.transform.position = transform.position;

            unit.Init(_unitConfig, _tasker);

            IsBuilded?.Invoke(unit);
        }
    }

    public void Spawn(Transform transform, Action<Unit> IsBuilded = null, int count = 3, float timeBuilding = 3f)
    {
        _spawnCoroutine = StartCoroutine(BuildingUnit(transform.position, count, timeBuilding, IsBuilded));
    }

    protected override Unit CreateObject()
    {
        Unit unit = PoolObject.GetObject();

        unit.Destroyer += ObjectRequestedReturn;

        return unit;
    }

    protected override void ObjectRequestedReturn(IPoolable unit)
    {
        unit.Destroyer -= ObjectRequestedReturn;
        PoolObject.ReturnPoolObject((Unit)unit);
    }

    private IEnumerator BuildingUnit(Vector3 position, int count, float timeBuilding, Action<Unit> IsBuilded = null)
    {
        for (int i = 0; i < count; i++)
        {
            _isBuilding = true;

            yield return new WaitForSeconds(timeBuilding);

            _isBuilding = false;

            Unit unit = CreateObject();

            unit.transform.position = position;

            unit.Init(_unitConfig, _tasker);

            IsBuilded?.Invoke(unit);
        }
    }
}
