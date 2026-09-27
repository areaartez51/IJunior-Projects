using UnityEngine;

public class UnitStorage : Storage,IStorage
{
    [SerializeField] private Mineral _mineral;

    public Vector3 Position => transform.position;

    public void ReceiveOrePiece(ResourceConfig resourceConfig)
    {
        _mineral.gameObject.SetActive(true);
        _mineral.GiveConfig(resourceConfig.FreeMaterial, resourceConfig.Price);
    }

    public int TransferOre()
    {
        _mineral.gameObject.SetActive(false);

        return _mineral.Price;
    }
}
