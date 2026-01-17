using UnityEngine;

namespace UI.Buttons
{
    public class HealButton : HealthButton
    {
        [SerializeField] private int _healValue;
        
        protected override void ChangeHealth()
        {
            Health.HealItself(_healValue);
        } 
    }
}