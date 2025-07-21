using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private Timer _timer;

    private void OnEnable()
    {
        _timer.ChangedNumber += ChangeText;
    }

    private void OnDisable()
    {
        _timer.ChangedNumber -= ChangeText;
    }

    private void ChangeText(float value)
    {
        _textMeshProUGUI.text = value.ToString();
    }
}
