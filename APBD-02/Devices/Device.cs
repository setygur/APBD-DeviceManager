namespace APBD_02.Devices;

public abstract class Device
{
    private int _id;
    private string _name;
    private bool _isOn;

    public Device(int id, string name, bool isOn)
    {
        _id = id;
        _name = name;
        _isOn = isOn;
    }

    public virtual void turnOn()
    {
        if (!_isOn)
        {
            _isOn = true;
        }
        else
        {
            Console.WriteLine("Device is already on");
        }
    }

    public virtual void turnOff()
    {
        if (_isOn)
        {
            _isOn = false;
        }
        else
        {
            Console.WriteLine("Device is already off");
        }
    }
}