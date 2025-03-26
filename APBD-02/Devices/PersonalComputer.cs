using APBD_02.Devices.Exceptions;

namespace APBD_02.Devices;

public class PersonalComputer : Device
{
    public string? OperatingSystem { get; private set; }

    public PersonalComputer(string id, string name, bool isOn) : base(id, name, isOn) {}

    public PersonalComputer(string id, string name, bool isOn, string? operatingSystem) : base(id, name, isOn)
    {
        OperatingSystem = operatingSystem;
    }

    public override bool turnOn()
    {
        if (string.IsNullOrWhiteSpace(OperatingSystem))
        {
            return base.turnOn();
        }
        throw new EmptySystemException();
    }

    public override string ToString()
    {
        return Id + "," + Name + "," + IsOn + "," + OperatingSystem;
    }
}