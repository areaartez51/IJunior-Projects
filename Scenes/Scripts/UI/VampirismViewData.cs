using UnityEngine;

namespace Platformer
{
    public abstract class VampirismViewData : MonoBehaviour
    {
        [SerializeField] protected Vampirism Vampirism;

        protected int TimeWorkSkill;
        protected int CooldownSkill;

        private void OnEnable()
        {
            Vampirism.Initialized += Initialize;
            Vampirism.ChangedStatusSkill += UpdateView;
        }

        private void OnDisable()
        {
            Vampirism.Initialized -= Initialize;
            Vampirism.ChangedStatusSkill -= UpdateView;
        }

        protected abstract void UpdateView(int maxValue);

        private void Initialize(int timeWorkSkill, int cooldownSkill)
        {
            TimeWorkSkill = timeWorkSkill;
            CooldownSkill = cooldownSkill;
        }
    }
}
