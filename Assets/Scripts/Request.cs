using System.Collections.Generic;

public class Request : IRequest
{  
    private readonly Queue<ITask> _data = new();

    public bool HighPriority { get; }

    public Request(Queue<ITask> data, bool highPriority = false)
    {
        _data = data;
        HighPriority = highPriority;
    }

    public ITask GetTask()=> _data.Count > 0 ? _data.Dequeue() : null;
}
