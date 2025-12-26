using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Button _button;

    private float _minValue = -80f;
    private float _defalteValue = 0;

    private void OnEnable()
    {
        _button.onClick.AddListener(ToggleSound);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ToggleSound);
    }

    private void ToggleSound()
    {
        _mixer.audioMixer.GetFloat(_mixer.name, out float value);

        if (value <= _minValue)
        {
            _mixer.audioMixer.SetFloat(_mixer.name, _defalteValue);
        }
        else
        {
            SetDefalteValue(value);

            _mixer.audioMixer.SetFloat(_mixer.name, _minValue);
        }
    }

    private void SetDefalteValue(float value)
    {
        _defalteValue = value;
    }
}
