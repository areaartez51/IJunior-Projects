using System.Collections.Generic;
using UnityEngine;

public class UnitsManager : MonoBehaviour
{
    private Queue<Unit> _freeUnits = new();
    private List<Unit> _workingUnits = new();

    public void GetOnDuty(Unit unit)
    {
        unit.FreedomFromWork -= GetOnDuty;
        _workingUnits.Remove(unit);
        _freeUnits.Enqueue(unit);
    }

    public void AddUnitInQueue(Unit unit)
    {
        _freeUnits.Enqueue(unit);
    }

    public bool TryGiveTask(ISearchable obj)
    {
        if (_freeUnits.Count == 0)
            return false;

        Unit unit = _freeUnits.Dequeue();
        unit.GetTask(obj);
        unit.FreedomFromWork += GetOnDuty;
        _workingUnits.Add(unit);

        return true;
    }
}
