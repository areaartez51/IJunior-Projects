using System;
using System.Collections;
using UnityEngine;

public abstract class TimedPoolableObject : MonoBehaviour, IPoolableObject
{
    [SerializeField] private float _lifeTime = 5f;

    private Coroutine _coroutine;
    private WaitForSeconds _waitForSeconds;

    public event Action<IPoolableObject> Destroyer;

    protected virtual void OnEnable()
    {
        RestartLifetime();
    }

    protected virtual void OnDisable()
    {
        StopLifeTime();
    }

    protected virtual void RestartLifetime()
    {
        StopLifeTime();
        _coroutine = StartCoroutine(LifetimeRoutine());
    }

    protected virtual void StopLifeTime()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator LifetimeRoutine()
    {
        _waitForSeconds = new WaitForSeconds(_lifeTime);
        yield return _waitForSeconds;
        ReturnToPool();
    }

    public void ReturnToPool()
    {
        Destroyer?.Invoke(this);
    }
}