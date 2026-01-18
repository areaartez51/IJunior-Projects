using UnityEngine;

namespace Platformer
{
    [RequireComponent(typeof(Animator))]

    public class EnemyAnimation : MonoBehaviour
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
    }
}

