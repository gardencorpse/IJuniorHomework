using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f;

    private void Update()
    {
        ChangeScale();
    }

    private void ChangeScale()
    {
        Vector3 direction = new Vector3(_speed, _speed, _speed) * Time.deltaTime;
        transform.localScale += direction;
    }
}
