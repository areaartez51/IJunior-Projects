public class BaseStorage : IStorageBase
{
    private float _amountMinerals = 0;

    public float AmountMinerals => _amountMinerals;

    public void GetOre(int price)
    {
        _amountMinerals += price;
    }

    public bool TryBuy(int price)
    {
        if (_amountMinerals >= price)
        {
            _amountMinerals -= price;
            return true;
        }
        return false;
    }
}
