using System.Collections.Generic;
using UnityEngine;

public class RaycasterHandler : MonoBehaviour
{
    [SerializeField] private CubeFabric _cubeFabric;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Detonator _detonator;

    private void OnEnable()
    {
        Raycaster.DetectedCube += ProcessingRay;
    }

    private void OnDisable()
    {
        Raycaster.DetectedCube -= ProcessingRay;
    }

    private void ProcessingRay(Cube cube)
    {
        List<Cube> cubes = _cubeFabric.Create(cube);
        _spawner.Spawn(cubes);
        _detonator.Explode(_cubeFabric.GetRigidbodyCubes(cubes), cube.transform.position);
        Destroy(cube.gameObject);
    }
}
