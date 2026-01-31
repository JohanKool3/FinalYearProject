using FinalYearProject.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FinalYearProject.EfCore.Helpers
{
    /// <summary>
    /// Used in Development to seed repositories with initial data
    /// </summary>
    public static class DevelopmentRepositorySeeder
    {
        public static async Task SeedDataAsync<T, TID>(
            IServiceScope serviceScope,
            ICollection<T> data) where T : class
        {
            // Fetch IRepository from services
            var serviceProvider = serviceScope.ServiceProvider;

            var repository = serviceProvider.GetRequiredService<IRepository<T, TID>>();

            // Input Data Here
            await SeedSampleDataAsync(repository, data);
        }

        private static async Task SeedSampleDataAsync<T, TID>(
            IRepository<T, TID> repository,
            ICollection<T> data) where T : class
        {
            foreach(var dataItem in data)
            {
                await repository.CreateAsync(dataItem);
            }
        }
    }
}
