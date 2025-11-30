using System;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundCheckRadius = 0.1f;
    [SerializeField] private float _offsetY = 0.5f;

    private RaycastHit2D[] _raycastHit = new RaycastHit2D[1];

    public event Action<bool> GroundedChanged;

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void CheckGround()
    {
        Vector2 pointUnderfoot = new Vector2(transform.position.x, transform.position.y - _offsetY);

        int hitCount = Physics2D.RaycastNonAlloc(pointUnderfoot, Vector2.down,
            _raycastHit, _groundCheckRadius, _groundLayer);

        GroundedChanged?.Invoke(hitCount > 0);
    }
}
