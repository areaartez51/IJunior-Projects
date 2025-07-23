using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 70;
    [SerializeField] private float _explosionForce = 700;

    public void Explode(List<Rigidbody> rigidbodys, Vector3 positionExplosion)
    {
        foreach (Rigidbody explodableObjects in rigidbodys)
            explodableObjects.AddExplosionForce(_explosionForce, positionExplosion, _explosionRadius);
    }
}
