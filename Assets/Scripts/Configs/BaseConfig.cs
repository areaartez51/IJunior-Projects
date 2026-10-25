using UnityEngine;

[CreateAssetMenu(fileName = "BaceConfig", menuName = "Configs/BaceConfig")]
public class BaseConfig : ScriptableObject
{
    [SerializeField] private int _price;
    [SerializeField] private int _startCountUnit;
    [SerializeField] private float _startTimeBuilding;

    public int Price => _price;
    public int StartCountUnit => _startCountUnit;
    public float StartTimeBuilding => _startTimeBuilding;
}


