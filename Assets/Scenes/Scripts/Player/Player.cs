using UnityEngine;

[RequireComponent(typeof(InteractionHandler))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(PlayerAnimation))]
public class Player : MonoBehaviour
{
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
