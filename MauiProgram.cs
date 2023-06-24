﻿using CommunityToolkit.Maui;
using Blazored.Modal;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

namespace EdUnity;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			})
			.UseMauiCommunityToolkit();
		string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "edunity.db3");
        builder.Services.AddSingleton<EdUnityRepository>(s => ActivatorUtilities.CreateInstance<EdUnityRepository>(s, dbPath));
		builder.Services.AddMauiBlazorWebView();
		builder.Services.AddBlazoredModal();
		builder.Services.AddBlazorise(options =>
		{
			options.Immediate = true;
		}).AddBootstrapProviders().AddFontAwesomeIcons();
		builder.Services.AddBlazorWebViewDeveloperTools();
		return builder.Build();
	}
}