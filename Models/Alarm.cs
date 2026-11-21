namespace Bai11.Models;

public sealed class Alarm
{
    public bool IsActive { get; private set; }

    public void Activate()
    {
        if (IsActive) return;
        IsActive = true;
        Console.WriteLine("[ALARM] Siren activated");
    }

    public void Deactivate()
    {
        if (!IsActive) return;
        IsActive = false;
        Console.WriteLine("[ALARM] Siren deactivated");
    }
}
