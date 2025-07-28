using System;
using System.Collections.Generic;
using UnityEngine;

namespace Practice_5
{
    public class CubeFactory : MonoBehaviour
    {
        [SerializeField] private float _dividerScale = 2;
        [SerializeField] private Cube _cube;

        public static event Action<Cube> RealisticExploded;
        public static event Action<List<Cube>, Vector3> CasualExploded;

        private int _minNumberCubes = 0;
        private int _maxNumberCubes = 6;

        private float _reductionFactor = 2f;

        public void Create(Cube cube)
        {
            Vector3 position = cube.transform.position;
            float currentSplitChance = cube.CurrentSplitChance;

            List<Cube> Cubes = new List<Cube>();

            int numberCubes = UnityEngine.Random.Range(_minNumberCubes, _maxNumberCubes);

            if (Divide(currentSplitChance))
            {
                for (int i = 0; i <= numberCubes; i++)
                {
                    _cube.Initialize(cube.transform.localScale / _dividerScale, position, currentSplitChance / _reductionFactor);
                    Cubes.Add(_cube);
                }

                Spawn(Cubes);

                CasualExploded?.Invoke(Cubes, position);
            }
            else
            {
                RealisticExploded?.Invoke(cube);
            }

            Destroy(cube.gameObject);
        }

        private void Spawn(List<Cube> cubes)
        {
            foreach (var cube in cubes)
                Instantiate(cube);
        }

        private bool Divide(float currentSplitChance)
        {
            return (GetRandomNumber() <= currentSplitChance);
        }

        private float GetRandomNumber(float minRange = 0, float maxRange = 100)
        {
            return UnityEngine.Random.Range(minRange, maxRange);
        }

        private void OnEnable()
        {
            Raycaster.DetectedCube += Create;
        }

        private void OnDisable()
        {
            Raycaster.DetectedCube -= Create;
        }
    }
}


