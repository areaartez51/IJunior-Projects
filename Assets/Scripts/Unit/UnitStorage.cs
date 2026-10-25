public class UnitStorage: IUnitStorage
{
    private readonly Mineral _mineral;
    private int _carriedValue;

    public UnitStorage(Mineral mineral)
    {
        _mineral = mineral;
    }

    public void ReceiveOrePiece(ResourceConfig resourceConfig)
    {
        _carriedValue += resourceConfig.PriceConfig.Price;
        DisplayMineral(resourceConfig);
    }

    public int GiveOre()
    {
        _mineral.gameObject.SetActive(false);

        int value = _carriedValue;   
        _carriedValue = 0;  
        
        return value;
    }

    private void DisplayMineral(ResourceConfig resourceConfig) 
    {
        _mineral.gameObject.SetActive(true);
        _mineral.Init(resourceConfig.FreeMaterial, resourceConfig.PriceConfig.Price);
    }
}
