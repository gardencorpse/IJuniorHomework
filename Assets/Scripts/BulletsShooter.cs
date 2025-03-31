using System.Collections;
using UnityEngine;

public class BulletsShooter : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private float _force;
    [SerializeField] private float _shootDelay;

    private void Start()
    {
        StartCoroutine(StartShooting());
    }

    IEnumerator StartShooting()
    {
        var wait = new WaitForSeconds(_shootDelay);

        while (enabled)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Rigidbody newBullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            newBullet.transform.up = direction;
            newBullet.linearVelocity = direction * _force;

            yield return wait;
        }
    }
}