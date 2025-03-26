namespace APBD_02.Devices.DeviceManagerUtils;

public static class DeviceManagerFactory
{
    public static DeviceManager CreateDeviceManager(string filePath)
    {
        return new DeviceManager(filePath);
    }
}