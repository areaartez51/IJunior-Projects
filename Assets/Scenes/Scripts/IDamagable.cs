using UnityEngine;

public interface IDamagable
{
    public void Attack(IDamagable target);
    public void TakeDamage(int damage);
}
