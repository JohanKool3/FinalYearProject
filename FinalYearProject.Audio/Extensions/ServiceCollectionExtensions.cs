using FinalYearProject.Audio.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FinalYearProject.Audio.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAudioServices(this IServiceCollection services)
        {
            // Register the Audio Service
            services.AddSingleton<FileAudioService>();

            return services;
        }
    }
}
