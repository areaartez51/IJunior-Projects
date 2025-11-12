using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    private Coroutine _activeCoroutine;
    private AudioSource _audioSource;
    private float _maxVolume;
    private float _recoveryRate = 0.5f;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Thief thief))
        {
            _maxVolume = 1f;
            _activeCoroutine = StartCoroutine(ChangeVolume());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _maxVolume = 0f;
        StopCoroutine(_activeCoroutine);
        _activeCoroutine = StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (_audioSource.volume != _maxVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _recoveryRate * Time.deltaTime);
            yield return null;
        }
    }
}
