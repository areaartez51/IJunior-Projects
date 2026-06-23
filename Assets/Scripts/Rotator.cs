using DG.Tweening;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotationAngle = 360f;
    [SerializeField] private float _rotationDuration = 3f;
    
    private RotateMode _rotateMode = RotateMode.FastBeyond360;
    private Ease _easeType = Ease.Linear;
    private LoopType _loopType = LoopType.Restart;

    private void Start()
    {
        transform.DORotate(new Vector3(0, _rotationAngle, 0), _rotationDuration, _rotateMode)
            .SetEase(_easeType)
            .SetLoops(-1, _loopType);
    }
}