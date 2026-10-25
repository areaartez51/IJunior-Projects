using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskDistributor : MonoBehaviour, ITaskDistributor, IPublisher
{
    RequestBuilder _requestBuilder;
    private float _cooldawnGiveTask;

    private readonly List<Unit> _units = new List<Unit>();

    private readonly Queue<ITaskReceiver> _listeners = new Queue<ITaskReceiver>();
    private readonly Queue<ICrystal> _requests = new Queue<ICrystal>();

    private IHologram _priorityRequests;

    private Coroutine _coroutine;

    public int CountUnit => _units.Count;
    public int CountListeners => _listeners.Count;
    public int CountTasks => _requests.Count;

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void Init(RequestBuilder requestBuilder, float cooldawnGiveTask = 1f)
    {
        _requestBuilder = requestBuilder;
        _cooldawnGiveTask = cooldawnGiveTask;
    }

    public void StartWork() => _coroutine = StartCoroutine(GiveTask());

    public void Add(Unit unit) => _units.Add(unit);

    public void AddListener(ITaskReceiver listener) => _listeners.Enqueue(listener);

    public void Publish(ICrystal crystal) => _requests.Enqueue(crystal);

    public void Publish(IHologram hologram) => _priorityRequests = hologram;

    public bool IsPriorityRequestsMissing() => _priorityRequests == null;

    public IEnumerator GiveTask()
    {
        while (true)
        {
            if (_listeners.Count > 0)
            {
                if (GetTask(out IRequest request, _listeners.Peek()))
                {
                    var listener = _listeners.Dequeue();

                    listener.ReceiveTask(request);
                }
            }

            yield return new WaitForSeconds(_cooldawnGiveTask);
        }
    }

    private bool GetTask(out IRequest request, ITaskReceiver listener)
    {
        if (!TryGetPriorityTask() && !TryGetTask())
        {
            request = null;
            return false;
        }
        else 
        {
            _requestBuilder.PrepareMutableData(listener);

            if (TryGetPriorityTask())
            {
                request = _requestBuilder.Create(_priorityRequests);
                _priorityRequests = null;
                return true;
            }
            else
            {
                request = _requestBuilder.Create(_requests.Dequeue());
                return true;
            }
        }
    }

    private bool TryGetTask() => _requests.Count > 0;

    private bool TryGetPriorityTask() => _priorityRequests != null;
}
