using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    public event Action<Cube> OnClicked;

    private int _splitChance = 100;
    private Rigidbody _rigidbody;

    public Rigidbody Rigidbody => _rigidbody;
    public int SplitChance => _splitChance;

    public void Initialize(int splitChance, Vector3 scale)
    {
        _splitChance = splitChance;
        transform.localScale = scale;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        OnClicked?.Invoke(this);
    }
}
