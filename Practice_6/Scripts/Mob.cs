using UnityEngine;

namespace Practice_6
{
    public class Mob : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void Update()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.Self);
        }
    }
}

