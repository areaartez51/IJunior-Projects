using DG.Tweening;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private Vector3 _targetScale = new Vector3(1.5f, 1.5f, 1.5f);
    [SerializeField] private float _scaleDuration = 1.5f;
    
    private Ease _easeType = Ease.InOutBack;
    private LoopType _loopType = LoopType.Yoyo;
    private Vector3 _originalScale;

    private void Start()
    {
        _originalScale = transform.localScale;

        transform.DOScale(_targetScale, _scaleDuration)
            .SetEase(_easeType)
            .SetLoops(-1, _loopType);
    }
}