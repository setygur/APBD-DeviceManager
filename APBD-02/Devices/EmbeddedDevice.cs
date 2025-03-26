using System.Text.RegularExpressions;
using APBD_02.Devices.Exceptions;

namespace APBD_02.Devices;

public class EmbeddedDevice : Device
{
    private string? _ip;
    public string NetworkName { get; }

    /// <summary>
    /// A Constructor for a EmbeddedDevice object
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="isOn"></param>
    /// <param name="ip"></param>
    /// <param name="networkName"></param>
    /// <exception cref="ArgumentNullException"></exception>
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
    
    /// <summary>
    /// Provide a regexCheck to Ip before setting it as a private field
    /// Returns _ip
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
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

    /// <summary>
    /// Checks ip for a IPv4 regex
    /// </summary>
    /// <param name="ip"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    private static bool CheckIp(string ip)
    {
        if (Regex.IsMatch(ip,
                "^((25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)\\.){3}(25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)$"))
        {
            return true;
        }

        throw new ArgumentException();
    }

    /// <summary>
    /// Checks if the network name contains a proper string
    /// </summary>
    /// <param name="networkName"></param>
    /// <returns></returns>
    /// <exception cref="ConnectionException"></exception>
    private bool Connect(String networkName)
    {
        if (networkName.Contains("MD Ltd."))
        {
            return true;
        }

        throw new ConnectionException();
    }

    /// <summary>
    /// Turns on a Device if the network name contains a proper string
    /// Returns true if operation successful
    /// </summary>
    /// <returns>bool</returns>
    public override bool turnOn()
    {
        if (Connect(NetworkName))
        {
            return base.turnOn();
        }

        return false;
    }

    /// <summary>
    /// Return data device
    /// </summary>
    /// <returns>string</returns>
    public override string ToString()
    {
        return Id + "," + Name + "," + _ip + "," + NetworkName; 
    }
}