using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    [RequireComponent(typeof(Slider))]

    public class VampirismViewLogic : VampirismViewData
    {
        protected Slider Slider;
        protected float StartValue;
        protected float EndValue;

        private void Awake()
        {
            Slider = GetComponent<Slider>();
        }

        protected override void UpdateView(int maxValue)
        {
            if (Mathf.Approximately(maxValue, TimeWorkSkill))
            {
                StartValue = 1f;
                EndValue = 0f;
            }
            else if (Mathf.Approximately(maxValue, CooldownSkill))
            {
                StartValue = 0f;
                EndValue = 1f;
            }
            else
            {
                throw new System.Exception($"Неожиданное значение - {maxValue}");
            }
        }
    }
}
