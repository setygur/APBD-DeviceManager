using System.Text.RegularExpressions;
using APBD_02.Devices.Exceptions;

namespace APBD_02.Devices;

public class EmbeddedDevice : Device
{
    private string? _ip;
    public string NetworkName { get; }

    public EmbeddedDevice(string id, string name, bool isOn, string ip, string networkName) 
        : base(id, name, isOn)
    {
        if (networkName != null)
        {
            NetworkName = networkName;
        }
        else
        {
            throw new ArgumentNullException(nameof(networkName));
        }
        Ip = ip;
    }
    
    public string? Ip
    {
        get => _ip;
        set
        {
            if (CheckIp(value))
            {
                _ip = value;
            }
            else
            {
                throw new ArgumentException($"Invalid IP address: {value}");
            }
        }
    }

    private static bool CheckIp(string ip)
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
        if (Connect(NetworkName))
        {
            return base.turnOn();
        }

        return false;
    }

    public override string ToString()
    {
        return Id + "," + Name + "," + _ip + "," + NetworkName; 
    }
}