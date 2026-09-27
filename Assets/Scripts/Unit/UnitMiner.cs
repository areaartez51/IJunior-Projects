using System;
using System.Collections;
using UnityEngine;

public class UnitMiner : MonoBehaviour
{
    [SerializeField] private float _timeMining;
    [SerializeField] private UnitStorage _unitStorage;

    private Coroutine _coroutine;

    public event Action Executed;

    public void StartMine(IResource crystal)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Mining(_timeMining, crystal));
    }

    private IEnumerator Mining(float timeMining, IResource crystal)
    {
        for (int i = 0; i < timeMining; i++)
        {
            yield return null;
        }

        crystal.ReturnToPool();

        _unitStorage.ReceiveOrePiece(crystal.GetOrePiece());

        Executed?.Invoke();
    }
}
