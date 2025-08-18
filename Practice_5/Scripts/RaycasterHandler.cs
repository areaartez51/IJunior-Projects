using System;
using UnityEngine;

namespace Practice_5
{
    public class RaycasterHandler : MonoBehaviour
    {
        public event Action<Cube> GetCube;

        public void SendCube(Cube cube)
        {
            GetCube?.Invoke(cube);
        }
    }
}
