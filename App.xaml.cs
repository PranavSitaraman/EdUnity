namespace EdUnity;
public partial class App : Application
{
	public static EdUnityRepository EdUnityRepo { get; private set; }
	public App(EdUnityRepository repo)
	{
		InitializeComponent();
		MainPage = new MainPage();
		EdUnityRepo = repo;
	}
}