using UnityEngine;

public class Mineral: MonoBehaviour
{
    private MeshRenderer _renderer;
    private int _price;

    public void GiveConfig(Material material, int price)
    {
        _renderer.material = material;
        _price = price;
    }

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        _renderer.material = new Material(Shader.Find("Standard"));
    }

    public int Price => _price;
}
