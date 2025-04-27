using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _wayPointsContainer;
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _speed = 2;

    private int _currentIndex = 0;
    private bool _isLookingRight = true;

#if UNITY_EDITOR
    [ContextMenu("Refresh Child Array")]
    private void RefreshChildArray()
    {
        _wayPoints = new Transform[_wayPointsContainer.childCount];

        if (_wayPoints.Length == 0)
        {
            Debug.LogWarning("Places Container is Empty!");
        }

        for (int i = 0; i < _wayPoints.Length; i++)
        {
            _wayPoints[i] = _wayPointsContainer.GetChild(i);
        }
    }
#endif

    private void Update()
    {
        if (transform.position == _wayPoints[_currentIndex].position)
        {
            _currentIndex = ++_currentIndex % _wayPoints.Length;
            CheckLookDirection();
        }

        transform.position = Vector2.MoveTowards(transform.position, _wayPoints[_currentIndex].position, _speed * Time.deltaTime);
        //transform.LookAt(_wayPoints[_currentIndex].position);
    }

    private void CheckLookDirection()
    {
        bool isNeedLookRight = _wayPoints[_currentIndex].position.x > transform.position.x;

        if (_isLookingRight && isNeedLookRight == false)
        {
            Flip();
        }
        else if(_isLookingRight == false && isNeedLookRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isLookingRight = !_isLookingRight;
        transform.Rotate(0, 180, 0);
    }
}
