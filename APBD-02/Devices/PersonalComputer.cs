using APBD_02.Devices.Exceptions;

namespace APBD_02.Devices;

public class PersonalComputer : Device
{
    private String? _operatingSystem;

    public PersonalComputer(string id, string name, bool isOn) : base(id, name, isOn)
    {
        
    }

    public PersonalComputer(string id, string name, bool isOn, string? operatingSystem) : base(id, name, isOn)
    {
        _operatingSystem = operatingSystem;
    }

    public override bool turnOn()
    {
        if (_operatingSystem != null)
        {
            return base.turnOn();
        }
        throw new EmptySystemException();
    }

    public override string ToString()
    {
        return _id + "," + _name + "," + _isOn + "," + _operatingSystem;
    }
}