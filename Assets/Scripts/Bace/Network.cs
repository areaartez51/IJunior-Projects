using System;

public class Network
{
    public event Action<ICrystal> SendMessageOccupied;

    public void InvokeMessage(ICrystal obj)
    {
        SendMessageOccupied?.Invoke(obj);
    }
}
