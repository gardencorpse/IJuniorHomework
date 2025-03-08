using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 5f;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        Vector3 direction = Vector3.up * _rotateSpeed * Time.deltaTime;
        transform.Rotate(direction);
    }
}
