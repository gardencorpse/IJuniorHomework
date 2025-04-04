using System;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public event Action Spotted;
    public event Action Losted;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Scammer scammer))
        {
            Spotted?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Scammer scammer))
        {
            Losted?.Invoke();
        }
    }
}
