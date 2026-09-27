using System.Collections.Generic;
using UnityEngine;

public class PoolObject<T> where T : MonoBehaviour, IPoolable
{
    private readonly Queue<T> _freeObjects = new();
    private readonly HashSet<T> _usedObjects = new();
    private T _prefab;

    public int GetCountUsedObjects()
    {
        return _usedObjects.Count;
    }

    public PoolObject(T prefab, int initializeCount = 1)
    {
        _prefab = prefab;

        for (int i = 0; i < initializeCount; i++)
        {
            T obj = Object.Instantiate(_prefab);
            obj.gameObject.SetActive(false);
            _freeObjects.Enqueue(obj);
        }
    }

    public T GetObject()
    {
        T obj;

        if (_freeObjects.Count > 0)
        {
            obj = _freeObjects.Dequeue();
        }
        else
        {
            obj = Object.Instantiate(_prefab);
        }

        obj.gameObject.SetActive(true);
        _usedObjects.Add(obj);
        return obj;
    }

    public void ReturnPoolObject(T obj)
    {
        if (_usedObjects.Remove(obj))
        {
            obj.transform.position = Vector3.zero;
            obj.gameObject.SetActive(false);
            _freeObjects.Enqueue(obj);
        }
    }

    public void ReturnAll()
    {
        foreach (var obj in _usedObjects)
        {
            if (obj != null)
            {
                obj.transform.position = Vector3.zero;
                obj.gameObject.SetActive(false);
            }

            _freeObjects.Enqueue(obj);
        }

        _usedObjects.Clear();
    }
}
