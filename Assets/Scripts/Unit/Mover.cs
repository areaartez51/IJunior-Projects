using System;
using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _arrivalThreshold;

    private Coroutine _coroutine;

    public event Action Executed;

    private IEnumerator MoveTarget(Vector3 target)
    {
        while (!UserUtils.IsReachedTarget(target, transform.position, _arrivalThreshold))
        {
            transform.LookAt(target);
            Vector3 newPosition = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
            transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);

            yield return null;
        }

        Executed?.Invoke();
    }

    public void StartMove(Vector3 target)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(MoveTarget(target));
    }
}
