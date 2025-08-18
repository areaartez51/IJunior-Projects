using System;
using UnityEngine;

namespace Practice_5
{
    public class Raycaster : MonoBehaviour
    {
        [SerializeField] private Transform _camera;
        [SerializeField] private float _maxDistance;
        [SerializeField] private InputControlerHandler _inputControlerHandler;
        [SerializeField] private RaycasterHandler _raycasterHandler;

        private RaycastHit _raycastHitInfo;

        private void OnEnable()
        {
            _inputControlerHandler.OnClick += PushRayCast;
        }

        private void OnDisable()
        {
            _inputControlerHandler.OnClick -= PushRayCast;
        }

        private void PushRayCast()
        {
            if (Physics.Raycast(_camera.position, _camera.forward, out _raycastHitInfo, _maxDistance))
            {
                if (_raycastHitInfo.transform.TryGetComponent<Cube>(out Cube cube))
                    _raycasterHandler?.SendCube(cube);
            }
        }
    }
}
