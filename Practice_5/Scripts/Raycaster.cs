using System;
using UnityEngine;

namespace Practice_5
{
    public class Raycaster : MonoBehaviour
    {
        [SerializeField] private Transform _camera;
        [SerializeField] private float _maxDistance;

        public static event Action<Cube> DetectedCube;

        private RaycastHit _raycastHitInfo;

        private void PushRayCast()
        {
            if (Physics.Raycast(_camera.position, _camera.forward, out _raycastHitInfo, _maxDistance))
            {
                Cube cube = _raycastHitInfo.transform.GetComponent<Cube>();

                if (cube != null)
                {
                    DetectedCube?.Invoke(cube);
                }
            }
        }

        private void OnEnable()
        {
            InputControler.MouseButtonDown += PushRayCast;
        }

        private void OnDisable()
        {
            InputControler.MouseButtonDown -= PushRayCast;
        }
    }
}
