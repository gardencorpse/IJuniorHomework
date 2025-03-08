using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        Vector3 direction = Vector3.up * _speed * Time.deltaTime;
        transform.Rotate(direction);
    }
}
