using UnityEngine;

public interface IResource : ISearchable, IPoolable
{
    public ResourceConfig GetOrePiece();
}
