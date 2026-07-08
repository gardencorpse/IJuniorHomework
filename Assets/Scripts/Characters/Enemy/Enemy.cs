using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Enemy : Entity
{
    [SerializeField] private Transform _wayPointsContainer;
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _detectDistance;
    [SerializeField] private Animator _animator;

    private EnemyAnimator _enemyAnimator;
    private int _currentIndex = 0;

    private void Awake()
    {
        _enemyAnimator = new EnemyAnimator(_animator);
    }

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
        if (TryDetectPlayer(out Transform playerPosition))
        {
            Chase(playerPosition);
        }
        else
        {
            Patrol();
        }
    }

    private bool TryDetectPlayer(out Transform playerPosition)
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.right), _detectDistance, _layerMask);

        if (hit)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * _detectDistance, Color.yellow);
            Debug.Log("Did Hit");
            playerPosition = hit.transform;
            return true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * _detectDistance, Color.white);
            Debug.Log("Did not Hit");
            playerPosition = null;
            return false;
        }
    }

    private void Chase(Transform playerPosition)
    {
        if(Vector3.Distance(transform.position, playerPosition.position) > 1f)
        {
            Move(playerPosition);
        }
        else
        {
            _enemyAnimator.ChangeAttackState(true);

        }
    }

    private void Patrol()
    {
        if ((transform.position - _wayPoints[_currentIndex].position).sqrMagnitude < 0.01f)
        {
            _currentIndex = ++_currentIndex % _wayPoints.Length;
            UpdateLookDirection();
        }

        _enemyAnimator.ChangeAttackState(false);
        Move(_wayPoints[_currentIndex]);
    }

    private void Move(Transform target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
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
