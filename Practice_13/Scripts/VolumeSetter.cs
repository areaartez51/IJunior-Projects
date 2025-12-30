using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetter : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _volumeSlider;

    [SerializeField] private string _mixerName;

    [SerializeField] private float _maxLevelDecibels = 0;
    [SerializeField] private float _minLevelDecibels = 80;

    private float _maxVolume = 1f;
    private float _minVolume = 0f;

    private float _minValue = -80f;
    private float _defalteValue = 0;

    private void OnEnable()
    {
        _volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    private void OnDisable()
    {
        _volumeSlider.onValueChanged.RemoveListener(SetVolume);
    }

    private void SetVolume(float volume)
    {
        if (volume <= _defalteValue)
        {
            _mixer.audioMixer.SetFloat(_mixerName, _minValue);
        }
        else 
        {
            float range = Mathf.Log10(Mathf.Clamp(volume, _minVolume, _maxVolume));

            _mixer.audioMixer.SetFloat(_mixerName, range * _minLevelDecibels + _maxLevelDecibels);
        }

    }
}
