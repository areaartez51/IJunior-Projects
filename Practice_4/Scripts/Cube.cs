using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(StartColorChanger))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _currentSplitChance = 100f;

    public float CurrentSplitChance => _currentSplitChance;

    public void Initialize(Vector3 localeScale, Vector3 position, float currentSplitChance)
    {
        _currentSplitChance = currentSplitChance;
        transform.localScale = localeScale;
        transform.localPosition = position;
    }
}
