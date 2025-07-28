using UnityEngine;

namespace Practice_5
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(ColorChanger))]

    public class Cube : MonoBehaviour
    {
        [SerializeField] private float _currentSplitChance = 100f;

        public float CurrentSplitChance => _currentSplitChance;

        public void Initialize(Vector3 localeScale, Vector3 position, float currentSplitChance)
        {
            _currentSplitChance = currentSplitChance;
            transform.localScale = localeScale;
            transform.localPosition = position;
        }
    }
}


