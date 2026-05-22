namespace AppDemo.MobileHybrid.MAUI.Blazor;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		/*
		 9>App.xaml.cs(9,3): 
		 Warning CS0618 : 
		 'Application.MainPage.set' is obsolete: 'This property is deprecated. Initialize your application by overriding 
		 Application.CreateWindow rather than setting MainPage. To modify the root page in an active application, 
		 use Windows[0].Page for applications with a single window. For applications with multiple windows, use 
		 Application.Windows to identify and update the root page on the correct window.  Additionally, each element 
		 features a Window property, accessible when it's part of the current window.'
		   
		MainPage = new MainPage();
		*/
	}
	
	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new MainPage()) { Title = "AppDemo.MobileHybrid.MAUI.Blazor" };
	}
}
