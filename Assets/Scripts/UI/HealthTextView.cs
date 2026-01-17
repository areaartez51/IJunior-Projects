using TMPro;
using UnityEngine;

namespace UI
{
    public class HealthTextView : HealthView
    {
        [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
        
        protected override void UpdateView(int currentValue, int maxValue) 
        {
            _textMeshProUGUI.text = $"{currentValue} / {maxValue}";
        } 
    }
}