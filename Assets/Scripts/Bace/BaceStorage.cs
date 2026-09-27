using UnityEngine;

public class BaceStorage : Storage,IStorage
{
    [SerializeField] private float _AmountMinerals = 0;

    public Vector3 Position => transform.position;

    public void ReceiveMineral(float price)
    {
        _AmountMinerals += price;
    }
}
