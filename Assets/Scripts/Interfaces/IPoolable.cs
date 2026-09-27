using System;

public interface IPoolable
{
    public event Action<IPoolable> Destroyer;

    public void ReturnToPool();
}
