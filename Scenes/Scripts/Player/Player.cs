using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Platformer
{
    [RequireComponent(typeof(InteractionHandler))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(PlayerMover))]
    [RequireComponent(typeof(InputReader))]
    [RequireComponent(typeof(GroundDetector))]
    [RequireComponent(typeof(PlayerAnimation))]
    [RequireComponent(typeof(Health))]

    public class Player : MonoBehaviour, IDamagable, IHealable
    {
        [SerializeField] private int _damage = 10;

        private InteractionHandler _interactionHandler;
        private GroundDetector _groundDetector;
        private PlayerAnimation _playerAnimation;
        private PlayerMover _playerMover;
        private InputReader _inputReader;
        private Health _health;

        private bool _isGrounded;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _interactionHandler = GetComponent<InteractionHandler>();
            _playerAnimation = GetComponent<PlayerAnimation>();
            _groundDetector = GetComponent<GroundDetector>();
            _playerMover = GetComponent<PlayerMover>();
            _inputReader = GetComponent<InputReader>();
        }

        private void OnEnable()
        {
            _interactionHandler.UsedHealthKit += Heal;
            _groundDetector.Grounded += OnGroundedChanged;
            _inputReader.HorizontalMovement += OnHorizontalMovement;
            _inputReader.Jumping += OnJumping;
        }

        private void OnDisable()
        {
            _interactionHandler.UsedHealthKit -= Heal;
            _groundDetector.Grounded -= OnGroundedChanged;
            _inputReader.HorizontalMovement -= OnHorizontalMovement;
            _inputReader.Jumping -= OnJumping;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent(out IDamagable enemy))
            {
                Attack(enemy);
            }
        }

        public void Attack(IDamagable target)
        {
            target.TakeDamage(_damage);
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }

        public void Heal(int healPoint)
        {
            _health.AddHitPoint(healPoint);
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
    }
}


