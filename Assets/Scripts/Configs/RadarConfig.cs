using UnityEngine;

[CreateAssetMenu(fileName = "RadarConfig", menuName = "Configs/RadarConfig")]
public class RadarConfig : ScriptableObject
{
    [SerializeField] private float _timeWork = 1f;
    [SerializeField] private float _timeRecovery = 5f;
    [SerializeField] private float _radiusScane = 1f;

    public float TimeWork => _timeWork;
    public float TimeRecovery => _timeRecovery;
    public float RadiusScane => _radiusScane;
}
