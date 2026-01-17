using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    [RequireComponent(typeof(Button))]

    public abstract class HealthButton : MonoBehaviour
    {
        [SerializeField] protected Health Health;
        
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        } 
            
        private void OnEnable() 
        {
            _button.onClick.AddListener(ChangeHealth);
        }
            
        private void OnDisable() 
        {
            _button.onClick.RemoveListener(ChangeHealth);
        } 
            
        protected abstract void ChangeHealth();
    }
}