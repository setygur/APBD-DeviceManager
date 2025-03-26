namespace APBD_02.Devices.DeviceManagerUtils;

public static class DeviceParser
{
    /// <summary>
    /// Takes a string with device data and parse it into new object Device
    /// </summary>
    /// <param name="deviceData"></param>
    /// <returns>Device?</returns>
    public static Device? ParseDevice(string deviceData)
    {
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

                return new Smartwatch(id, name, isOn, batteryPercentage);
            }

            Console.WriteLine("Invalid device data: " + deviceData);
        }
        else if (splitDeviceData[0].StartsWith("P"))
        {
            if (splitDeviceData.Length == 3)
            {
                var id = splitDeviceData[0];
                var name = splitDeviceData[1];
                var isOn = bool.Parse(splitDeviceData[2]);

                return new PersonalComputer(id, name, isOn);
            }

            if (splitDeviceData.Length == 4)
            {
                var id = splitDeviceData[0];
                var name = splitDeviceData[1];
                var isOn = bool.Parse(splitDeviceData[2]);
                var system = splitDeviceData[3];

                return new PersonalComputer(id, name, isOn, system);
            }

            Console.WriteLine("Invalid device data: " + deviceData);
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

                return new EmbeddedDevice(id, name, isOn, ip, network);
            }

            Console.WriteLine("Invalid device data: " + deviceData);
        }
        Console.WriteLine("Invalid device data: " + deviceData);
        return null;
    }
}
