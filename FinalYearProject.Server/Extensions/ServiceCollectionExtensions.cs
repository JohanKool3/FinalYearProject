using FinalYearProject.Accuracy.Analysis.Models;
using FinalYearProject.Audio.Models;
using FinalYearProject.EfCore.Helpers;
using FinalYearProject.EfCore.Models;
using FinalYearProject.Server.Helpers;
using FinalYearProject.Server.Interfaces;
using FinalYearProject.Server.Models;
using FinalYearProject.Server.Repositories;
using FinalYearProject.Server.Services;
using FinalYearProject.Server.Validators;
using FinalYearProject.Shared.Interfaces;

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

            // Load Accuracy Settings
            _ = services.AddSingleton(sp
                => SettingsSubSectionHelper
                .GetSettingsSubSection<AccuracySettings>(configuration));

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
            services.AddScoped<IDataValidator<AnalysisRequest>, AudioDataValidator>();
            services.AddScoped<IDataValidator<AnalysisRequestMetadata>, RequestMetadataValidator>();
            services.AddScoped<IAudioFileProcessorService, AudioFileProcessorService>();

            return services;
        }

        public static IServiceCollection LoadDataStores(
            this IServiceCollection services,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Load Development Data Stores
                services.AddSingleton<IRepository<Piece, Guid>, InMemoryPieceRepository>();
            }
            else if (env.IsTest())
            {
                services.AddSingleton<IRepository<Piece, Guid>, InMemoryPieceRepository>();
            }
            else
            {
                // Load Production Data Stores
            }

            return services;
        }
    }
}
