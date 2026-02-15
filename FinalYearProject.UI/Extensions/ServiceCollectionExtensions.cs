using FinalYearProject.Api;
using FinalYearProject.UI.Models;
using Microsoft.Extensions.Configuration;

namespace FinalYearProject.UI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiClient(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration
                .GetSection("api")
                .Get<ApiOptions>()
                ?? throw new InvalidOperationException("API options are not configured properly.");
            
            services.AddHttpClient<FinalYearProjectApiClient>("MyApi", client =>
            {
                client.BaseAddress = new Uri(options.Url);
            });

            return services;

        }

        public static IServiceCollection AddUISettings(this IServiceCollection services)
        {
            services.AddSingleton<AppSettingsExpansionSettings>();

            return services;
        }
    }
}
