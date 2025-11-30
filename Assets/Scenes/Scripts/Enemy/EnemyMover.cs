using UnityEngine;

[RequireComponent(typeof(Rotator))]
[RequireComponent(typeof(EnemyAnimation))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speedMovement = 1f;

    private float _horizontalDirection;

    private EnemyAnimation _enemyAnimation;
    private Rotator _rotator;


    private void Awake()
    {
        _enemyAnimation = GetComponent<EnemyAnimation>();
        _rotator = GetComponent<Rotator>();
    }

    public void Move(float targetPointX)
    {
        Vector2 targetPoint = new Vector2(targetPointX, transform.position.y);
        _horizontalDirection = targetPoint.x - transform.position.x;

        _rotator.TurnAround(_horizontalDirection);

        transform.position = Vector2.MoveTowards(transform.position, targetPoint, _speedMovement * Time.deltaTime);

        _enemyAnimation.SetSpeed(_horizontalDirection);
    }
}
