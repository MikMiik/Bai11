namespace Bai11.Models;

using Bai11.Interfaces;

public sealed class EmailAlertObserver : IAlertObserver
{
    public void Update(AlertEvent alertEvent)
    {
        Console.WriteLine(
            $"[EMAIL] {alertEvent.SensorName}: " +
            $"{alertEvent.Value:F1}{alertEvent.Unit} " +
            $"[{alertEvent.Severity}]");
    }
}
