using UnityEngine;
using UnityEngine.UI;

public class AudioSourcePlayer : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        _button.onClick.AddListener(PlaySound);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(PlaySound);
    }

    private void PlaySound()
    {
        _audioSource.Play();
    }
}
