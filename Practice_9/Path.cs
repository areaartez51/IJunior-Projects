using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] private Transform _point;

    private int _currentPointIndex;
    private Transform [] _pathPoints;

    private void Start()
    {
        _currentPointIndex = 0;

        _pathPoints = new Transform[_point.childCount];

        for (int i = 0; i < _point.childCount; i++)
        {
            _pathPoints[i] = _point.GetChild(i);
        }
    }

    private void Update()
    {
        Transform currentPoint = _pathPoints[_currentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, _speed * Time.deltaTime);

        if (transform.position == currentPoint.position) 
            ChangeCurrentPoint();
    }

    private void ChangeCurrentPoint()
    {
        _currentPointIndex++;

        if (_currentPointIndex == _pathPoints.Length)
        {
            _currentPointIndex = 0;
        }
    }
}
