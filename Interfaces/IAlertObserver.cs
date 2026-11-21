using Bai11.Models;
namespace Bai11.Interfaces;

public interface IAlertObserver
{
    void Update(AlertEvent alertEvent);
}