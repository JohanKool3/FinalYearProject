using FinalYearProject.Server;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace FinalYearProject.Integration.Tests
{
    public class TestApiFactory: WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test");

            // Ensure that the configuration has been set up
            builder.ConfigureAppConfiguration((context, config) =>
            {
                // Load user secrets from the Integration test project
                var assembly = Assembly.GetExecutingAssembly();
                config.AddUserSecrets(assembly, optional: true);
            });
        }
    }
}
