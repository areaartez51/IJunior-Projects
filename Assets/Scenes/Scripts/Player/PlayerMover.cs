using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speedMovement = 8f;
    [SerializeField] private float _jumpHeight = 12f;

    private Rigidbody2D _rigidbody2D;

    private Quaternion _rotation;
    private float _glanceRight = 0;
    private float _glanceLeft = 180;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(float horizontalDirection)
    {
        TurnAround(horizontalDirection);
        Vector2 movement = new Vector2(horizontalDirection * _speedMovement, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = movement;
    }

    public void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpHeight, ForceMode2D.Impulse);
    }

    private void TurnAround(float horizontalDirection)
    {
        if (horizontalDirection >= 0)
            _rotation.y = _glanceRight;
        else
            _rotation.y = _glanceLeft;

        transform.rotation = _rotation;
    }
}

