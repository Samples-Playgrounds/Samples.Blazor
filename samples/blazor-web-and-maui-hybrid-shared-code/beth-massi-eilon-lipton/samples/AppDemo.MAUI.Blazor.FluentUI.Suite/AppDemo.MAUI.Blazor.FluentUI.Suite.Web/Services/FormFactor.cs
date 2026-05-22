using AppDemo.MAUI.Blazor.FluentUI.Suite.Shared.Services;

namespace AppDemo.MAUI.Blazor.FluentUI.Suite.Web.Services;

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
