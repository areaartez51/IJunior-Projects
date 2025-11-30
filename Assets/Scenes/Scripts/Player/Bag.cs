using UnityEngine;

public class Bag : MonoBehaviour
{
    private int _currentCoin = 0;

    public void AddCoin()
    {
        _currentCoin++;
    }
}
