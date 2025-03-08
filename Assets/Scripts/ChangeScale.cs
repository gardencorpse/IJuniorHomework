using UnityEngine;

public class ChangeScale : MonoBehaviour
{
    [SerializeField] private float _scaleChangeSpeed = 0.1f;

    void Update()
    {
        Vector3 direction = new Vector3(_scaleChangeSpeed, _scaleChangeSpeed, _scaleChangeSpeed) * Time.deltaTime;
        transform.localScale += direction;
    }
}
