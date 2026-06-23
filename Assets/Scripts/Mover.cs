using DG.Tweening;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveDistance = 3f;
    [SerializeField] private float _moveDuration = 2f;
    
    private Ease _easeType = Ease.InOutSine;
    private LoopType _loopType = LoopType.Yoyo;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;

        transform.DOMove(_startPosition + Vector3.right * _moveDistance, _moveDuration)
            .SetEase(_easeType)
            .SetLoops(-1, _loopType);
    }
}