using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float _maxDistance;
    [SerializeField] private Spawner _spawner;

    private RaycastHit _raycastHitInfo;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_camera.position, _camera.forward, out _raycastHitInfo, _maxDistance))
            {
                Cube cube = _raycastHitInfo.transform.GetComponent<Cube>();

                if (cube != null)
                {
                    _spawner.SpawnGameObject(cube);
                }
            }
        }
    }
}
