using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimator : MonoBehaviour
{
    [SerializeField]
    private string[] _texts = {
        "Hello World!",
        "Unity C# (´ ε ` )♡",
        "Animation is pain! (╥﹏╥)"
    };

    [SerializeField] private float _changeDuration = 1f;
    [SerializeField] private float _scrambleDuration = 0.5f;

    private Text _uiText;
    private int _currentTextIndex = 0;

    private void Start()
    {
        _uiText = GetComponent<Text>();
        PlayAnimationSequence();
    }

    private void PlayAnimationSequence()
    {
        _currentTextIndex = (_currentTextIndex + 1) % _texts.Length;
        string targetText = _texts[_currentTextIndex];

        Sequence sequence = DOTween.Sequence();

        AddTextAnimation(sequence, targetText, _changeDuration, ScrambleMode.None);

        AddTextAnimation(sequence, targetText, _changeDuration, ScrambleMode.None, true);

        AddTextAnimation(sequence, targetText, _scrambleDuration, ScrambleMode.Lowercase, true);

        sequence.OnComplete(PlayAnimationSequence);
    }

    private void AddTextAnimation(Sequence sequence, string text, float duration,
                                ScrambleMode scrambleMode, bool needClear = false)
    {
        if (needClear)
            sequence.AppendCallback(() => _uiText.text = "");

        sequence.Append(
            _uiText.DOText(text, duration, true, scrambleMode)
        );
    }
}