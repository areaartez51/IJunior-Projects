using System;
using UnityEngine;

namespace Practice_5
{
    public class InputControler : MonoBehaviour
    {
        [SerializeField] private InputControlerHandler _inputControlerHandler;

        private int _leftClick = 0;

        private void Update()
        {
            if (Input.GetMouseButtonDown(_leftClick))
                _inputControlerHandler.IsClick();
        }
    }
}


