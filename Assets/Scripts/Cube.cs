using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Colorizer))]
public class Cube : MonoBehaviour
{
    private Colorizer _colorizer;
    private Rigidbody _rigidbody;
    private Coroutine _coroutine;
    private bool _isTimerLaunch = false;

    public event Action<Cube> TimeOuted;

    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _colorizer = GetComponent<Colorizer>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Platform>(out Platform platform))//
        {
            StartTimerDestroy();
        }
    }

    public void Initialize()
    {
        _isTimerLaunch = false;
        _colorizer.ChangeColorToDefault();
    }

    public void StartTimerDestroy()
    {
        if (_isTimerLaunch)
            return;
        
        _isTimerLaunch = true;
        _coroutine = StartCoroutine(LaunchTimer());  
    }

    private IEnumerator LaunchTimer()
    {
        int minDelay = 3;
        int maxDelay = 5;
        _colorizer.ChangeColorToRed();

        yield return new WaitForSeconds(UnityEngine.Random.Range(minDelay, maxDelay + 1));

        TimeOuted.Invoke(this);
    }
}
