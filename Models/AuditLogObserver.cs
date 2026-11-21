namespace Bai11.Models;

using Bai11.Interfaces;

public sealed class AuditLogObserver : IAlertObserver
{
    public void Update(AlertEvent alertEvent)
    {
        Console.WriteLine(
            $"[AUDIT] {alertEvent.OccurredAt:yyyy-MM-dd HH:mm:ss} | " +
            $"{alertEvent.SensorName}: {alertEvent.Value:F1}{alertEvent.Unit} " +
            $"[{alertEvent.Severity}]");
    }
}
