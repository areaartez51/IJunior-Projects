using UnityEngine;

[CreateAssetMenu(fileName = "SceneConfig", menuName = "Configs/SceneConfig")]
public class SceneConfig : ScriptableObject
{
    [SerializeField] private BaseConfig _baceConfig;
    [SerializeField] private BaceFactoryConfig _baceFactoryConfig;
    [SerializeField] private RadarConfig _radarConfig;
    [SerializeField] private UnitConfig _unitConfig;
    [SerializeField] private CrystalSpawnerConfig _crystalSpawnerConfig;

    public BaseConfig BaceConfig => _baceConfig;
    public BaceFactoryConfig BaceFactoryConfig => _baceFactoryConfig;
    public RadarConfig RadarConfig => _radarConfig;
    public UnitConfig UnitConfig => _unitConfig;
    public CrystalSpawnerConfig CrystalSpawnerConfig => _crystalSpawnerConfig;
}
