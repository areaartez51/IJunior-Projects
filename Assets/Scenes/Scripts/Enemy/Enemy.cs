using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[RequireComponent(typeof(StateHarassment))]
[RequireComponent(typeof(StatePatrolling))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private int _hitPoint = 100;
    [SerializeField] private int _damage = 10;

    private StatePatrolling _statePatrolling;
    private StateHarassment _stateHarassment;

    private EnemyStateMachine _currentState;

    private void Awake()
    {
        _statePatrolling = GetComponent<StatePatrolling>();
        _stateHarassment = GetComponent<StateHarassment>();
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
        _hitPoint -= damage;

        if( _hitPoint <= 0)
            Destroy(gameObject);
    }
}
