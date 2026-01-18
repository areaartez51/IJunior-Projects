using System;
using UnityEngine;

namespace Platformer
{
    public class GroundDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _groundCheckRadius = 0.1f;
        [SerializeField] private float _offsetY = 0.5f;

        private RaycastHit2D[] _raycastHit = new RaycastHit2D[1];

        public event Action<bool> Grounded;

        private void FixedUpdate()
        {
            IsGround();
        }

        private void IsGround()
        {
            Vector2 pointUnderfoot = new Vector2(transform.position.x, transform.position.y - _offsetY);

            int hitCount = Physics2D.RaycastNonAlloc(pointUnderfoot, Vector2.down,
                _raycastHit, _groundCheckRadius, _groundLayer);

            Grounded?.Invoke(hitCount > 0);
        }
    }
}

