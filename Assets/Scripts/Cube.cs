using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    public int ExplosionMultiplier { get; private set; } = 1;

    private int _splitChance = 100;
    private Rigidbody _rigidbody;
    public int SplitChance => _splitChance;
    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(int explosionMultiplier, int splitChance, Vector3 scale)
    {
        ExplosionMultiplier = explosionMultiplier;
        _splitChance = splitChance;
        transform.localScale = scale;
    }

    public bool IsSplit()
    {
        int maxChance = 100;
        int randomChance = UnityEngine.Random.Range(1, maxChance + 1);

        return _splitChance >= randomChance;
    }
}
