using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 _moveDirection;
    private float _moveSpeed = 1.5f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
    }

    public void Initialize(int moveDirection)
    {
        transform.rotation = Quaternion.AngleAxis(moveDirection, Vector3.up);
    }
}
