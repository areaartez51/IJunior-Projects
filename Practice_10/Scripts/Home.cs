using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private AlarmSystem _alarmSystem;

    private void OnEnable()
    {
        _door.BreakingInto += TurnOnAlarm;
        _door.LeftHouse += TurnOffAlarm;
    }

    private void OnDisable()
    {
        _door.BreakingInto -= TurnOnAlarm;
        _door.LeftHouse -= TurnOffAlarm;
    }

    private void TurnOnAlarm()
    {
        _alarmSystem.PlaySound();
    }

    private void TurnOffAlarm()
    {
        _alarmSystem.StopSound();
    }
}
