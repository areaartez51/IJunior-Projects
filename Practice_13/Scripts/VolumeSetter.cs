using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetter : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _volumeSlider;

    [SerializeField] private float _maxLevelDecibels = 0;
    [SerializeField] private float _minLevelDecibels = 80;

    private float _maxVolume = 1f;
    private float _minVolume = 0.0001f;

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
        _mixer.audioMixer.SetFloat(_mixer.name, Mathf.Log10(Mathf.Clamp(volume, _minVolume, _maxVolume)) * _minLevelDecibels + _maxLevelDecibels);
    }
}
