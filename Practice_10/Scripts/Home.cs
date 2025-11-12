using System;
using UnityEngine;

public class Home : MonoBehaviour
{
    public event Action<Collider> BreakingInto;
    public event Action LeftHouse;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Thief thief))
        {
            BreakingInto?.Invoke(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        LeftHouse?.Invoke();
    }
}
