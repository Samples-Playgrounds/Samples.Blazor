using AppDemo.MAUI.Blazor.FluentUI.Suite.Shared.Services;

namespace AppDemo.MAUI.Blazor.FluentUI.Suite.Services;

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
