using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    public event Action BreakingInto;
    public event Action LeftHouse;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Thief thief))
        {
            BreakingInto?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Thief thief))
        {
            LeftHouse?.Invoke();
        }
    }
}
