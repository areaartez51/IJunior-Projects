using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawner : Spawner<Crystal>
{
    private List<ResourceConfig> _resourceConfig;

    private float _minSpawnDelay;
    private float _maxSpawnDelay;
    private int _spawnObjectCount;
    private float _minRadius;
    private float _maxRadius;

    private Coroutine _spawnCoroutine;

    public void Init(CrystalSpawnerConfig crystalSpawnerConfig)
    {
        _resourceConfig = crystalSpawnerConfig.ResourceConfig;

        _minSpawnDelay = crystalSpawnerConfig.MinSpawnDelay;
        _maxSpawnDelay = crystalSpawnerConfig.MaxSpawnDelay;
        _spawnObjectCount = crystalSpawnerConfig.SpawnObjectCount;
        _minRadius = crystalSpawnerConfig.MinRadius;
        _maxRadius = crystalSpawnerConfig.MaxRadius;
    }

    public void StartSpawn(Action<Crystal> IsSpawned = null)
    {
        StopSpawn();
        _spawnCoroutine = StartCoroutine(SpawnRoutine(IsSpawned));
    }

    public void ResetSpawn()
    {
        Reset();
    }

    protected override Crystal CreateObject()
    {
        Crystal crystal = PoolObject.GetObject();
        crystal.Destroyer += ObjectRequestedReturn;
        return crystal;
    }

    protected override void ObjectRequestedReturn(IPoolable crystal)
    {
        crystal.Destroyer -= ObjectRequestedReturn;
        PoolObject.ReturnPoolObject((Crystal)crystal);
    }

    private void StopSpawn()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }

        Reset();
    }

    private IEnumerator SpawnRoutine(Action<Crystal> IsSpawned = null)
    {
        while (true)
        {
            int configIndex = UnityEngine.Random.Range(0, _resourceConfig.Count);

            if (GetCountSpawnedObjects() < _spawnObjectCount)
            {
                Crystal crystal = CreateObject();
                crystal.Init(UserUtils.GetSpawnPosition(_minRadius, _maxRadius), _resourceConfig[configIndex]);

                IsSpawned?.Invoke(crystal);
            }

            yield return new WaitForSeconds((UnityEngine.Random.Range(_minSpawnDelay, _maxSpawnDelay)));
        }
    }
}
