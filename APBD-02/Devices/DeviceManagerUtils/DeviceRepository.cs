namespace APBD_02.Devices.DeviceManagerUtils;

public class DeviceRepository
{
    private Device?[] _devices = new Device?[15];

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

    public Device?[] GetDevices() => _devices;
}
