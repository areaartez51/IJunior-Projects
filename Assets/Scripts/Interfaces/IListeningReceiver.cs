using System;

public interface IListeningReceiver
{
    public void ListeningReceiver(Action<IRequest> listener);
}