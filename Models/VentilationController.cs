namespace Bai11.Models;

public sealed class VentilationController
{
    public bool IsRunning { get; private set; } = true;

    public void ShutDown()
    {
        if (!IsRunning) return;
        IsRunning = false;
        Console.WriteLine("[VENTILATION] Ventilation shut down");
    }

    public void StartUp()
    {
        if (IsRunning) return;
        IsRunning = true;
        Console.WriteLine("[VENTILATION] Ventilation started");
    }
}
