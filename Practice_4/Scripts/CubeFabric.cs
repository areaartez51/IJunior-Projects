using System.Collections.Generic;
using UnityEngine;

public class CubeFabric : MonoBehaviour
{
    [SerializeField] private float _dividerScale = 2;

    private float _reductionFactor = 2f;

    private int _minNumberCubes = 0;
    private int _maxNumberCubes = 6;

    public List<Cube> Create(Cube cube)
    {
        List<Cube> Cubes = new List<Cube>();

        int numberCubes = Random.Range(_minNumberCubes, _maxNumberCubes);

        if (ShouldSplit(cube.CurrentSplitChance))
        {
            cube.Initialization(GetRandomColor(), cube.transform.localScale /= _dividerScale, cube.transform.position, cube.CurrentSplitChance / _reductionFactor);

            for (int i = 0; i <= numberCubes; i++)
                Cubes.Add(cube);
        }

        return Cubes;
    }

    public List<Rigidbody> GetRigidbodyCubes(List<Cube> cubes)
    {
        List<Rigidbody> rigidbodies = new List<Rigidbody>();

        foreach (Cube cube in cubes)
            if (cube.GetComponent<Rigidbody>() != null)
                rigidbodies.Add(cube.GetComponent<Rigidbody>());

        return rigidbodies;
    }

    private Color GetRandomColor()
    {
        float minRange = 0;
        float maxRange = 1;

        Vector4 newColor = new Vector4(GetRandomNumber(minRange, maxRange), GetRandomNumber(minRange, maxRange), GetRandomNumber(minRange, maxRange));

        return newColor;
    }

    private bool ShouldSplit(float currentSplitChance)
    {
        return (GetRandomNumber() <= currentSplitChance);
    }

    private float GetRandomNumber(float minRange = 0, float maxRange = 100)
    {
        float randomNumber = Random.Range(minRange, maxRange);

        return randomNumber;
    }
}
