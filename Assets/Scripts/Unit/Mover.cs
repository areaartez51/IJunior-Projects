using DG.Tweening;
using System;
using UnityEngine;

public class Mover : MonoBehaviour, IMover
{
    private float _speed;
    private float _arrivalThreshold;

    private Tween _tween;

    public void Init(float speed, float arrivalThreshold)
    {
        _speed = speed;
        _arrivalThreshold = arrivalThreshold;
    }

    public void StartMove(Vector3 target, Action Executed)
    {
        _tween?.Kill();

        Vector3 flatTarget = new Vector3(target.x, transform.position.y, target.z);

        transform.LookAt(flatTarget);

        Vector3 flatPosition = new Vector3(transform.position.x, 0f, transform.position.z);
        Vector3 flatTargetZero = new Vector3(flatTarget.x, 0f, flatTarget.z);

        Vector3 direction = (flatTargetZero - flatPosition).normalized;
        float distance = Vector3.Distance(flatPosition, flatTargetZero);

        float moveDistance = Mathf.Max(0f, distance - _arrivalThreshold);
        Vector3 stopPoint = flatPosition + direction * moveDistance;

        stopPoint.y = transform.position.y;

        float duration = _speed > 0f ? moveDistance / _speed : 0f;

        _tween = transform
            .DOMove(stopPoint, duration)
            .SetEase(Ease.Linear)
            .SetUpdate(UpdateType.Normal)
            .OnComplete(() => Executed?.Invoke());
    }
}