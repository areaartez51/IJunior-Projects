using UnityEngine;

namespace Practice_6
{
    public class Mob : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Vector3 _direction;

        private void Update()
        {
            transform.Translate(_direction * _speed * Time.deltaTime);
        }

        public void Initialize(Quaternion rotation)
        {
            _direction = ConvertQuaternionToDirection(rotation);
        }

        private Vector3 ConvertQuaternionToDirection(Quaternion quaternion)
        {
            return quaternion * Vector3.forward;
        }
    }
}

