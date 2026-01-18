using UnityEngine;

namespace Platformer
{
    public class TargetFollower : MonoBehaviour
    {
        [SerializeField] private GameObject _targetObserve;
        [SerializeField] private float _distanceFromGoal = -10;

        private void LateUpdate()
        {
            if (_targetObserve != null)
                transform.position = new Vector3(_targetObserve.transform.position.x, _targetObserve.transform.position.y, _distanceFromGoal);
        }
    }
}