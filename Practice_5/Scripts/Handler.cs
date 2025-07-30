using System;
using System.Collections.Generic;
using UnityEngine;

namespace Practice_5
{
    public class Handler : MonoBehaviour
    {
        public event Action<Cube> RealisticExploded;
        public event Action<List<Cube>, Vector3> CasualExploded;

        public void Report(List<Cube> Cubes, Vector3 positionExplosion)
        {
            CasualExploded?.Invoke(Cubes, positionExplosion);
        }

        public void Report(Cube cube)
        {
            RealisticExploded?.Invoke(cube);
        }
    }
}

