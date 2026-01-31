using FinalYearProject.Audio.Enums;
using FinalYearProject.Audio.Extensions;
using FinalYearProject.Server.Extensions;

namespace FinalYearProject.Server
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Load Settings
            builder.Services.LoadSettings(builder.Configuration);

            // Load Data Stores
            builder.Services.LoadDataStores(builder.Environment);

            // Load Validators
            builder.Services.LoadValidators();

            // Load Audio Analysis Pipeline
            builder.Services.AddAudioAnalysisServices(ServiceType.Simple);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}