using UnityEngine;

namespace UI.Buttons
{
    public class DamageButton : HealthButton
    {
        [SerializeField] private int _damageValue;
        
        protected override void ChangeHealth()
        {
            Health.TakeDamage(_damageValue);
        }  
    }
}