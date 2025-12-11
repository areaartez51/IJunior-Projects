using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private GameObject _targetObserve;

    private void LateUpdate()
    {
        if (_targetObserve != null)
            transform.position = new Vector3(_targetObserve.transform.position.x, _targetObserve.transform.position.y, -10);
    }
}
