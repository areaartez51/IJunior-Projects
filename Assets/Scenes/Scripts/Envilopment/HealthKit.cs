using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class HealthKit : MonoBehaviour
{
    [SerializeField] private int _healPoint;

    public int HealPoint => _healPoint;
}
