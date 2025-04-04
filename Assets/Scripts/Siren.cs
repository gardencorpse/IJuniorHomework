using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Siren : MonoBehaviour
{
    [SerializeField] private Observer observer;
    [SerializeField] private FlashingLight flashingLight;
    private AudioSource _source;
    private Coroutine _coroutine;
    private float _changeSpeed = 0.02f;
    private float _maxVolume = 1f;
    private float _minVolume = 0f;

    private void OnEnable()
    {
        observer.Spotted += OnSpotted;
        observer.Losted += OnLosted;
    }

    private void OnDisable()
    {
        observer.Spotted -= OnSpotted;
        observer.Losted -= OnLosted;
    }

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    private void OnSpotted()
    {
        StopCoroutine();
        _coroutine = StartCoroutine(IncreaseVolume());
        flashingLight?.StartFlashLight();
    }

    private void OnLosted()
    {
        StopCoroutine();
        _coroutine = StartCoroutine(DecreaseVolume());
        flashingLight?.StopFlashLight();
    }

    private void StopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator IncreaseVolume()
    {
        var wait = new WaitForFixedUpdate();
        _source.Play();

        while (_source.volume < 1)
        {
            yield return wait;
            _source.volume = Mathf.MoveTowards(_source.volume, _maxVolume, _changeSpeed);
        }
    }

    private IEnumerator DecreaseVolume()
    {
        var wait = new WaitForFixedUpdate();

        while (_source.volume > 0)
        {
            yield return wait;
            _source.volume = Mathf.MoveTowards(_source.volume, _minVolume, _changeSpeed);
        }

        _source.Stop();
    }
}
