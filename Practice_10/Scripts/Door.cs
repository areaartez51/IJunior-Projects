using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    public event Action BreakingInto;
    public event Action LeftHouse;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Thief>(out _))
        {
            BreakingInto?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Thief>(out _))
        {
            LeftHouse?.Invoke();
        }
    }
}
