using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Mineral : MonoBehaviour
{
    private MeshRenderer _renderer;
    private int _price = 0;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        _renderer.material = new Material(Shader.Find("Standard"));
    }

    public void Init(Material material, int price)
    {
        _renderer.material = material;
        _price = price;
    }

    public int Price => _price;
}
