using UnityEngine;
using UnityEngine.Pool;

namespace Practice_7
{
    public class PoolObject : MonoBehaviour
    {
        [SerializeField] private Box _prefab;
        [SerializeField] private int _poolMaxSize = 40;

        private ObjectPool<Box> _pool;

        private void Awake()
        {
            _pool = new ObjectPool<Box>(
                createFunc: () => Instantiate(_prefab),
                actionOnRelease: (box) => box.gameObject.SetActive(false),
                actionOnDestroy: (box) => Destroy(box),
                collectionCheck: true,
                maxSize: _poolMaxSize);
        }

        private void OnEnable()
        {
            Box.CubeFalled += ReturnCubeInPool;
        }

        private void OnDisable()
        {
            Box.CubeFalled -= ReturnCubeInPool;
        }

        public Box GetBox() => _pool.Get();

        private void ReturnCubeInPool(Box box) => _pool.Release(box);
    }
}
