using FinalYearProject.Api;
using FinalYearProject.Server;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace FinalYearProject.Integration.Tests.Helpers
{
    public class TestSetupHelper
    {
        public static IServiceProvider Create(
        WebApplicationFactory<Program> factory)
        {
            var services = new ServiceCollection();

            // Create HttpClient from the factory
            services.AddSingleton(factory.CreateClient());

            // Custom API Client that will interact with the server
            services.AddSingleton<FinalYearProjectApiClient>();

            return services.BuildServiceProvider();
        }
    }
}
