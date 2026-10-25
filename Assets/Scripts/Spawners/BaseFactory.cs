using System;
using System.Collections;
using UnityEngine;

public class BaseFactory : Spawner<CommandCenter>, IBaseFactory
{
    private Network _network;

    private Coroutine _spawnCoroutine;

    private float _timeBuilding;

    private UnitConfig _unitConfig;
    private BaseConfig _baceConfig;
    private RadarConfig _radarConfig;

    private bool _isBuilding;
    public bool IsBuilding => _isBuilding;

    public void Init(Network network, BaceFactoryConfig baceFactoryConfig, BaseConfig baceConfig, RadarConfig radarConfig, UnitConfig unitConfig)
    {
        _network = network;
        _unitConfig = unitConfig;

        _timeBuilding = baceFactoryConfig.TimeBuilding;
        _baceConfig = baceConfig;
        _radarConfig = radarConfig;
    }

    public void StartSpawn(Transform transform, Action<CommandCenter> IsBuilded = null)
    {
        CommandCenter commandCenter = CreateObject();

        Init(commandCenter, transform.position);

        IsBuilded?.Invoke(commandCenter);
    }

    public void Spawn(Vector3 position, Action<IBase> IsBuilded = null)
    {
        _spawnCoroutine = StartCoroutine(BuildingBace(position, IsBuilded));
    }

    protected override CommandCenter CreateObject()
    {
        CommandCenter commandCenter = PoolObject.GetObject();
        commandCenter.Destroyer += ObjectRequestedReturn;

        return commandCenter;
    }

    protected override void ObjectRequestedReturn(IPoolable obj)
    {
        obj.Destroyer -= ObjectRequestedReturn;
        PoolObject.ReturnPoolObject((CommandCenter)obj);
    }

    private IEnumerator BuildingBace(Vector3 position, Action<CommandCenter> IsBuilded = null)
    {
        _isBuilding = true;

        yield return new WaitForSeconds(_timeBuilding);

        _isBuilding = false;

        CommandCenter commandCenter = CreateObject();

        Init(commandCenter, position);

        IsBuilded?.Invoke(commandCenter);
    }

    private void Init(CommandCenter commandCenter, Vector3 position)
    {
        commandCenter.transform.position = position;
        commandCenter.Init(_network, _unitConfig, _baceConfig, _radarConfig, this);
    }
}
