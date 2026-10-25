using System.Collections.Generic;
using UnityEngine;

public class DataStorageScanner
{
    private Network _network;

    private readonly List<ICrystal> _detectedObj = new();
    private readonly List<ICrystal> _occupiedObj = new();

    private void OnDisable()
    {
        _network.SendMessageOccupied -= GetMessageOccupied;
    }

    public void Init(Network network)
    {
        _network = network;
        _network.SendMessageOccupied += GetMessageOccupied;
    }

    public void Add(ICrystal obj)
    {
        if (!_detectedObj.Contains(obj) && !_occupiedObj.Contains(obj))
        {
            _detectedObj.Add(obj);
        }
    }

    public bool TryGetFreeObj(out ICrystal crystal)
    {
        if (_detectedObj.Count <= 0)
        {
            crystal = null;
            return false;
        }
        else 
        {
            crystal = _detectedObj[0];
            _network.InvokeMessage(crystal);

            return true;
        }
    }

    private void GetMessageOccupied(ICrystal obj)
    {
        _detectedObj.Remove(obj);
        _occupiedObj.Add(obj);

        obj.Freedom += Freedom;
    }

    private void Freedom(ISearchable obj)
    {
        _occupiedObj.Remove((Crystal)obj);

        obj.Freedom -= Freedom;
    }
}
