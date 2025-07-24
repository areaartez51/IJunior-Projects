using System.Collections.Generic;
using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private float _dividerScale = 2;
    [SerializeField] private Cube _cube;

    private float _reductionFactor = 2f;

    private int _minNumberCubes = 0;
    private int _maxNumberCubes = 6;

    public List<Cube> Create(Cube cube)
    {
        List<Cube> Cubes = new List<Cube>();

        int numberCubes = Random.Range(_minNumberCubes, _maxNumberCubes);

        if (Divide(cube.CurrentSplitChance))
        {
            for (int i = 0; i <= numberCubes; i++)
            {
                _cube.Initialize(cube.transform.localScale / _dividerScale, cube.transform.position, cube.CurrentSplitChance / _reductionFactor);
                Cubes.Add(_cube);
            }
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

    private bool Divide(float currentSplitChance)
    {
        return (GetRandomNumber() <= currentSplitChance);
    }

    private float GetRandomNumber(float minRange = 0, float maxRange = 100)
    {
        return Random.Range(minRange, maxRange);
    }
}
