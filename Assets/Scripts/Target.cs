using UnityEngine;

public class Target : MonoBehaviour
{
    private Transform[] _waypoints;
    private float _speed = 4f;
    private int _currentWaypoint = 0;

    private void Update()
    {
        if (_waypoints.Length <= 0)
            return;

        if (transform.position == _waypoints[_currentWaypoint].position)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }

    public void Initialize(Transform[] waypoints)
    {
        _waypoints = waypoints;
    }
}
