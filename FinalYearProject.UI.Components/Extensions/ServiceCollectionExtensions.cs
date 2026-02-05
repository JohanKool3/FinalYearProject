using FinalYearProject.Services.Interfaces;
using FinalYearProject.Services.UIFramework.TabLoaders;
using FinalYearProject.Shared.Models.Dtos;
using FinalYearProject.UI.Components.DataManagers;
using FinalYearProject.UI.Components.Interfaces;
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

            // Register Tab Display Loader
            //services.AddSingleton<ITabLoaderService, BasicTabLoaderService>();
            services.AddScoped<ITabLoaderService, TabLoaderService>();

            // Register Playback Service
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
    }
}
