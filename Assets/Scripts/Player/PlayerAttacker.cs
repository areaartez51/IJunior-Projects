using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    public void Reset()
    {
        _weapon.Reset();
    }

    public void Attack()
    {
        _weapon.Fire();
    }
}