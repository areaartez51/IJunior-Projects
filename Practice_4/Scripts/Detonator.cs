using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 70;
    [SerializeField] private float _explosionForce = 700;

    public void Explode()
    {
        List<Rigidbody> rigidbodys = GetExplodableObjects();

        foreach (Rigidbody explodableObjects in rigidbodys)
        {
            explodableObjects.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> rigidbodys = new();

        foreach (Collider hit in hits)
        {
            Rigidbody rigidbody = hit.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbodys.Add(rigidbody);
            }
        }

        return rigidbodys;
    }
}
