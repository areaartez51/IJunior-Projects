using System;
using UnityEngine;

[RequireComponent(typeof(Bag))]
public class InteractionHandler : MonoBehaviour
{
    private Bag _currentBag;

    public event Action<int> UsedHealthKit;

    private void Awake()
    {
        _currentBag = GetComponent<Bag>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out _))
        {
            _currentBag.AddCoin();
            Destroy(collision.gameObject);
        }

        if (collision.TryGetComponent(out HealthKit healthKit))
        {
            UsedHealthKit?.Invoke(healthKit.HealPoint);
            Destroy(collision.gameObject);
        }
    }
}
