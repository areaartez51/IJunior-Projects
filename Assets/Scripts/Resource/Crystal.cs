using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(Rigidbody))]
public class Crystal : MonoBehaviour, IConfigSource, ICrystal, ISearchable
{
    private MeshRenderer _renderer;
    private ResourceConfig _resourceConfig;

    public Vector3 Position => transform.position;

    public event Action<IPoolable> Destroyer;
    public event Action<ISearchable> Freedom;

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
    }

    public ResourceConfig GetConfig() => _resourceConfig;

    public void ReturnToPool()
    {
        Freedom?.Invoke(this);
        Destroyer?.Invoke(this);
    }
}
