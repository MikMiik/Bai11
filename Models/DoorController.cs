namespace Bai11.Models;

public sealed class DoorController
{
    public bool AreDoorsUnlocked { get; private set; }

    public void UnlockAll()
    {
        if (AreDoorsUnlocked) return;
        AreDoorsUnlocked = true;
        Console.WriteLine("[DOOR] Emergency doors unlocked");
    }

    public void LockAll()
    {
        if (!AreDoorsUnlocked) return;
        AreDoorsUnlocked = false;
        Console.WriteLine("[DOOR] Emergency doors locked");
    }
}
