using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Cube>(out Cube cube))
        {
            cube.StartTimer();
        }
    }
}
