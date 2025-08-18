using System.Collections.Generic;
using UnityEngine;

namespace Practice_5
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float _dividerScale = 2;
        [SerializeField] private Cube _prefabCube;

        private int _minNumberCubes = 0;
        private int _maxNumberCubes = 6;

        private float _reductionFactor = 2f;

        public List<Cube> Spawn(Cube cube)
        {
            Vector3 position = cube.transform.position;
            float currentSplitChance = cube.CurrentSplitChance;

            List<Cube> cubes = new List<Cube>();

            int numberCubes = Random.Range(_minNumberCubes, _maxNumberCubes);

            for (int i = 0; i <= numberCubes; i++)
            {
                Cube newCube = Instantiate(_prefabCube);
                newCube.Initialize(cube.transform.localScale / _dividerScale, position, currentSplitChance / _reductionFactor);
                cubes.Add(newCube);
            }

            return cubes;
        }
    }
}