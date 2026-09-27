using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawner : Spawner<Crystal>
{
    [SerializeField] protected List<ResourceConfig> ResourceConfigs;

    [SerializeField] protected float MinSpawnDelay = 1f;
    [SerializeField] protected float MaxSpawnDelay = 5f;
    [SerializeField] protected int SpawnObjectCount = 1;
    [SerializeField] private float _minRadius = 15f;
    [SerializeField] private float _maxRadius = 45f;

    private WaitForSeconds _waitForSeconds;
    private Coroutine _spawnCoroutine;

    public void Start()
    {
        StopSpawn();
        _spawnCoroutine = StartCoroutine(SpawnRoutine());
    }

    public void ResetSpawn()
    {
        Reset();
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

    private IEnumerator SpawnRoutine()
    {
        while (enabled)
        {
            _waitForSeconds = new WaitForSeconds((Random.Range(MinSpawnDelay, MaxSpawnDelay)));

            int configIndex = Random.Range(0, ResourceConfigs.Count);

            if (GetCountSpawnedObjects() < SpawnObjectCount)
            {
                Crystal crystal = CreateObject();
                crystal.Init(UserUtils.GetSpawnPosition(_minRadius, _maxRadius), ResourceConfigs[configIndex]);
            }

            yield return _waitForSeconds;
        }
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
}
