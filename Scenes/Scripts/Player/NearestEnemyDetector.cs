using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class NearestEnemyDetector : MonoBehaviour
    {
        [SerializeField] private List<Enemy> _enemies;

        private Enemy _target;

        public event Action<Enemy> NewEnemyAppeared;

        private void Awake()
        {
            _enemies = new List<Enemy>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.TryGetComponent(out Enemy enemy))
            {
                _enemies.Add(enemy);
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.transform.TryGetComponent(out Enemy enemy))
            {
                _target = FindClosestEnemy();

                NewEnemyAppeared?.Invoke(_target);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.transform.TryGetComponent(out Enemy enemy))
            {
                if (_enemies != null)
                {
                    _enemies.Remove(enemy);
                }
            }
        }

        private Enemy FindClosestEnemy()
        {
            float distance = Mathf.Infinity;
            Enemy nearEnemy = null;

            foreach (Enemy enemy in _enemies)
            {
                Vector2 distanceVector = enemy.transform.position - transform.position;
                float currentDistance = distanceVector.sqrMagnitude;

                if (currentDistance < distance)
                {
                    nearEnemy = enemy;
                    distance = currentDistance;
                }
            }

            return nearEnemy;
        }
    }
}

