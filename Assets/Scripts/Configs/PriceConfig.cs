using UnityEngine;

[CreateAssetMenu(fileName = "PriceConfig", menuName = "Configs/Price", order = 51)]
public class PriceConfig : ScriptableObject
{
    [SerializeField] private int _price;

    public int Price => _price;
}
