using UnityEngine;

[RequireComponent(typeof(StateChase))]
[RequireComponent(typeof(StatePatrolling))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private int _damage = 10;

    private Health _health;
    private StatePatrolling _statePatrolling;
    private StateChase _stateHarassment;

    private IState _currentState;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _statePatrolling = GetComponent<StatePatrolling>();
        _stateHarassment = GetComponent<StateChase>();
    }

    private void Start()
    {
        _currentState = _statePatrolling;
        _currentState.Enter();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
        {
            Attack(player);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _))
        {
            _currentState.Exit();
            _currentState = _stateHarassment;
            _currentState.Enter();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _))
        {
            _stateHarassment.SetTargetPosition(collision.gameObject.transform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _))
        {
            _currentState.Exit();
            _currentState = _statePatrolling;
            _currentState.Enter();
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
}
