using System;
using UnityEngine;

namespace Platformer
{
    public class InputReader : MonoBehaviour
    {
        private const string Horizontal = nameof(Horizontal);
        private const KeyCode JumpKeyCode = KeyCode.Space;
        private const KeyCode SpellKeyCode = KeyCode.E;

        public event Action<float> HorizontalMovement;
        public event Action Jumping;
        public event Action SpellActivated;

        private void Update()
        {
            MoveControl();
            JumpControl();
            SpellControl();
        }

        private void MoveControl()
        {
            float horizontalDirection = Input.GetAxis(Horizontal);

            if (horizontalDirection != 0)
                HorizontalMovement?.Invoke(horizontalDirection);
        }

        private void JumpControl()
        {
            if (Input.GetKeyDown(JumpKeyCode))
                Jumping?.Invoke();
        }

        private void SpellControl()
        {
            if (Input.GetKeyDown(SpellKeyCode))
                SpellActivated?.Invoke();
        }
    }
}

