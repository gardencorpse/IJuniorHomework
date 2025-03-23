using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Rigidbody Rigidbody => _rigidbody;
    public event Action<Cube> OnTimeOuted;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void StartTimer()
    {


    }
}
