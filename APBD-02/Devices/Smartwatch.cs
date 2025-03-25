using APBD_02.Devices.Exceptions;

namespace APBD_02.Devices;

public class Smartwatch : Device, IPowerNotifier
{
    private int _batteryPercentage;
    public Smartwatch(string id, string name, bool isOn, int batteryPercentage) : base(id, name, isOn)
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
                throw new ArgumentException("Battery percentage must be between 0 and 100.");
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

    public override string ToString()
    {
        return "SW-" + _id + "," + _name + "," + _isOn + "," + _batteryPercentage;
    }
}