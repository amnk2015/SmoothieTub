using Microsoft.Extensions.Logging;

namespace SmoothieTub;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.ConfigureMauiHandlers(handlers =>
        {
#if ANDROID
            handlers.AddHandler<BannerAdView, SmoothieTub.Platforms.Android.Handlers.BannerAdViewHandler>();
#endif
        });

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
