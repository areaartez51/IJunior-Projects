using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private Home _home;

    private Coroutine _activeCoroutine;
    private AudioSource _audioSource;

    private float _targetVolume;
    private float _recoveryRate = 0.5f;

    private void OnEnable()
    {
        _home.BreakingInto += PlaySound;
        _home.LeftHouse += StopSound;
    }

    private void OnDisable()
    {
        _home.BreakingInto -= PlaySound;
        _home.LeftHouse -= StopSound;
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0f;
    }

    private void PlaySound(Collider other)
    {
        _targetVolume = 1f;
        _activeCoroutine = StartCoroutine(ChangeVolume());
    }

    private void StopSound()
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
