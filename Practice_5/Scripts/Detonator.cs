using System.Collections.Generic;
using UnityEngine;

namespace Practice_5
{
    public class Detonator : MonoBehaviour
    {
        [SerializeField] private float _maxForceExplosion = 700;
        [SerializeField] private float _maxRadiusExplosion = 30;

        private void CasualExplode(List<Cube> Cubes, Vector3 positionExplosion)
        {
            foreach (Rigidbody rigidbody in GetRigidbodyCubes(Cubes))
            {
                rigidbody.AddExplosionForce(_maxForceExplosion, positionExplosion, _maxRadiusExplosion);
            }
        }

        private void RealisticExplode(Cube cube)
        {
            Vector3 positionExplosion = cube.transform.position;
            float localScaleCube = cube.transform.localScale.magnitude;

            Collider[] overlappedColliders = Physics.OverlapSphere(positionExplosion, _maxRadiusExplosion / localScaleCube);

            List<Rigidbody> rigidbodies = GetRigidbodyCubes(overlappedColliders);

            foreach (Rigidbody rigidbody in rigidbodies)
            {
                float currentDistance = Vector3.Distance(positionExplosion, rigidbody.transform.position);
                float normalizedCurrentDistanceExplosion = 1 - Mathf.Clamp01(currentDistance / _maxRadiusExplosion);
                float currentForceExplosion = Mathf.Lerp(0, _maxForceExplosion, normalizedCurrentDistanceExplosion) / localScaleCube;

                rigidbody.AddExplosionForce(currentForceExplosion, positionExplosion, _maxRadiusExplosion);
            }
        }

        private List<Rigidbody> GetRigidbodyCubes(Collider[] overlappedColliders)
        {
            List<Rigidbody> rigidbodies = new List<Rigidbody>();

            foreach (Collider collider in overlappedColliders)
                if (collider.GetComponent<Rigidbody>() != null)
                    rigidbodies.Add(collider.GetComponent<Rigidbody>());

            return rigidbodies;
        }

        private List<Rigidbody> GetRigidbodyCubes(List<Cube> Cubes)
        {
            List<Rigidbody> rigidbodies = new List<Rigidbody>();

            foreach (Cube cube in Cubes)
                if (cube.GetComponent<Rigidbody>() != null)
                    rigidbodies.Add(cube.GetComponent<Rigidbody>());

            return rigidbodies;
        }

        private void OnEnable()
        {
            CubeFactory.RealisticExploded += RealisticExplode;
            CubeFactory.CasualExploded += CasualExplode;
        }

        private void OnDisable()
        {
            CubeFactory.RealisticExploded -= RealisticExplode;
            CubeFactory.CasualExploded -= CasualExplode;
        }
    }
}


