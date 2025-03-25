using APBD_02.Devices;

namespace APBD_02Tests;

public class TestDevice : Device
{
    public TestDevice(string id, string name, bool isOn) : base(id, name, isOn) { }
}