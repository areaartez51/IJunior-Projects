using UnityEngine;

public class TerrainRayCaster
{
    private readonly Camera _camera;
    private readonly LayerMask _mask;
    private readonly float _length;

    public TerrainRayCaster(Camera camera, LayerMask mask, float length = 1000f)
    {
        _camera = camera; 
        _mask = mask; 
        _length = length;
    }

    public bool TryPushRay(Vector2 screenPos, out Vector3 point)
    {
        point = default;
        Ray ray = _camera.ScreenPointToRay(screenPos);

        if (!Physics.Raycast(ray, out var hit, _length, _mask)) 
            return false;
        
        point = hit.point;
        return true;
    }
}
