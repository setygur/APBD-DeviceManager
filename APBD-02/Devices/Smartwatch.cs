using APBD_02.Devices.Exceptions;

namespace APBD_02.Devices;

public class Smartwatch : Device, IPowerNotifier
{
    private int _batteryPercentage;
    public Smartwatch(int id, string name, bool isOn, int batteryPercentage) : base(id, name, isOn)
    {
        _batteryPercentage = batteryPercentage;
    }

    public int BatteryPercentage
    {
        get { return _batteryPercentage; }
        set
        {
            if (value >= 0 || value <= 100)
            {
                _batteryPercentage = value;
                if (_batteryPercentage < 20)
                {
                    PowerLow();
                }
            }
            else
            {
                Console.WriteLine("Battery percentage out of range");
            }
        }
    }
    public void PowerLow()
    {
        Console.WriteLine("PowerLow");
    }

    public override bool turnOn()
    {
        if (_batteryPercentage < 11)
        {
            throw new EmptyBatteryException();
        }

        return base.turnOn();
    }
    
}