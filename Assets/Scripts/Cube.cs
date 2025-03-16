using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    public int ExplosionMultiplier { get; private set; } = 1;

    private int _splitChance = 100;
    private Rigidbody _rigidbody;

    public event Action<Cube> Clicked;

    public int SplitChance => _splitChance;
    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    public void OnMouseClick()
    {
        Clicked?.Invoke(this);
        Destroy(gameObject);
    }

    public void Initialize(int explosionMultiplier, int splitChance, Vector3 scale)
    {
        ExplosionMultiplier = explosionMultiplier;
        _splitChance = splitChance;
        transform.localScale = scale;
    }
}
