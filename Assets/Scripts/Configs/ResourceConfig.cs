using UnityEngine;

[CreateAssetMenu(fileName = "ResourceConfig", menuName = "Configs/Resource", order = 51)]
public class ResourceConfig : ScriptableObject
{
    [SerializeField] private PriceConfig _priceConfig;

    [SerializeField] private Material _freeMaterial;

    public Material FreeMaterial => _freeMaterial;

    public PriceConfig PriceConfig { get { return _priceConfig; } set { _priceConfig = value; } }
}
