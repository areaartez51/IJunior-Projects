using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private float _maxVolume = 1.0f;
    [SerializeField] private float _minVolume = 0f;

    private Coroutine _activeCoroutine;
    private AudioSource _audioSource;

    private float _recoveryRate = 0.5f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Stop();
    }

    public void PlaySound()
    {
        _audioSource.Play();
        _activeCoroutine = StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void StopSound()
    {
        _activeCoroutine = StartCoroutine(ChangeVolume(_minVolume));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _recoveryRate * Time.deltaTime);
            yield return null;
        }

        if (_audioSource.volume == 0)
            _audioSource.Stop();
    }
}
