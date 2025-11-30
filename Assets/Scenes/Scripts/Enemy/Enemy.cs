using UnityEngine;

[RequireComponent(typeof(Patroller))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    private Patroller _patroller;

    private void Awake()
    {
        _patroller = GetComponent<Patroller>();
    }

    private void Start()
    {
        _patroller.Patrolling();
    }
}
