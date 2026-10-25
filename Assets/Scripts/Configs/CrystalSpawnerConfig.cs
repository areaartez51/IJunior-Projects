using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CrystalSpawnerConfig", menuName = "Configs/CrystalSpawnerConfig")]
public class CrystalSpawnerConfig : ScriptableObject
{
    [SerializeField] List<ResourceConfig> _resourceConfig = new();

    [SerializeField] private float _minSpawnDelay = 0.1f;
    [SerializeField] private float _maxSpawnDelay = 1f;
    [SerializeField] private int _spawnObjectCount = 1;
    [SerializeField] private float _minRadius = 15f;
    [SerializeField] private float _maxRadius = 35f;

    public List<ResourceConfig> ResourceConfig => _resourceConfig;

    public float MinSpawnDelay => _minSpawnDelay;
    public float MaxSpawnDelay => _maxSpawnDelay;
    public int SpawnObjectCount => _spawnObjectCount;
    public float MinRadius => _minRadius;
    public float MaxRadius => _maxRadius;
}
