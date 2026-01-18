using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(Animator))]

    public class PlayerAnimation : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetSpeed(float speed)
        {
            _animator.SetFloat(AnimatorData.Speed, Mathf.Abs(speed));
        }

        public void TriggerJump()
        {
            _animator.SetTrigger(AnimatorData.Jump);
        }
    }
}

