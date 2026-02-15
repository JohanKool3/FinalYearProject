using FinalYearProject.UI.Components.Extensions;
using FinalYearProject.UI.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;
using FinalYearProject.Services.Extensions;

namespace FinalYearProject.UI
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

#if DEBUG
            builder.Configuration.AddUserSecrets(
            Assembly.GetExecutingAssembly(),
            optional: true);
#endif

            builder.Services.AddAutoMapper(cfg => { }, typeof(MauiProgram));

            builder.Services.AddMauiBlazorWebView();

            // Add API Client
            builder.Services.AddApiClient(builder.Configuration);

            // Add Local File System
            builder.Services.AddLocalFileStorage();

            // Add Audio Services
            builder.Services.AddAudioServices(DeviceInfo.Current);

            // Add UI Settings
            builder.Services.AddUISettings();

            // Register User Interface Services
            builder.Services.AddUiServices();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
