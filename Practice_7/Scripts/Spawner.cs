using UnityEngine;

namespace Practice_7
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private PoolObject _poolObject;

        [SerializeField] private float _size;
        [SerializeField] private float _repeatRate = 1;

        private float _time = 0;

        private void Start()
        {
            InvokeRepeating(nameof(Spawn), _time, _repeatRate);
        }

        private void Spawn()
        {
            Box box = _poolObject.GetBox();
            box.Init(GetRandomStartPosition());
        }

        private Vector3 GetRandomStartPosition()
        {
            float randomSize = Random.Range(-_size, _size);

            return new Vector3(randomSize, transform.position.y, randomSize);
        }
    }
}