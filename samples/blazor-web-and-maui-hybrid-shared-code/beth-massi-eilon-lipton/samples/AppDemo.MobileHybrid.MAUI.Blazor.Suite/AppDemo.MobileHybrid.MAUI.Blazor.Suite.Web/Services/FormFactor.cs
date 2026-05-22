using AppDemo.MobileHybrid.MAUI.Blazor.Suite.Shared.Services;

namespace AppDemo.MobileHybrid.MAUI.Blazor.Suite.Web.Services;

public class FormFactor : IFormFactor
{
    public string GetFormFactor()
    {
        return "Web";
    }

    public string GetPlatform()
    {
        return Environment.OSVersion.ToString();
    }
}
