using FinalYearProject.Services.Interfaces;
using FinalYearProject.Services.Settings;
using FinalYearProject.Services.UI.TabLoaders;
using FinalYearProject.Shared.Models;
using FinalYearProject.Shared.Models.Dtos;
using FinalYearProject.Shared.Services;
using FinalYearProject.UI.Components.DataManagers;
using FinalYearProject.UI.Components.Interfaces;
using FinalYearProject.UI.Components.Models;
using FinalYearProject.UI.Components.Services;
using FinalYearProject.UI.Components.Services.Audio;
using FinalYearProject.UI.Components.Services.Audio.Windows.AudioBuses;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Devices;

namespace FinalYearProject.UI.Components.Extensions
{
    public static class ServiceCollectionExtensions
    {

        /// <summary>
        /// Register the UI Services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddUiServices(this IServiceCollection services)
        {

            // Register Settings
            services.RegisterSettings();

            // Register Tab Display Loader
            //services.AddSingleton<ITabLoaderService, BasicTabLoaderService>();
            services.AddSingleton<ITabLoaderService, TabLoaderService>();

            // Register Playback Timer
            services.AddSingleton<GlobalTimerService>();

            // Register Display Service
            services.AddSingleton<DisplayService>();

            // Register Playback Service
            services.AddSingleton<PlaybackService>();

            // Register Settings Service
            services.AddSingleton<SettingsService>();

            services.AddSingleton<PerformanceService>();

            // Register Data Managers
            services.RegisterDataManagers();

            return services;
        }

        private static IServiceCollection RegisterDataManagers(this IServiceCollection services)
        {
            services.AddScoped<IDataManager<PieceInformationDto>, TabBrowserDataManager>();

            return services;
        }

        public static IServiceCollection AddLocalFileStorage(this IServiceCollection services)
        {

            services.AddSingleton<IUserDataService, UserDataService>();

            return services;
        }

        public static IServiceCollection RegisterSettings(this IServiceCollection services)
        {
            services.AddSingleton<ToolbarSettings>();
            services.AddSingleton<UserSettings>();

            return services;
        }

        public static IServiceCollection AddAudioServices(
            this IServiceCollection services,
            IDeviceInfo deviceInfo)
        {
            // Based on the Device Platform, add the relevant recording service.
            // At the moment, this will only support Windows but in the future,
            // this can be extended to include platforms such as MAC and Android

            // Register Settings as they are platform independent
            services.AddSingleton<AudioServiceSettings>();


            if (deviceInfo.Platform == DevicePlatform.WinUI)
            {
                RegisterWindowsServices(services);
            }

            else
            {
                throw new PlatformNotSupportedException("Platform is not currently supported");
            }

            return services;
        }

        private static void RegisterWindowsServices(IServiceCollection services)
        {
            // Register the 4 Busses
            // (so that they can be modified in the UI)
            services.AddSingleton<MainBus>();
            services.AddSingleton<UserBus>();
            services.AddSingleton<BackingTrackBus>();
            services.AddSingleton<MetronomeBus>();

            // Register main Service
            services.AddSingleton<IAudioService, WindowsAudioService>();
        }
    }
}
