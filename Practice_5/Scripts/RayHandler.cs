using System.Collections.Generic;
using UnityEngine;

namespace Practice_5
{
    public class RayHandler : MonoBehaviour
    {
        [SerializeField] private Spawner _spawner;
        [SerializeField] private Detonator _detonator;

        public void SendCube(Cube cube)
        {
            if (cube.CanSplit(GetRandomNumber()))
            {
                List<Cube> cubes = _spawner.Spawn(cube);
                _detonator.DetonateCasual(cubes, cube.transform.position);
            }
            else 
            {
                _detonator.DetonateRealistic(cube);
            }

            Destroy(cube.gameObject);
        }

        private float GetRandomNumber(float minRange = 0, float maxRange = 100) => Random.Range(minRange, maxRange);
    }
}