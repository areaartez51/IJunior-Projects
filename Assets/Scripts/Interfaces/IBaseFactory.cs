using System;
using UnityEngine;

public interface IBaseFactory
{
    public void Spawn(Vector3 position, Action<IBase> IsBuilded = null);
}
