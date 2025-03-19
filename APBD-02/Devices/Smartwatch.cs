namespace APBD_02.Devices;

public class Smartwatch : Device, IPowerNotifier
{
    private int _batteryPercentage;
    public Smartwatch(int id, string name, bool isOn, int batteryPercentage) : base(id, name, isOn)
    {
        _batteryPercentage = batteryPercentage;
    }
    
}