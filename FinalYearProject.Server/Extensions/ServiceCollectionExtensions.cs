using FinalYearProject.Server.Exceptions;
using FinalYearProject.Server.Helpers;
using FinalYearProject.Server.Interfaces;
using FinalYearProject.Server.Models;
using FinalYearProject.Server.Validators;

namespace FinalYearProject.Server.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadSettings(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Load Validation Settings
            _ = services.AddSingleton(sp
                => SettingsSubSectionHelper
                .GetSettingsSubSection<ValidationSettings>(configuration));

            return services;
        }

        public static IServiceCollection LoadValidators(
            this IServiceCollection services)
        {
            services.AddScoped<IAudioDataValidator, AudioDataValidator>();

            return services;
        }
    }
}
