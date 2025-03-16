using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
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

    public void Initialize(int splitChance, Vector3 scale)
    {
        _splitChance = splitChance;
        transform.localScale = scale;
    }
}
