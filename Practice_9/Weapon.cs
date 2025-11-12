using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _delay = 1f;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _target;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        bool isWork = enabled;

        while (isWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Vector3 spawnPosition = transform.position + direction;

            Bullet NewBullet = Instantiate(_prefab, spawnPosition, Quaternion.identity);
            NewBullet.Init(direction);

            yield return new WaitForSeconds(_delay);
        }
    }
}
