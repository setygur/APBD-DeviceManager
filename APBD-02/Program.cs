using APBD_02.Devices;

DeviceManager deviceManager = new DeviceManager("input-path");
deviceManager.ShowAllDevices();
var smartwatch = new Smartwatch("SW-5", "AppleWatch", false, 10);
deviceManager.AddDevice(smartwatch);
// deviceManager.TurnOnDevice(smartwatch);
deviceManager.ShowAllDevices();
deviceManager.RemoveDevice(smartwatch);
deviceManager.ExportDevices("output-path");
