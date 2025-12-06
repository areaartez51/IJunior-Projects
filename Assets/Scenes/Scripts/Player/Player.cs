using UnityEngine;

[RequireComponent(typeof(InteractionHandler))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(PlayerAnimation))]
public class Player : MonoBehaviour, IDamagable
{
    [SerializeField] private int _hitPoint = 100;
    [SerializeField] private int _damage = 10;

    private GroundDetector _groundDetector;
    private PlayerAnimation _playerAnimation;
    private PlayerMover _playerMover;
    private InputReader _inputReader;

    private bool _isGrounded;

    private void Awake()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _groundDetector = GetComponent<GroundDetector>();
        _playerMover = GetComponent<PlayerMover>();
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _groundDetector.GroundedChanged += OnGroundedChanged;
        _inputReader.HorizontalMovement += OnHorizontalMovement;
        _inputReader.Jumping += OnJumping;
    }

    private void OnDisable()
    {
        _groundDetector.GroundedChanged -= OnGroundedChanged;
        _inputReader.HorizontalMovement -= OnHorizontalMovement;
        _inputReader.Jumping -= OnJumping;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Enemy enemy))
        {
            Attack(enemy);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthKit healthKit))
        {
            Attack(healthKit);
        }
    }

    private void OnHorizontalMovement(float horizontalDirection)
    {
        _playerMover.Move(horizontalDirection);
        _playerAnimation.SetSpeed(horizontalDirection);
    }

    private void OnJumping()
    {
        if (_isGrounded)
        {
            _playerMover.Jump();
            _playerAnimation.TriggerJump();
        }
    }

    private void OnGroundedChanged(bool isGrounded)
    {
        _isGrounded = isGrounded;
    }

    public void Attack(IDamagable target)
    {
        target.TakeDamage(_damage);
    }

    public void TakeDamage(int damage)
    {
        _hitPoint -= damage;

        if (_hitPoint <= 0)
            Destroy(gameObject);
    }
}
