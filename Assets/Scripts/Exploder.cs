using System.Collections.Generic;
using UnityEngine;

public class Exploder
{
    float _radius = 25f;
    float _power = 5f;
    float _powerUp = 3f;

    public void Explode(List<Rigidbody> rigidbodys)
    {
        foreach (Rigidbody rigidbody in rigidbodys)
        {
            rigidbody.AddExplosionForce(_power, rigidbody.position, _radius, _powerUp, ForceMode.Impulse);
        }
    }
}
