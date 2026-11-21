using Bai11.Interfaces;
using Bai11.Models;

/*  
202418946
Phạm Văn Minh
*/

LegacySmokeDetector legacy = new(300);
ISensor smokeSensor = new SmokeSensorAdapter(legacy);

Alarm alarm = new();
DoorController doorController = new();
VentilationController ventilationController = new();
IEmergencyMediator mediator = new EmergencyMediator(alarm, doorController, ventilationController);

SensorMonitor monitor = new();
IAlertObserver dashboard = new DashboardObserver();
IAlertObserver email = new EmailAlertObserver();
IAlertObserver audit = new AuditLogObserver();
IAlertObserver emergencyBridge = new EmergencyBridgeObserver(mediator);

monitor.Attach(dashboard);
monitor.Attach(email);
monitor.Attach(audit);
monitor.Attach(emergencyBridge);

// 1. Mức khói bình thường (300 -> 30.0%)
Console.WriteLine("1. Mức khói bình thường (300 -> 30.0%)");
monitor.CheckSensor("ServerRoom-Smoke", smokeSensor);

// 2. Mức khói cảnh báo WARNING (550 -> 55.0%)
Console.WriteLine("2. Mức khói cảnh báo WARNING (550 -> 55.0%)");
legacy.SetSmokeLevel(550);
monitor.CheckSensor("ServerRoom-Smoke", smokeSensor);

// 3. Mức khói nguy hiểm CRITICAL (735 -> 73.5%)
Console.WriteLine("3. Mức khói nguy hiểm CRITICAL (735 -> 73.5%)");
legacy.SetSmokeLevel(735);
monitor.CheckSensor("ServerRoom-Smoke", smokeSensor);

// 4. Hủy đăng ký EmailAlertObserver và kiểm tra lại
Console.WriteLine("4. Hủy đăng ký EmailAlertObserver và kiểm tra lại");
monitor.Detach(email);
monitor.CheckSensor("ServerRoom-Smoke", smokeSensor);
