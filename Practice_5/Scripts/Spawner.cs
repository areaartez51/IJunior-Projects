using System.Collections.Generic;
using UnityEngine;

namespace Practice_5
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float _dividerScale = 2;
        [SerializeField] private Cube _cube;
        [SerializeField] private SpawnerHandler _spawnerHandler;
        [SerializeField] private RaycasterHandler _raycasterHandler;

        private int _minNumberCubes = 0;
        private int _maxNumberCubes = 6;

        private float _reductionFactor = 2f;

        private void OnEnable()
        {
            _raycasterHandler.GetCube += Spawn;
        }

        private void OnDisable()
        {
            _raycasterHandler.GetCube -= Spawn;
        }

        public void Spawn(Cube cube)
        {
            Vector3 position = cube.transform.position;
            float currentSplitChance = cube.CurrentSplitChance;

            List<Cube> cubes = new List<Cube>();

            int numberCubes = Random.Range(_minNumberCubes, _maxNumberCubes);

            if (cube.CanSplit(GetRandomNumber()))
            {
                for (int i = 0; i <= numberCubes; i++)
                {
                    _cube.Initialize(cube.transform.localScale / _dividerScale, position, currentSplitChance / _reductionFactor);
                    Instantiate(_cube);
                    cubes.Add(_cube);
                }

                _spawnerHandler.SpawnHandler(cubes, position);
            }
            else
            {
                _spawnerHandler.SpawnHandler(cube);
            }

            Destroy(cube.gameObject);
        }

        private float GetRandomNumber(float minRange = 0, float maxRange = 100) => Random.Range(minRange, maxRange);
    }
}


