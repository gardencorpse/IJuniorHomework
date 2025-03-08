using UnityEngine;

public class RotateLocal : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 5f;

    void Update()
    {
        Vector3 direction = Vector3.up * _rotateSpeed * Time.deltaTime;
        transform.Rotate(direction, Space.Self);
    }
}
