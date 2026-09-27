using UnityEngine;

[CreateAssetMenu(fileName = "New Resource", menuName = "Resource/Create resource config", order = 51)]
public class ResourceConfig : ScriptableObject
{
    [SerializeField] private Material _freeMaterial;
    [SerializeField] private int _price;

    public Material FreeMaterial => _freeMaterial;
    public int Price => _price;
}
