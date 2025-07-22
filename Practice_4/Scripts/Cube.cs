using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Color _color;
    [SerializeField] private float _currentSplitChance = 100f;

    public float GetRandomNumber(float minRange = 0, float maxRange = 100)
    {
        float randomNumber = Random.Range(minRange, maxRange);

        return randomNumber;
    }

    public void ColorChange()
    {
        float minRange = 0;
        float maxRange = 1;

        Vector4 newColor = new Vector4(GetRandomNumber(minRange, maxRange), GetRandomNumber(minRange, maxRange), GetRandomNumber(minRange, maxRange));

        GetComponent<Renderer>().material.color = newColor;
    }

    public bool ShouldSplit()
    {
        float reductionFactor = 2f;

        float randomNumber = GetRandomNumber();

        if (randomNumber <= _currentSplitChance)
        {
            _currentSplitChance /= reductionFactor;
            return true;
        }

        return false;
    }
}
