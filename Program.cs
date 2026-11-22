using Bai11.Interfaces;
using Bai11.Models;

/*  
202418946
Phạm Văn Minh
*/

LegacySmokeDetector legacy = new(735);
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

// 1. Adapter chuyển đổi giá trị và đơn vị từ cảm biến cũ
Console.WriteLine("1. Adapter chuyển đổi giá trị và đơn vị từ cảm biến cũ");
Console.WriteLine($"Value: {smokeSensor.ReadValue()}, Unit: {smokeSensor.GetUnit()}");

// 2. Mức khói bình thường (300 -> 30.0%)
Console.WriteLine("2. Mức khói bình thường (300 -> 30.0%)");
legacy.SetSmokeLevel(300);
monitor.CheckSensor("ServerRoom-Smoke", smokeSensor);

// 3. Mức khói cảnh báo WARNING (550 -> 55.0%)
Console.WriteLine("3. Mức khói cảnh báo WARNING (550 -> 55.0%)");
legacy.SetSmokeLevel(550);
monitor.CheckSensor("ServerRoom-Smoke", smokeSensor);

// 4. Mức khói nguy hiểm CRITICAL (735 -> 73.5%)
Console.WriteLine("4. Mức khói nguy hiểm CRITICAL (735 -> 73.5%)");
legacy.SetSmokeLevel(735);
monitor.CheckSensor("ServerRoom-Smoke", smokeSensor);

// 5. Khôi phục trạng thái an toàn qua EmergencyMediator (ALL_CLEAR)
Console.WriteLine("5. Khôi phục trạng thái an toàn qua EmergencyMediator");
mediator.Notify(monitor, "ALL_CLEAR");

// 6. Đăng ký trùng cùng một observer
Console.WriteLine("6. Đăng ký trùng cùng một observer");
monitor.Attach(dashboard);
legacy.SetSmokeLevel(550);
monitor.CheckSensor("ServerRoom-Smoke", smokeSensor);

// 7. Hủy đăng ký EmailAlertObserver
Console.WriteLine("7. Hủy đăng ký EmailAlertObserver");
monitor.Detach(email);
monitor.CheckSensor("ServerRoom-Smoke", smokeSensor);
