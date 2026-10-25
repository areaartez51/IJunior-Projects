using System;
using System.Collections;
using UnityEngine;

public class UnitMiner : MonoBehaviour, IUnitMiner
{
    private float _timeMining;

    public void Init(float timeMining)
    {
        _timeMining = timeMining;
    }

    private Coroutine _coroutine;

    public void TryStartMine(ICrystal crystal, IUnitStorage unitStorage, Action Executed)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Mining(crystal, unitStorage, Executed));
    }

    private IEnumerator Mining(ICrystal crystal, IUnitStorage unitStorage, Action Executed)
    {
        yield return new WaitForSeconds(_timeMining);

        crystal.ReturnToPool();

        unitStorage.ReceiveOrePiece(crystal.GetConfig());

        Executed?.Invoke();
    }
}
