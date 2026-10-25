using UnityEngine;

public interface IHologram
{
    public bool PlacementAllowed { get; }

    public Vector3 Position { get; set; }

    public void Place();
    public void ResetObj();
}
