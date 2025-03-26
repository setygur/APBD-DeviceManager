namespace APBD_02.Devices.DeviceManagerUtils;

public static class DeviceManagerFactory
{
    /// <summary>
    /// DeviceManagerFactory
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns>DeviceManager</returns>
    public static DeviceManager CreateDeviceManager(string filePath)
    {
        return new DeviceManager(filePath);
    }
}