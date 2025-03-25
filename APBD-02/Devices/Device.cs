namespace APBD_02.Devices;

public abstract class Device
{
    protected string _id;
    protected string _name;
    protected bool _isOn;

    public Device(string id, string name, bool isOn)
    {
        _id = id;
        _name = name;
        _isOn = isOn;
    }

    public virtual bool turnOn()
    {
        if (!_isOn)
        {
            _isOn = true;
            return true;
        }
        else
        {
            Console.WriteLine("Device is already on");
            return false;
        }
    }

    public virtual bool turnOff()
    {
        if (_isOn)
        {
            _isOn = false;
            return true;
        }
        else
        {
            Console.WriteLine("Device is already off");
            return false;
        }
    }

    public override string ToString()
    {
        return "Unknown Device";
    }
}