using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Hologram : MonoBehaviour, IHologram
{
    [SerializeField] Material _materialHologram;
    [SerializeField] Material _materialHologramFail;
    [SerializeField] Material _materialHologramSuccess;

    private readonly List<MeshRenderer> _renderers = new();
    private BoxCollider _boxCollider;
    private Vector3 _defaultPosition = new();

    private bool _placementAllowed;
    private bool _placed;

    public bool PlacementAllowed => _placementAllowed;
    public bool Placed => _placed;

    public Vector3 Position { get { return transform.position; } set { transform.position = value; } }

    public void Init(Vector3 defaultPosition, float colliderSeze = 5f)
    {
        _defaultPosition = defaultPosition;
        transform.position = _defaultPosition;

        _boxCollider = GetComponent<BoxCollider>();
        _boxCollider.isTrigger = true;
        _boxCollider.center = new Vector3(0, (colliderSeze / 2), 0);
        _boxCollider.size = new Vector3(colliderSeze, colliderSeze, colliderSeze);

        CollectChildRenderers();
        SetMaterialChildren(_materialHologram);
        Hide();
    }

    public void Place()
    {
        _placed = true;
        SetMaterialChildren(_materialHologram);
    }

    public void Show()
    {
        foreach (var renderer in _renderers)
        {
            renderer.enabled = true;
        }
    }

    public void ResetObj()
    {
        SetMaterialChildren(_materialHologram);
        Position = _defaultPosition;
        Hide();
    }

    private void Hide()
    {
        foreach (var renderer in _renderers) 
        {
            renderer.enabled = false;
        }

        _placed = false;
    }

    private void CollectChildRenderers(bool includeInactive = true)
    {
        foreach (Transform child in transform)
        {
            _renderers.AddRange(child.GetComponentsInChildren<MeshRenderer>(includeInactive));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CommandCenter _)) 
        {
            _placementAllowed = false;
            SetMaterialChildren(_materialHologramFail);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out CommandCenter _))
        {
            _placementAllowed = true;
            SetMaterialChildren(_materialHologramSuccess);
        }
    }

    private void SetMaterialChildren(Material material)
    {
        foreach (var renderer in _renderers)
            renderer.material = material;
    }
}
