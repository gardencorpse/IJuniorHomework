using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Colorizer))]
public class Cube : MonoBehaviour
{
    private Colorizer _colorizer;
    private Rigidbody _rigidbody;
    private Coroutine _coroutine;
    private bool _isTouchPlatform = false;

    public event Action<Cube> TimeOuted;

    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _colorizer = GetComponent<Colorizer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isTouchPlatform)
            return;

        if (collision.gameObject.TryGetComponent<Platform>(out Platform _))
        {
            _isTouchPlatform = true;
            _colorizer.ChangeColorToRed();
            StartTimerDestroy();
        }
    }

    public void Initialize()
    {
        _isTouchPlatform = false;
        _colorizer.ChangeColorToDefault();
    }

    private void StartTimerDestroy()
    {
        _coroutine = StartCoroutine(LaunchTimer());  
    }

    private IEnumerator LaunchTimer()
    {
        int minDelay = 3;
        int maxDelay = 5;

        yield return new WaitForSeconds(UnityEngine.Random.Range(minDelay, maxDelay + 1));

        TimeOuted.Invoke(this);
    }
}
