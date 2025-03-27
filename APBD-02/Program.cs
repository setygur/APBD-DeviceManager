using APBD_02.Devices;
using APBD_02.Devices.DeviceManagerUtils;
using APBD_02.Devices.Exceptions;

// DeviceManager deviceManager = new DeviceManager("input-path");
// deviceManager.ShowAllDevices();
// var smartwatch = new Smartwatch("SW-5", "AppleWatch", false, 10);
// deviceManager.AddDevice(smartwatch);
// // deviceManager.TurnOnDevice(smartwatch);
// deviceManager.ShowAllDevices();
// deviceManager.RemoveDevice(smartwatch);
// deviceManager.ExportDevices("output-path");

try
{
    DeviceManager deviceManager = DeviceManagerFactory.CreateDeviceManager("input.txt");
            
    Console.WriteLine("Devices presented after file read.");
    deviceManager.ShowAllDevices();
            
    Console.WriteLine("Create new computer with correct data and add it to device store.");
    PersonalComputer computer = new("P-2", "ThinkPad T440", false, null);
    deviceManager.AddDevice(computer);
            
    Console.WriteLine("Let's try to enable this PC");
    try
    {
        deviceManager.TurnOnDevice(computer);
    }
    catch (EmptySystemException ex)
    {
        Console.WriteLine(ex.Message);
    }
            
    Console.WriteLine("Let's install OS for this PC");
            
    PersonalComputer editComputer = new("P-2", "ThinkPad T440", true, "Arch Linux");
    deviceManager.EditDevice(editComputer);
            
    Console.WriteLine("Let's try to enable this PC");
    deviceManager.TurnOnDevice(computer);
            
    Console.WriteLine("Let's turn off this PC");
    deviceManager.TurnOffDevice(computer);
            
    Console.WriteLine("Delete this PC");
    deviceManager.RemoveDevice(computer);
            
    Console.WriteLine("Devices presented after all operations.");
    deviceManager.ShowAllDevices();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}