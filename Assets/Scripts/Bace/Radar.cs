using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public class Radar : MonoBehaviour
{
    [SerializeField] private float _timeWork = 1f;
    [SerializeField] private float _timeRecovery = 5f;

    [SerializeField] private int _radius = 4;

    [SerializeField] private List<ISearchable> _detectedObj = new();

    private SphereCollider _sphereCollider;

    public event Action<List<ISearchable>> UpdateDate;

    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _sphereCollider.radius *= _radius;
    }

    private void Start()
    {
        _sphereCollider.enabled = false;
        StartCoroutine(CoolDownScane());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Crystal mineral) && !_detectedObj.Contains(mineral))
        {
            _detectedObj.Add(mineral);
        }
    }

    private IEnumerator CoolDownScane()
    {
        while (true)
        {
            ChangeWork();
            yield return new WaitForSeconds(_timeWork);

            ChangeWork();
            UpdateDate?.Invoke(_detectedObj);
            _detectedObj.Clear();
            yield return new WaitForSeconds(_timeRecovery);
        }
    }

    private void ChangeWork()=> _sphereCollider.enabled = !_sphereCollider.enabled;
}