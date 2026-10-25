using UnityEngine;

public class InputManager
{
    private IHologram _hologram;
    private IBuil _build;

    public void SetPosition(Vector3 point)
    {
        if(_hologram != null)
            _hologram.Position = point;
    }

    public void GiveBuild(IBuil build)
    {
        _build = build;

        if (_hologram == null)
        {
            _hologram = _build.GetHologram();
        }
        else
        {
            _hologram.ResetObj();
            _hologram = null;
        }
    }

    public void PlaceBuild()
    {
        if (_hologram != null)
        {
            if (_hologram.PlacementAllowed)
            {
                _hologram.Place();
                _hologram = null;
            }
        }
    }
}
