using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Radar : MonoBehaviour
{
    private float _timeWork;
    private float _timeRecovery;

    private bool _isWork;

    private SphereCollider _sphereCollider;
    private DataStorageScanner _dataStorageScanner;

    public void Init(RadarConfig radarConfig, DataStorageScanner dataStorageScanner, Network network)
    {
        _timeWork = radarConfig.TimeWork;
        _timeRecovery = radarConfig.TimeRecovery;

        _dataStorageScanner = dataStorageScanner;
        _dataStorageScanner.Init(network);

        _sphereCollider = GetComponent<SphereCollider>();
        _sphereCollider.radius = radarConfig.RadiusScane;

        _sphereCollider.enabled = false;

        StartWork();
    }

    private void StartWork()
    {
        StartCoroutine(Work());
    }

    private void OnEnable()
    {
        _isWork = true;
    }

    private void OnDisable()
    {
        _isWork = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Crystal crystal))
        {
            _dataStorageScanner.Add(crystal);
        }
    }

    private IEnumerator Work()
    {
        while (_isWork)
        {
            ChangeWork();
            yield return new WaitForSeconds(_timeWork);

            ChangeWork();
            yield return new WaitForSeconds(_timeRecovery);
        }
    }

    private void ChangeWork() => _sphereCollider.enabled = !_sphereCollider.enabled;
}