using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(Vector3 target)
    {
        _rigidbody.transform.up = target;
        _rigidbody.velocity = target * _speed;
    }
}
