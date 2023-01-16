using AppBurgerJEAI.Data;

namespace AppBurgerJEAI;

public partial class App : Application
{
	public static BurgerDataBase BurgerRepo { get; private set; }
	public App(BurgerDataBase repo)
	{
		InitializeComponent();

		MainPage = new AppShell();

		BurgerRepo = repo;
	}
}
