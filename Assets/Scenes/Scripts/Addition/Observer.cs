using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField] private GameObject _targetObserve;

    private void Update()
    {
        transform.position = new Vector3(_targetObserve.transform.position.x, _targetObserve.transform.position.y, -10);
    }
}
