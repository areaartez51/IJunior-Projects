using System;
using UnityEngine;

namespace Practice_5
{
    public class PlayerInput : MonoBehaviour
    {
        public event Action OnClick;

        private int _leftClick = 0;

        private void Update()
        {
            if (Input.GetMouseButtonDown(_leftClick))
                OnClick?.Invoke();
        }
    }
}


