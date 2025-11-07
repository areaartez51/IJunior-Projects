using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Practice_8
{
    public class MobSpawner : MonoBehaviour
    {
        [SerializeField] private List<SpawnPoint> _spawnPoints;

        private ObjectPool<Orc> _orcPool;
        private int _orcPoolCapacity = 20;
        private int _orcPoolMaxSize = 20;
        private int _repeatRate = 2;

        private void Awake()
        {
            _orcPool = new ObjectPool<Orc>(
                createFunc: () => CreateEnemy(),
                actionOnGet: (orc) => Initialization(orc),
                actionOnRelease: (orc) => Disable(orc),
                actionOnDestroy: (orc) => Destroy(orc),
                collectionCheck: true,
                defaultCapacity: _orcPoolCapacity,
                maxSize: _orcPoolMaxSize);
        }

        private void Start()
        {
            StartCoroutine(SpawnOrcWithRate(_repeatRate));
        }

        private Orc CreateEnemy()
        {
            SpawnPoint certainSpawnPoint = GetSpawnPoint();
            Orc certainOrc = certainSpawnPoint.Orc;
            Orc orc = Instantiate(certainOrc, certainSpawnPoint.transform.position, Quaternion.identity);
            orc.RecieveTarget(certainSpawnPoint.Human);
            orc.RecieveStartPosition(certainSpawnPoint);

            return orc;
        }

        private void RemoveOrc(Orc orc)
        {
            _orcPool.Release(orc);
            orc.Removed -= RemoveOrc;
        }

        private void Initialization(Orc orc)
        {
            orc.gameObject.SetActive(true);
            orc.Initialization();
        }

        private void Disable(Orc orc)
        {
            orc.gameObject.SetActive(false);
        }

        private SpawnPoint GetSpawnPoint()
        {
            return _spawnPoints[Random.Range(0, _spawnPoints.Count)];
        }

        private IEnumerator SpawnOrcWithRate(int repeatRate)
        {
            var wait = new WaitForSeconds(repeatRate);

            while (enabled)
            {
                yield return wait;

                SpawnOrc();
            }
        }

        private void SpawnOrc()
        {
            Orc newOrc = _orcPool.Get();
            newOrc.Removed += RemoveOrc;
        }
    }
}


