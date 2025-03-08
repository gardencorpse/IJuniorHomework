using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        Vector3 direction = Vector3.forward * _speed * Time.deltaTime;
        transform.Translate(direction);
    }
}
