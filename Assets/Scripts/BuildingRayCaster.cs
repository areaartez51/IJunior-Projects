using UnityEngine;

public class BuildingRayCaster
{
    private readonly Camera _camera;
    private readonly LayerMask _mask;
    private readonly float _length;

    public BuildingRayCaster(Camera camera, LayerMask mask, float length = 1000f)
    {
        _camera = camera; 
        _mask = mask;
        _length = length;
    }

    public bool TryPushRay(Vector2 screenPos, out IBuil build)
    {
        build = null;
        Ray ray = _camera.ScreenPointToRay(screenPos);

        if (!Physics.Raycast(ray, out var hit, _length, _mask))
            return false;

        return hit.transform.TryGetComponent(out build);
    }
}
