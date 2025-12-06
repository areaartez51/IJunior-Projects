using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class HealthKit : MonoBehaviour, IDamagable
{
    [SerializeField] private int _healPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Attack(player);
        }
    }

    public void Attack(IDamagable target)
    {
        target.TakeDamage(-_healPoint);
    }

    public void TakeDamage(int damage)
    {
        Destroy(gameObject);
    }
}
