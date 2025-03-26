namespace APBD_02.Devices;

public class DeviceManager
{
    private Device?[] _devices;

    public DeviceManager(string filePath)
    {
        _devices = ImportDevices(GetDevicesFromFile(filePath));
    }

    public String[] GetDevicesFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found: " + filePath);
            return null;
        }
        return File.ReadAllLines(filePath);
    }

    public Device[] ImportDevices(String[] devicesData)
    {
        Device[] devices = new Device[15];
        int index = 0;
        foreach (String deviceData in devicesData)
        {
            if (index > 15)
            {
                Console.WriteLine("Devices capacity is full");
                return devices;
            }
            
            String[] splitDeviceData = deviceData.Split(',');
            if (splitDeviceData[0].StartsWith("SW"))
            {
                if (splitDeviceData.Length == 4)
                {
                    var id = splitDeviceData[0];
                    var name = splitDeviceData[1];
                    var isOn = bool.Parse(splitDeviceData[2]);
                    var batteryPercentage = int.Parse(splitDeviceData[3].Substring(0,
                        splitDeviceData[3].Length - 1));
                    
                    devices[index] = new Smartwatch(id, name, isOn, batteryPercentage);
                    index++;
                }
                else
                {
                    Console.WriteLine("Invalid device data: " + deviceData);
                }
            }
            else if (splitDeviceData[0].StartsWith("P"))
            {
                if (splitDeviceData.Length == 3)
                {
                    var id = splitDeviceData[0];
                    var name = splitDeviceData[1];
                    var isOn = bool.Parse(splitDeviceData[2]);
                    
                    devices[index] = new PersonalComputer(id, name, isOn);
                    index++;
                }
                else if (splitDeviceData.Length == 4)
                {
                    var id = splitDeviceData[0];
                    var name = splitDeviceData[1];
                    var isOn = bool.Parse(splitDeviceData[2]);
                    var system = splitDeviceData[3];
                    
                    devices[index] = new PersonalComputer(id, name, isOn, system);
                    index++;
                }
                else
                {
                    Console.WriteLine("Invalid device data: " + deviceData);
                }
            }
            else if (splitDeviceData[0].StartsWith("ED"))
            {
                if (splitDeviceData.Length == 4)
                {
                    var id = splitDeviceData[0];
                    var name = splitDeviceData[1];
                    var isOn = false;
                    var ip = splitDeviceData[2];
                    var network = splitDeviceData[3];
                    
                    devices[index] = new EmbeddedDevice(id, name, isOn, ip, network);
                    index++;
                }
                else
                {
                    Console.WriteLine("Invalid device data: " + deviceData);
                }
            }
        }
        return devices;
    }

    public void AddDevice(Device device)
    {
        for (int i = 0; i < _devices.Length; i++)
        {
            if (_devices[i] == null)
            {
                _devices[i] = device;
                Console.WriteLine("Device inserted at index " + i);
                return;
            }
        }
        Console.WriteLine("No empty space available to insert the device.");
    }

    public void RemoveDevice(Device device)
    {
        for (int i = 0; i < _devices.Length; i++)
        {
            if (_devices[i] == device)
            {
                _devices[i] = null;
                Console.WriteLine("Device removed at index " + i);
                return;
            }
        }
        Console.WriteLine("Cannot remove the device as it does not appear in devices");
    }

    public void EditDevice(Device editDevice)
    {
        var targetDeviceIndex = -1;
        for (var index = 0; index < _devices.Length; index++)
        {
            var storedDevice = _devices[index];
            if (storedDevice != null)
            {
                if (storedDevice.Id.Equals(editDevice.Id))
                {
                    targetDeviceIndex = index;
                    break;
                }
            }
        }

        if (targetDeviceIndex == -1)
        {
            throw new ArgumentException($"Device with ID {editDevice.Id} is not stored.", nameof(editDevice));
        }

        if (editDevice is Smartwatch)
        {
            if (_devices[targetDeviceIndex] is Smartwatch)
            {
                _devices[targetDeviceIndex] = editDevice;
            }
            else
            {
                throw new ArgumentException($"Type mismatch between devices. " +
                                            $"Target device has type {_devices[targetDeviceIndex].GetType().Name}");
            }
        }
        
        if (editDevice is PersonalComputer)
        {
            if (_devices[targetDeviceIndex] is PersonalComputer)
            {
                _devices[targetDeviceIndex] = editDevice;
            }
            else
            {
                throw new ArgumentException($"Type mismatch between devices. " +
                                            $"Target device has type {_devices[targetDeviceIndex].GetType().Name}");
            }
        }
        
        if (editDevice is EmbeddedDevice)
        {
            if (_devices[targetDeviceIndex] is EmbeddedDevice)
            {
                _devices[targetDeviceIndex] = editDevice;
            }
            else
            {
                throw new ArgumentException($"Type mismatch between devices. " +
                                            $"Target device has type {_devices[targetDeviceIndex].GetType().Name}");
            }
        }
    }

    public void TurnOnDevice(Device device)
    {
        device.turnOn();
    }

    public void TurnOffDevice(Device device)
    {
        device.turnOff();
    }

    public void ShowAllDevices()
    {
        foreach (var x in _devices)
        {
            if (x != null)
            {
                Console.WriteLine(x.ToString());
            }
            else
            {
                Console.WriteLine("Empty device");
            }
        }
    }

    public void ExportDevices(String outputPath)
    {
        if (!Directory.Exists(outputPath))
        {
            Directory.CreateDirectory(outputPath);
        }
        
        string filePath = Path.Combine(outputPath, "output.txt");

        try
        {
            string[] devicesStrings = new string[15];
            for (int i = 0; i < 15; i++)
            {
                if (_devices[i] != null)
                {
                    devicesStrings[i] = _devices[i].ToString();
                }
            }
            File.WriteAllLines(filePath, devicesStrings);
            Console.WriteLine($"Devices have been written");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    public Device?[] GetDevices()
    {
        return _devices?.ToArray();
    }
}