using FinalYearProject.Audio.Models;
using FinalYearProject.Server.Helpers;
using FinalYearProject.Server.Interfaces;
using FinalYearProject.Server.Models;
using FinalYearProject.Server.Services;
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

            // Load File Settings
            _ = services.AddSingleton(sp
                => SettingsSubSectionHelper
                .GetSettingsSubSection<FileSettings>(configuration));

            #region Audio Analysis Pipeline Settings

            // Load Tuning Scheme
            _ = services.AddSingleton(sp
                => SettingsSubSectionHelper
                .GetSettingsSubSection<TuningScheme>(configuration));

            // Load Detection Settings
            _ = services.AddSingleton(sp
                => SettingsSubSectionHelper
                .GetSettingsSubSection<DetectionSettings>(configuration));

            #endregion

            return services;
        }

        public static IServiceCollection LoadValidators(
            this IServiceCollection services)
        {
            services.AddScoped<IAudioDataValidator, AudioDataValidator>();
            services.AddScoped<IAudioFileProcessorService, AudioFileProcessorService>();

            return services;
        }
    }
}
