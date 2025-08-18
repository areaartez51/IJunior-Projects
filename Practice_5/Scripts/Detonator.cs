using System.Collections.Generic;
using UnityEngine;

namespace Practice_5
{
    public class Detonator : MonoBehaviour
    {
        [SerializeField] private float _maxForceExplosion = 700;
        [SerializeField] private float _maxRadiusExplosion = 30;
        [SerializeField] private SpawnerHandler _spawnerHandler;

        private void OnEnable()
        {
            _spawnerHandler.RealisticExploded += DetonateRealistic;
            _spawnerHandler.CasualExploded += DetonateCasual;
        }

        private void OnDisable()
        {
            _spawnerHandler.RealisticExploded -= DetonateRealistic;
            _spawnerHandler.CasualExploded -= DetonateCasual;
        }

        private void DetonateCasual(List<Cube> Cubes, Vector3 positionExplosion)
        {
            foreach (Rigidbody rigidbody in GetRigidbodiesCubes(Cubes))
            {
                rigidbody.AddExplosionForce(_maxForceExplosion, positionExplosion, _maxRadiusExplosion);
            }
        }

        private void DetonateRealistic(Cube cube)
        {
            Vector3 positionExplosion = cube.transform.position;
            float localScaleCube = cube.transform.localScale.magnitude;

            Collider[] overlappedColliders = Physics.OverlapSphere(positionExplosion, _maxRadiusExplosion / localScaleCube);

            foreach (Rigidbody rigidbody in GetRigidbodiesCubes(overlappedColliders))
            {
                float currentDistance = Vector3.Distance(positionExplosion, rigidbody.transform.position);
                float normalizedCurrentDistanceExplosion = 1 - Mathf.Clamp01(currentDistance / _maxRadiusExplosion);
                float currentForceExplosion = Mathf.Lerp(0, _maxForceExplosion, normalizedCurrentDistanceExplosion) / localScaleCube;

                rigidbody.AddExplosionForce(currentForceExplosion, positionExplosion, _maxRadiusExplosion);
            }
        }

        private List<Rigidbody> GetRigidbodiesCubes<T>(IEnumerable<T> source) where T : Component
        {
            List<Rigidbody> rigidbodies = new List<Rigidbody>();

            foreach (var item in source)
                if (item.GetComponent<Rigidbody>() != null)
                    rigidbodies.Add(item.GetComponent<Rigidbody>());

            return rigidbodies;
        }
    }
}


