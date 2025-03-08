using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        Vector3 direction = Vector3.forward * _moveSpeed * Time.deltaTime;
        transform.Translate(direction);
    }
}
