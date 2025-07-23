using System;
using UnityEngine;

public class InputControler : MonoBehaviour
{
    public static event Action MouseButtonDown;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            MouseButtonDown?.Invoke();
    }
}
