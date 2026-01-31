using FinalYearProject.Accuracy.Analysis.Services;
using FinalYearProject.Accuracy.Analysis.Services.Calculators;
using Microsoft.Extensions.DependencyInjection;

namespace FinalYearProject.Accuracy.Analysis.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPerformanceAnalysisServices(this IServiceCollection services)
        {
            // Required Calculators
            services.AddSingleton<NoteAccuracyCalculatorService>();


            // Main Service
            services.AddSingleton<PerformanceAccuracyService>();

            return services;
        }
    }
}
