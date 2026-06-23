using DG.Tweening;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField]
    private Color[] _colors = {
        Color.red,
        Color.blue,
        Color.green,
        Color.yellow,
        Color.magenta
    };

    [SerializeField] private float _colorChangeDuration = 1f;
    
    private Ease _easeType = Ease.InOutSine;
    private Material _objectMaterial;
    private int _currentColorIndex = 0;

    private void Start()
    {
        _objectMaterial = GetComponent<Renderer>().material;

        ChangeColor();
    }

    private void ChangeColor()
    {
        _currentColorIndex = (_currentColorIndex + 1) % _colors.Length;

        _objectMaterial.DOColor(_colors[_currentColorIndex], _colorChangeDuration)
            .SetEase(_easeType)
            .OnComplete(ChangeColor);
    }
}