using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(Rigidbody))]
public class Crystal : MonoBehaviour, IResource
{
    private MeshRenderer _renderer;
    private ResourceConfig _resourceConfig;

    private int _price = 0;

    public Vector3 Position => transform.position;

    public event Action<IPoolable> Destroyer;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>(); 
        _renderer.material = new Material(Shader.Find("Standard"));
    }

    public void Init(Vector3 startPosition, ResourceConfig resourceConfig)
    {
        transform.position = startPosition;
        _resourceConfig = resourceConfig;

        _renderer.material = resourceConfig.FreeMaterial;
        _price = resourceConfig.Price;
    }

    public ResourceConfig GetOrePiece() => _resourceConfig;

    public void ReturnToPool() => Destroyer?.Invoke(this);
}
