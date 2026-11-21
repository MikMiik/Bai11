namespace Bai11.Models;

using Bai11.Interfaces;

public sealed class EmergencyMediator : IEmergencyMediator
{
    private readonly Alarm alarm;
    private readonly DoorController doorController;
    private readonly VentilationController ventilationController;

    public EmergencyMediator(
        Alarm alarm,
        DoorController doorController,
        VentilationController ventilationController)
    {
        this.alarm = alarm;
        this.doorController = doorController;
        this.ventilationController = ventilationController;
    }

    public void Notify(object sender, string eventName)
    {
        switch (eventName)
        {
            case "FIRE_DETECTED":
                alarm.Activate();
                doorController.UnlockAll();
                ventilationController.ShutDown();
                break;
            case "ALL_CLEAR":
                alarm.Deactivate();
                doorController.LockAll();
                ventilationController.StartUp();
                break;
        }
    }
}
