using UnityEngine;

public interface ICrystal: IPoolable, ISearchable, IConfigSource
{
    public Vector3 Position { get; }
}
