using System;

public interface IUnitMiner
{
    public void TryStartMine(ICrystal crystal, IUnitStorage unitStorage, Action Executed);
}
