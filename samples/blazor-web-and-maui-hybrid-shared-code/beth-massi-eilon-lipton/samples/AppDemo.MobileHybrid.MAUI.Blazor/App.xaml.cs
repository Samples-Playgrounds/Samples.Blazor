namespace AppDemo.MobileHybrid.MAUI.Blazor;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new MainPage()) { Title = "AppDemo.MobileHybrid.MAUI.Blazor" };
	}
}
