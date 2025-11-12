using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Transform _point;

    private Vector3 _startPositon;
    private Vector3 _direction;

    private void Start()
    {
        _startPositon = transform.position;
        _direction = _point.position;
    }

    private void Update()
    {
        if (transform.position.x == _point.position.x && transform.position.z == _point.position.z)
        {
            _direction = _startPositon;
        }

        transform.position = Vector3.MoveTowards(transform.position, _direction, _speed * Time.deltaTime);
    }
}
