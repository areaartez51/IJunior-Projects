using UnityEngine;

[RequireComponent(typeof(EnemyAnimation))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private float _horizontalDirection;

    private EnemyAnimation _enemyAnimation;

    private Quaternion _rotation;
    private float _glanceRight = 0;
    private float _glanceLeft = 180;

    private void Awake()
    {
        _enemyAnimation = GetComponent<EnemyAnimation>();
    }

    public void Move(float targetPointX)
    {
        Vector2 targetPoint = new Vector2(targetPointX, transform.position.y);
        _horizontalDirection = targetPoint.x - transform.position.x;

        TurnAround(_horizontalDirection);

        transform.position = Vector2.MoveTowards(transform.position, targetPoint, _speed * Time.deltaTime);

        _enemyAnimation.SetSpeed(_horizontalDirection);
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
