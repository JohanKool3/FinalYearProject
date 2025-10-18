using FinalYearProject.UI.Components.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.UI.Components.Extensions
{
    public static class ServiceCollectionExtension
    {

        /// <summary>
        /// Register the UI Services.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddUiServices(this IServiceCollection services)
        {

            // Register Playback Service
            services.AddSingleton<TabPlaybackService>();

            // Register Settings Service
            services.AddSingleton<TabRepresentationSettingsService>();
            return services;
        }
    }
}
