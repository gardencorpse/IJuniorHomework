using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform _target;
    private float _moveSpeed = 1.5f;

    private void Update()
    {
        Move();
    }

    public void Initialize(Transform target)
    {
        _target = target;
    }

    private void Move()
    {
        transform.LookAt(_target);
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _moveSpeed * Time.deltaTime);
    }
}
