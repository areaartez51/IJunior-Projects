using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace Practice_7
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Box _prefab;

        [SerializeField] private float _size;
        [SerializeField] private float _repeatRate = 1;

        [SerializeField] private int _poolMaxSize = 40;

        private ObjectPool<Box> _pool;

        private void Start()
        {
            bool isWorked = true;
            StartCoroutine(TimerForDie(isWorked, _repeatRate));
        }

        private void Awake()
        {
            _pool = new ObjectPool<Box>(
                createFunc: () => Instantiate(_prefab),
                actionOnRelease: (box) => box.gameObject.SetActive(false),
                actionOnDestroy: (box) => Destroy(box),
                collectionCheck: true,
                maxSize: _poolMaxSize);
        }

        private IEnumerator TimerForDie(bool isWorked = true, float delay = 2)
        {
            var wait = new WaitForSeconds(delay);

            while (isWorked)
            {
                Spawn();
                yield return wait;
            }
        }

        private void Spawn()
        {
            Box box = GetBox();
            box.Init(GetRandomStartPosition());
        }

        private Vector3 GetRandomStartPosition()
        {
            float randomSize = Random.Range(-_size, _size);

            return new Vector3(randomSize, transform.position.y, randomSize);
        }

        private Box GetBox()
        {
            Box box = _pool.Get();
            box.Falled += OnBoxFalled;

            return box;
        }

        public void OnBoxFalled(Box box)
        {
            box.Falled -= OnBoxFalled;
            _pool.Release(box);
        }
    }
}
