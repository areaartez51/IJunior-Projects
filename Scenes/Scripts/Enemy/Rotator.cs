using UnityEngine;

namespace Platformer
{
    public class Rotator : MonoBehaviour
    {
        private Quaternion _rotation;
        private float _glanceRight = 0;
        private float _glanceLeft = 180;

        public void TurnAround(float horizontalDirection)
        {
            if (horizontalDirection >= 0)
                _rotation.y = _glanceRight;
            else
                _rotation.y = _glanceLeft;

            transform.rotation = _rotation;
        }
    }
}

