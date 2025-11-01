using UnityEngine;

namespace Practice_7
{
    public class ColorChanger : MonoBehaviour
    {
        public Color Ñolor = Color.red;

        public Color GetRandomColor()
        {
            float colorChannelR = Random.value;
            float colorChannelG = Random.value;
            float colorChannelB = Random.value;

            return new Color(colorChannelR, colorChannelG, colorChannelB);
        }
    }
}
