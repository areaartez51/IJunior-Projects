using UnityEngine;

[RequireComponent(typeof(Rotator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speedMovement = 8f;
    [SerializeField] private float _jumpHeight = 12f;

    private Rigidbody2D _rigidbody2D;
    private Rotator _rotator;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rotator = GetComponent<Rotator>();
    }

    public void Move(float horizontalDirection)
    {
        _rotator.TurnAround(horizontalDirection);
        Vector2 movement = new Vector2(horizontalDirection * _speedMovement, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = movement;
    }

    public void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpHeight, ForceMode2D.Impulse);
    }
}

