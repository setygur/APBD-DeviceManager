namespace APBD_02.Devices.DeviceManagerUtils;

public static class DeviceFileService
{
    public static String[] GetDevicesFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found: " + filePath);
            return null;
        }
        return File.ReadAllLines(filePath);
    }
    
    public static void ExportDevices(String outputPath, Device?[] devices)
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
                if (devices[i] != null)
                {
                    devicesStrings[i] = devices[i].ToString();
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
}