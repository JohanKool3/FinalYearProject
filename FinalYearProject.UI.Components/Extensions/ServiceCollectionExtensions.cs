using FinalYearProject.Services.UI.TabLoaders;
using FinalYearProject.Shared.Models;
using FinalYearProject.Shared.Models.Dtos;
using FinalYearProject.Shared.Services;
using FinalYearProject.UI.Components.DataManagers;
using FinalYearProject.UI.Components.Interfaces;
using FinalYearProject.UI.Components.Models;
using FinalYearProject.UI.Components.Services;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddSingleton<IUserDataStorage, UserDataStorage>();

            return services;
        }

        public static IServiceCollection RegisterSettings(this IServiceCollection services)
        {
            services.AddSingleton<ToolbarSettings>();
            services.AddSingleton<UserSettings>();

            return services;
        }
    }
}
