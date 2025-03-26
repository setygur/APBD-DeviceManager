using System.Text.RegularExpressions;
using APBD_02.Devices.Exceptions;

namespace APBD_02.Devices;

public class EmbeddedDevice : Device
{
    private String? _ip;
    private String _networkName;

    public EmbeddedDevice(string id, string name, bool isOn, string ip, string networkName) : base(id, name, isOn)
    {
        if (CheckIp(ip))
        {
            _ip = ip;
        }
        _networkName = networkName;
    }

    private bool CheckIp(string ip)
    {
        if (Regex.IsMatch(ip,
                "^((25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)\\.){3}(25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)$"))
        {
            return true;
        }

        throw new ArgumentException();
    }

    private bool Connect(String networkName)
    {
        if (networkName.Contains("MD Ltd."))
        {
            return true;
        }

        throw new ConnectionException();
    }

    public override bool turnOn()
    {
        if (Connect(_networkName))
        {
            return base.turnOn();
        }

        return false;
    }

    public String? Ip
    {
        get => _ip;
        set
        {
            if (CheckIp(value))
            {
                _ip = value;
            }
        }
    }

    public override string ToString()
    {
        return Id + "," + Name + "," + _ip + "," + _networkName; 
    }
}