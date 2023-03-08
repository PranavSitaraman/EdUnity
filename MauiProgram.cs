using Microsoft.AspNetCore.Components.WebView.Maui;
using EdUnity.Data;
using CommunityToolkit.Maui;
using Blazored.Modal;
namespace EdUnity;
public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder.UseMauiApp<App>().ConfigureFonts(fonts =>
		{
			fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
		}).UseMauiCommunityToolkit();
        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddBlazoredModal();
        builder.Services.AddBlazorWebViewDeveloperTools();
		return builder.Build();
	}
}