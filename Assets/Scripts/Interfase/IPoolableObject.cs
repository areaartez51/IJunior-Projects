using System;

public interface IPoolableObject
{
    public event Action<IPoolableObject> Destroyer;
    public void ReturnToPool();
}
