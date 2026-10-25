using UnityEngine;

[CreateAssetMenu(fileName = "BaceFactoryConfig", menuName = "Configs/BaceFactoryConfig")]
public class BaceFactoryConfig : ScriptableObject
{
    [SerializeField] private float _timeBuilding;

    public float TimeBuilding => _timeBuilding;
}
