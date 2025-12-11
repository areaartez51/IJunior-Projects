using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private int _hitPoint = 100;

    public void TakeDamage(int damage)
    {
        _hitPoint -= Math.Abs(damage);

        if (_hitPoint <= 0)
            Destroy(gameObject);
    }

    public void AddHitPoint(int hitPoint)
    {
        _hitPoint += Math.Abs(hitPoint);
    }
}
