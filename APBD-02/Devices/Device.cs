namespace APBD_02.Devices;

public abstract class Device
{
    public string Id { get; } //no set to prevent modification. Can be modified with EditDevice()
    public string Name { get; private set; }
    public bool IsOn { get; private set; }

    public Device(string id, string name, bool isOn)
    {
        if (id != null)
        {
            Id = id;
        }
        else
        {
            throw new ArgumentNullException(nameof(id));
        }

        if (name != null)
        {
            Name = name;
        }
        else
        {
            throw new ArgumentNullException(nameof(name));
        }
        IsOn = isOn;
    }

    public virtual bool turnOn()
    {
        if (!IsOn)
        {
            IsOn = true;
            return true;
        }
        Console.WriteLine("Device is already on");
        return false;
    }

    public virtual bool turnOff()
    {
        if (IsOn)
        {
            IsOn = false;
            return true;
        }
        Console.WriteLine("Device is already off");
        return false;
    }

    public override string ToString()
    {
        return "Unknown Device";
    }
}