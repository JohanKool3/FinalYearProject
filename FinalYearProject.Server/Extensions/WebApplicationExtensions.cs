using FinalYearProject.EfCore.Helpers;
using FinalYearProject.EfCore.Models;
using FinalYearProject.Server.Seeding;

namespace FinalYearProject.Server.Extensions
{
    public static class WebApplicationExtensions
    {
        public static async Task SeedRepositoriesAsync(this WebApplication app)
        {
            // Check if in Development
            if (!(app.Environment.IsDevelopment() || app.Environment.IsTest()))
            {
                return;
            }

            using var scope = app.Services.CreateScope();

            await DevelopmentRepositorySeeder
                .SeedDataAsync<PieceModel, Guid>(scope, PieceDataHelper.GetData());
        }
    }
}
