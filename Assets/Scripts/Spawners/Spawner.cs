using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour, IPoolable
{
    [SerializeField] protected T Prefab;
    [SerializeField] protected PoolObject<T> PoolObject;
    [SerializeField] protected int PoolObjectCount = 1;

    private void Awake()
    {
        PoolObject = new PoolObject<T>(Prefab, PoolObjectCount);
    }

    protected abstract T CreateObject();
    protected abstract void ObjectRequestedReturn(IPoolable prefab);
    protected virtual void Reset()
    {
        PoolObject.ReturnAll();
    }

    protected virtual int GetCountSpawnedObjects()
    {
        return PoolObject.GetCountUsedObjects();
    }
}
