using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _currentSplitChance = 100f;

    public float CurrentSplitChance => _currentSplitChance;

    public void Initialization(Color newColor, Vector3 localeScale, Vector3 position, float currentSplitChance)
    {
        GetComponent<Renderer>().material.color = newColor;
        _currentSplitChance = currentSplitChance;
        transform.localScale = localeScale;
        transform.localPosition = position;
    }
}
