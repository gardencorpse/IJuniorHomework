using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Light))]
public class FlashingLight : MonoBehaviour
{
    private Light _light;
    private float _maxIntensity = 1f;
    private float _minIntensity = 0f;
    private float _speed = 0.1f;
    private bool _isIncrease = true;
    private Coroutine _coroutine;

    private void Start()
    {
        _light = GetComponent<Light>();
    }

    public void StartFlashLight()
    {
        StopCoroutine();
        _coroutine = StartCoroutine(StartFlashing());
    }
    
    public void StopFlashLight()
    {
        StopCoroutine();
        _coroutine = StartCoroutine(StopFlashing());
    }

    private void StopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator StartFlashing()
    {
        var wait = new WaitForFixedUpdate();

        while (enabled)
        {
            yield return wait;

            if (_isIncrease)
            {
                _light.intensity = Mathf.MoveTowards(_light.intensity, _maxIntensity, _speed);
            }
            else
            {
                _light.intensity = Mathf.MoveTowards(_light.intensity, _minIntensity, _speed);
            }

            if (_light.intensity >= _maxIntensity || _light.intensity <= _minIntensity)
            {
                _isIncrease = !_isIncrease;
            }
        }
    }

    private IEnumerator StopFlashing()
    {
        var wait = new WaitForFixedUpdate();

        while (_light.intensity > 0)
        {
            yield return wait;
            _light.intensity = Mathf.MoveTowards(_light.intensity, _minIntensity, _speed);
        }
    }
}
