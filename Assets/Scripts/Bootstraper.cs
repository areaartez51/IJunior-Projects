using System.Collections.Generic;
using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [SerializeField] private Transform _startSpawnBace;

    [SerializeField] private Camera _camera;

    [SerializeField] private PlayerInputController _prefabPlayerInputController;
    [SerializeField] private BaseFactory _preafabBaceFactory;
    [SerializeField] private CrystalSpawner _preafabCrystalSpawner;

    [SerializeField] private SceneConfig _sceneConfig;

    [SerializeField] private LayerMask TerrainLayerMask;
    [SerializeField] private LayerMask BuildingLayerMask;

    [SerializeField] private List<MonoBehaviour> _sceneObj = new List<MonoBehaviour>();

    private Network _network;
    private BaseFactory _baseFactory;
    private CrystalSpawner _crystalSpawner;
    private PlayerInputController _playerInputController;

    private TerrainRayCaster _terrainRayCaster;
    private BuildingRayCaster _buildingRayCaster;

    private void Awake()
    {
        _baseFactory = Instantiate(_preafabBaceFactory, transform.position, Quaternion.identity);
        _crystalSpawner = Instantiate(_preafabCrystalSpawner, transform.position, Quaternion.identity);
        _playerInputController = Instantiate(_prefabPlayerInputController);

        Init();
    }

    private void Init()
    {
        _network = new();
        _terrainRayCaster = new TerrainRayCaster(_camera, TerrainLayerMask);
        _buildingRayCaster = new BuildingRayCaster(_camera, BuildingLayerMask);

        _playerInputController.Init(_buildingRayCaster, _terrainRayCaster);
        _crystalSpawner.Init(_sceneConfig.CrystalSpawnerConfig);
        _baseFactory.Init(_network, _sceneConfig.BaceFactoryConfig, _sceneConfig.BaceConfig, _sceneConfig.RadarConfig, _sceneConfig.UnitConfig);
    }

    private void Start()
    {
        _crystalSpawner.StartSpawn(_sceneObj.Add);
        _baseFactory.StartSpawn(_startSpawnBace, GetCommandCenter);
    }

    private void GetCommandCenter(CommandCenter commandCenter)
    {
        _sceneObj.Add(commandCenter);

        commandCenter.StartWork();
        commandCenter.StartSpawnUnits();
    }
}
