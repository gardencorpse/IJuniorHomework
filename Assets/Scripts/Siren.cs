using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Siren : MonoBehaviour
{
    private AudioSource _source;
    private Coroutine _coroutine;
    private float _changeSpeed = 0.02f;
    private float _maxVolume = 1f;
    private float _minVolume = 0f;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    public void StartSiren()
    {
        StopCoroutine();
        _coroutine = StartCoroutine(IncreaseVolume(_maxVolume));
    }

    public void StopSiren()
    {
        StopCoroutine();
        _coroutine = StartCoroutine(DecreaseVolume(_minVolume));
    }

    private void StopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator IncreaseVolume(float targetVolume)
    {
        _source.Play();

        yield return ChangeVolume(targetVolume);
    }

    private IEnumerator DecreaseVolume(float targetVolume)
    {
        yield return ChangeVolume(targetVolume);

        _source.Stop();
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        var wait = new WaitForFixedUpdate();

        while (Mathf.Approximately(targetVolume, _source.volume) == false)
        {
            yield return wait;
            _source.volume = Mathf.MoveTowards(_source.volume, targetVolume, _changeSpeed);
        }

        _source.volume = targetVolume;
    }
}
