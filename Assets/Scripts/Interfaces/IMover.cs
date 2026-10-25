using System;
using UnityEngine;

public interface IMover
{
    public void StartMove(Vector3 target, Action Executed);
}
