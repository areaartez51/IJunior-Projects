using System;
using System.Collections;
using UnityEditor.VersionControl;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _startValue = 0;
    [SerializeField] private float _interval = 1;
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private InputReader _inputReader;

    public float CurrentValue => _currentValue;

    public event Action<float> ChangedNumber;

    private Coroutine _coroutine;

    private bool _isStarted = false;

    private float _currentValue;

    private void Start()
    {
        _currentValue = _startValue;
    }

    private void OnEnable()
    {
        _inputReader.Clicked += ProcessPressedButton;
    }

    private void OnDisable()
    {
        _inputReader.Clicked -= ProcessPressedButton;
    }

    private void ProcessPressedButton()
    {
        if (_isStarted == false)
        {
            _isStarted = true;

            _coroutine = StartCoroutine(Count());
        }
        else
        {
            Stop();
        }
    }

    private void Stop()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);

            _coroutine = null;
            _isStarted = false;
        }
    }

    private IEnumerator Count()
    {
        WaitForSeconds _wait = new WaitForSeconds(_delay);

        while (_isStarted)
        {
            _currentValue += _interval;
            ChangedNumber?.Invoke(_currentValue);

            yield return _wait;
        }
    }
}
