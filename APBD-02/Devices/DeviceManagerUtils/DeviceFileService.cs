namespace APBD_02.Devices.DeviceManagerUtils;

public static class DeviceFileService
{
    /// <summary>
    /// Read the file and provide an array of Strings with lines read
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns>
    /// String[] of lines from file
    /// </returns>
    public static String[] GetDevicesFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found: " + filePath);
            return null;
        }
        return File.ReadAllLines(filePath);
    }
    
    /// <summary>
    /// Writes devices into a file
    /// </summary>
    /// <param name="outputPath"></param>
    /// <param name="devices"></param>
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