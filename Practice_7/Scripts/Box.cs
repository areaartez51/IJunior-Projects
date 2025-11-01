using System;
using System.Collections;
using UnityEngine;

namespace Practice_7
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Renderer))]
    [RequireComponent(typeof(ColorChanger))]

    public class Box : MonoBehaviour
    {
        private Plane Plane;
        private float _lifeTime;
        private bool _intersection;

        public static event Action<Box> CubeFalled;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag == nameof(Plane)) 
            {
                if (!_intersection)
                {
                    _intersection = !_intersection;
                    SetColor(GetComponent<ColorChanger>().GetRandomColor());
                    StartCoroutine(TimerForDie(_lifeTime));
                }
            }
        }

        public void Init(Vector3 position)
        {
            float minRange = 2;
            float maxRange = 5;

            transform.position = position;
            SetColor(GetComponent<ColorChanger>().Ñolor);
            _lifeTime = UnityEngine.Random.Range(minRange, maxRange);
            _intersection = false;
            gameObject.SetActive(true);
        }

        private IEnumerator TimerForDie(float delay)
        {
            var wait = new WaitForSeconds(delay);
            yield return wait;
            CubeFalled?.Invoke(this);
        }

        private void SetColor(Color color)
        {
            GetComponent<Renderer>().material.color = color;
        }
    }
}
