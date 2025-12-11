using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class HealthKit : MonoBehaviour
{
    [SerializeField] private int _healPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IHealable target))
        {
            target.Heal(_healPoint);

            Destroy(gameObject);
        }
    }
}
