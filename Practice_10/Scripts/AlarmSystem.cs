using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    private Coroutine _activeCoroutine;
    private AudioSource _audioSource;

    private float _targetVolume;
    private float _recoveryRate = 0.5f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0f;
    }

    public void PlaySound()
    {
        _targetVolume = 1f;
        _activeCoroutine = StartCoroutine(ChangeVolume());
    }

    public void StopSound()
    {
        _targetVolume = 0f;

        if (_activeCoroutine != null)
            StopCoroutine(_activeCoroutine);

        _activeCoroutine = StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (_audioSource.volume != _targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _recoveryRate * Time.deltaTime);
            yield return null;
        }
    }
}
