using FinalYearProject.Services.Interfaces;
using FinalYearProject.Services.UIFramework.TabLoaders;
using FinalYearProject.UI.Components.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FinalYearProject.UI.Components.Extensions
{
    public static class ServiceCollectionExtension
    {

        /// <summary>
        /// Register the UI Services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddUiServices(this IServiceCollection services)
        {

            // Register Tab Display Loader
            services.AddSingleton<ITabDisplayLoaderService, BasicTabDisplayLoaderService>();

            // Register Playback Service
            services.AddSingleton<TabPlaybackService>();

            // Register Settings Service
            services.AddSingleton<SettingsService>();
            return services;
        }
    }
}
