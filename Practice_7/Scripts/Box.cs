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
        private float _lifeTime;

        private bool _intersection;

        private Color _defalteColor;
        private Color _newColor;

        private Renderer _renderer;

        public event Action<Box> BoxFalled;

        private void Awake()
        {
            _defalteColor = GetComponent<ColorChanger>().Color;
            _newColor = GetComponent<ColorChanger>().GetRandomColor();
            _renderer = GetComponent<Renderer>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Plane plane)) 
            {
                if (!_intersection)
                {
                    _intersection = !_intersection;
                    SetColor(_newColor);
                    StartCoroutine(TimerForDie(_lifeTime));
                }
            }
        }

        public void Init(Vector3 position)
        {
            float minRange = 2;
            float maxRange = 5;

            transform.position = position;
            SetColor(_defalteColor);
            _lifeTime = UnityEngine.Random.Range(minRange, maxRange);
            _intersection = false;
            gameObject.SetActive(true);
        }

        private IEnumerator TimerForDie(float delay)
        {
            var wait = new WaitForSeconds(delay);
            yield return wait;
            BoxFalled?.Invoke(this);
        }

        private void SetColor(Color color)
        {
            _renderer.material.color = color;
        }
    }
}
