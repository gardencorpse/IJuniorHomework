using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(MeshRenderer))]
public class Coin : MonoBehaviour
{
    public int Value { get; private set; } = 1;

    [SerializeField] private float _changeScaleSpeed = 0.05f;
    private Collider2D _collider;
    private MeshRenderer _meshRenderer;
    private Coroutine _coroutine;

    public event Action<Coin> Collected;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Initialize()
    {
        _collider.enabled = true;
        StartCoroutine(LaunchVisualize());
    }

    public void Pick()
    {
        _collider.enabled = false;

        Collected?.Invoke(this);
    }

    public void Hide()
    {
        StartCoroutine(LaunchHiding(Vector3.zero));
    }

    public void Respawn(int delay)
    {
        _coroutine = StartCoroutine(LaunchRespawn(delay));
    }

    private IEnumerator LaunchRespawn(int delay)
    {
        var wait = new WaitForSeconds(delay);

        yield return wait;
        _meshRenderer.enabled = true;
        Initialize();
    }

    private IEnumerator LaunchVisualize()
    {
        var wait = new WaitForEndOfFrame();

        while (transform.localScale.x <= 1)
        {
            transform.localScale += new Vector3(_changeScaleSpeed, _changeScaleSpeed, _changeScaleSpeed);
            yield return wait;
        }

        transform.localScale = Vector3.one;
        _meshRenderer.enabled = true;
    }

    private IEnumerator LaunchHiding(Vector3 vector)
    {
        var wait = new WaitForEndOfFrame();

        while (Mathf.Approximately(transform.localScale.x, 0) == false)
        {
//            transform.localScale -= new Vector3(_changeScaleSpeed, _changeScaleSpeed, _changeScaleSpeed);
            transform.localScale = Vector3.MoveTowards(transform.localScale, vector, _changeScaleSpeed);
            yield return wait;
        }

        transform.localScale = Vector3.zero;
        _meshRenderer.enabled = false;
    }
}
