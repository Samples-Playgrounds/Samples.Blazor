namespace AppDemo.MAUI.Blazor.FluentUI.Suite;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new MainPage()) { Title = "AppDemo.MAUI.Blazor.FluentUI.Suite" };
    }
}
