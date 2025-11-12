using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _delay = 1f;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _target;

    private WaitForSeconds waitForSeconds;

    private void Start()
    {
        StartCoroutine(Shoot());
        waitForSeconds = new WaitForSeconds(_delay);
    }

    private IEnumerator Shoot()
    {
        bool isWork = enabled;

        while (isWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Vector3 spawnPosition = transform.position + direction;

            Bullet newBullet = Instantiate(_prefab, spawnPosition, Quaternion.identity);
            newBullet.Init(direction);

            yield return waitForSeconds;
        }
    }
}
