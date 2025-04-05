using UnityEngine;

public class Scammer : MonoBehaviour
{
    [SerializeField] private Transform _wayPointsContainer;
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _speed = 2;

    private int _currentIndex = 0;

#if UNITY_EDITOR
    [ContextMenu("Refresh Child Array")]
    private void RefreshChildArray()
    {
        _wayPoints = new Transform[_wayPointsContainer.childCount];

        if (_wayPoints.Length == 0)
        {
            Debug.LogWarning("Places Container не имеет дочерних объектов!");
        }

        for (int i = 0; i < _wayPoints.Length; i++)
        {
            _wayPoints[i] = _wayPointsContainer.GetChild(i);
        }
    }
#endif

    private void Update()
    {
        if(transform.position == _wayPoints[_currentIndex].position)
        {
            _currentIndex = ++_currentIndex % _wayPoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentIndex].position, _speed * Time.deltaTime);
        transform.LookAt(_wayPoints[_currentIndex].position);
    }
}
