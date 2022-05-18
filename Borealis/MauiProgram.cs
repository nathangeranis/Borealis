using Microsoft.Extensions.DependencyInjection;

namespace Borealis
{
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
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();
            builder.Services.Configure<MudTheme>(builder.Configuration.GetSection(nameof(MudTheme)));
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif
            return builder.Build();
        }
    }
}