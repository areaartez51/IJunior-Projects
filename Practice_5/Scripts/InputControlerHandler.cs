using System;
using UnityEngine;

namespace Practice_5
{
    public class InputControlerHandler : MonoBehaviour
    {
        public event Action OnClick;

        public void IsClick()
        {
            OnClick?.Invoke();
        }
    }
}
