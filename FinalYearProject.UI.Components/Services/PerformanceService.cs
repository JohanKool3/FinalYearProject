using FinalYearProject.Api;
using FinalYearProject.Shared.Models.Dtos;
using FinalYearProject.UI.Components.Helpers;

namespace FinalYearProject.UI.Components.Services
{
    /// <summary>
    /// Holds information about the user's
    /// last performance results
    /// </summary>
    public class PerformanceService(FinalYearProjectApiClient
        apiClient)
    {

        public AccuracyResultsDto? LastFetchedResults { get; private set; }

        public FinalYearProjectApiClient ApiClient { get; } = apiClient;

        /// <summary>
        /// Requests Results, saves to LastFetchedResults property
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pieceId"></param>
        /// <returns></returns>
        public async Task GetResultsAsync(Stream data, Guid pieceId)
        {
            if (data is null || ApiClient is null)
            {
                return;
            }

            var request = ApiRequestHelper
                .GenerateAnalysisRequestData(pieceId,
                $"{Guid.NewGuid().ToString()[..4]}.wav", // Generate a placeholder name
                data
                );

            var results = await ApiClient.RequestAnalysisAsync(request, CancellationToken.None);
        
            LastFetchedResults = results;
        }
    }
}
