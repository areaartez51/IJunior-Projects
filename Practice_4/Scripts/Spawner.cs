using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Detonator _detonator;
    [SerializeField] private float _dividerScale = 2;

    private float _minNumberCubes = 0f;
    private float _maxNumberCubes = 6f;

    public void SpawnGameObject(Cube cube)
    {
        float numberCubes = Random.Range(_minNumberCubes, _maxNumberCubes);

        Destroy(cube.gameObject);

        if (cube.ShouldSplit())//100%
        {
            for (int i = 0; i <= numberCubes; i++)
            {
                Cube copyObject = Instantiate(cube);

                copyObject.ColorChange();

                copyObject.transform.position = cube.transform.position;
                copyObject.transform.localScale = copyObject.transform.localScale / _dividerScale;
            }
        }

        Detonator detonator = Instantiate(_detonator, cube.transform.position, cube.transform.rotation);
        detonator.Explode();
    }
}