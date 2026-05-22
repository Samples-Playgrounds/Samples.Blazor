using AppDemo.MobileHybrid.MAUI.Blazor.Suite.Shared.Services;

namespace AppDemo.MobileHybrid.MAUI.Blazor.Suite.Services;

public class FormFactor : IFormFactor
{
    public string GetFormFactor()
    {
        return DeviceInfo.Idiom.ToString();
    }

    public string GetPlatform()
    {
        return DeviceInfo.Platform.ToString() + " - " + DeviceInfo.VersionString;
    }
}
