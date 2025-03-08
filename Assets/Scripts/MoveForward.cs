using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private void Update()
    {
        Vector3 direction = Vector3.forward * _moveSpeed * Time.deltaTime;
        transform.Translate(direction);
    }
}
