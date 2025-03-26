using APBD_02.Devices.DeviceManagerUtils;

namespace APBD_02.Devices;

public class DeviceManager
{
    private DeviceRepository _repository;

    public DeviceManager(string filePath)
    {
        _repository = new DeviceRepository();
        ImportDevices(filePath);
    }
    
    public void ImportDevices(string filePath)
    {
        var deviceData = DeviceFileService.GetDevicesFromFile(filePath);
        foreach (var data in deviceData)
        {
            var device = DeviceParser.ParseDevice(data);
            if (device != null) _repository.AddDevice(device);
        }
    }

    public Device?[] GetDevicesFromFile(string filePath)
    { 
        Device?[] devices = new Device[15];
        var deviceData = DeviceFileService.GetDevicesFromFile(filePath);
        foreach (var data in deviceData)
        {
            var device = DeviceParser.ParseDevice(data);
            for (int i = 0; i < devices.Length; i++)
            {
                if (devices[i] == null)
                {
                    devices[i] = device;
                }
            }
        }
        return devices;
    } //kept it here due to the tests
    public void AddDevice(Device device) =>
        _repository.AddDevice(device);

    public void RemoveDevice(Device device) =>
        _repository.RemoveDevice(device);

    public void EditDevice(Device editDevice) =>
        _repository.EditDevice(editDevice);

    public void TurnOnDevice(Device device) =>
        device.turnOn();

    public void TurnOffDevice(Device device) =>
        device.turnOff();

    public void ShowAllDevices() =>
        _repository.ShowAllDevices();

    public void ExportDevices(String outputPath) =>
        DeviceFileService.ExportDevices(outputPath, _repository.GetDevices());

    public Device?[] GetDevices() =>
        _repository.GetDevices();
}