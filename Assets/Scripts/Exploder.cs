using System.Collections.Generic;
using UnityEngine;

public class Exploder
{
    private float _radius = 5f;
    private float _power = 5f;
    private float _powerUp = 3f;

    public void Explode(List<Rigidbody> rigidbodys)
    {
        foreach (Rigidbody rigidbody in rigidbodys)
        {
            rigidbody.AddExplosionForce(_power, rigidbody.position, _radius, _powerUp, ForceMode.Impulse);
        }
    }
    public void Explode(List<Rigidbody> rigidbodys,Vector3 position, int explosionMultiplier)
    {
        foreach (Rigidbody rigidbody in rigidbodys)
        {
            rigidbody.AddExplosionForce(_power * explosionMultiplier, position, _radius * explosionMultiplier, _powerUp, ForceMode.Impulse);
        }
    }

    public List<Rigidbody> GetExplodableObjects(Vector3 position)
    {
        Collider[] hits = Physics.OverlapSphere(position, _radius);

        List<Rigidbody> rigidbodies = new();
        foreach (Collider hit in hits)
            if (hit.TryGetComponent(out Rigidbody cube))
                rigidbodies.Add(cube);

        return rigidbodies;
    }
}
