using System;
using System.Collections;
using UnityEngine;

namespace Practice_8
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]

    public abstract class Orc : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;

        private Human _human;
        private Vector3 _startPosition;

        public event Action<Orc> Removed;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Human human))
            {
                Removed?.Invoke(this);
            }
        }

        public void Initialization()
        {
            transform.position = _startPosition;
            StartCoroutine(Move());
        }

        public void RecieveTarget(Human human)
        {
            _human = human;
        }

        public void RecieveStartPosition(SpawnPoint spawnPoint)
        {
            _startPosition = spawnPoint.transform.position;
        }

        private IEnumerator Move()
        {
            while (isActiveAndEnabled)
            {
                transform.LookAt(_human.transform.position);
                transform.position = Vector3.MoveTowards(transform.position, _human.transform.position, _speed * Time.deltaTime);

                yield return null;
            }
        }
    }
}

