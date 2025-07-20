using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] Timer timer;

    private void OnEnable()
    {
        timer.ChangedNumber += ChangeText;
    }

    private void OnDisable()
    {
        timer.ChangedNumber -= ChangeText;
    }

    private void ChangeText(float Value)
    {
        textMeshProUGUI.text = timer.CurrentValue.ToString();
    }
}
