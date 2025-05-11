using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _wayPointsContainer;
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _speed = 2;
    [SerializeField] private Flipper _flipper;

    private int _currentIndex = 0;

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
            UpdateLookDirection();
        }

        transform.position = Vector2.MoveTowards(transform.position, _wayPoints[_currentIndex].position, _speed * Time.deltaTime);
    }

    private void UpdateLookDirection()
    {
        bool isNeedLookRight = _wayPoints[_currentIndex].position.x > transform.position.x;

        if (_flipper.IsLookingRight && isNeedLookRight == false)
        {
            _flipper.Flip();
        }
        else if(_flipper.IsLookingRight == false && isNeedLookRight)
        {
            _flipper.Flip();
        }
    }
}
