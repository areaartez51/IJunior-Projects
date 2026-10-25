using UnityEngine;

[CreateAssetMenu(fileName = "UnitConfig", menuName = "Configs/UnitConfig")]
public class UnitConfig : ScriptableObject
{
    [SerializeField] private int _price = 3;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _arrivalThreshold = 0.1f;
    [SerializeField] private float _timeMining;

    public int Price => _price;
    public float Speed => _speed;
    public float ArrivalThreshold => _arrivalThreshold;
    public float TimeMining => _timeMining;
}
