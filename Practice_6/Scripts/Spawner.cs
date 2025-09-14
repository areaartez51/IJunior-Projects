using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Practice_6
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Mob _prefabMob;
        [SerializeField] private List<SpawPoint> _spawPoints;

        private void Start()
        {
            StartCoroutine(CountTime());
        }

        private IEnumerator CountTime(float delay = 2)
        {
            var wait = new WaitForSeconds(delay);
            int minRageRotation = 0;
            int maxRageRotation = 360;

            while (true)
            {
                int randomRotation = Random.Range(minRageRotation, maxRageRotation);
                Quaternion rotation = Quaternion.Euler(0, randomRotation, 0);

                Spawn(rotation);
                yield return wait;
            }
        }

        public void Spawn(Quaternion rotation)
        {
            SpawPoint spawPoint = _spawPoints[Random.Range(0, _spawPoints.Count)];
            Mob newMob = Instantiate(_prefabMob, spawPoint.transform.position, spawPoint.transform.rotation);
            newMob.Initialize(rotation);
        }
    }
}


