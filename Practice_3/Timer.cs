using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _startValue = 0;
    [SerializeField] private float _endValue = 15;
    [SerializeField] private float _interval = 1;
    [SerializeField] private float _delay = 0.5f;

    public float CurrentValue => _currentValue;

    public event Action <float> ChangedNumber;

    private float _currentValue;

    private bool _isClick = false;
    private bool _coroutinesIsWork = false;

    private void Update()
    {
        OnClickMouse();
    }
    
    private void OnClickMouse()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            _isClick = !_isClick;

            if (!_coroutinesIsWork)
            {
                StartCoroutine(Counter());
            }
        }
    }

    private IEnumerator Counter()
    {
        _coroutinesIsWork = !_coroutinesIsWork;

        for (_currentValue = _startValue; _currentValue <= _endValue; _currentValue += _interval)
        {
            ChangedNumber?.Invoke(_currentValue);

            yield return new WaitForSeconds(_delay);
            yield return new WaitUntil(() => _isClick);
        }
    }
}
