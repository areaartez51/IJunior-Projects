using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private AudioListener _audioListener;

    [SerializeField] private Button _button;

    private bool _enabled;

    private void Awake()
    {
        _audioListener = _camera.GetComponent<AudioListener>();
        _enabled = _audioListener != null;
    }

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
        _enabled = !_enabled;
        _audioListener.enabled = _enabled;
    }
}
