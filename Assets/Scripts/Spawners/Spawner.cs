using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : MonoBehaviour, IPoolable
{
    [SerializeField] protected T Prefab;
    [SerializeField] protected int PoolObjectCount = 1;

    protected PoolObject<T> PoolObject;

    private void Awake()
    {
        PoolObject = new PoolObject<T>(Prefab);
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
