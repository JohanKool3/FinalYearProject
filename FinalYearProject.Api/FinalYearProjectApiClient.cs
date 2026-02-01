using FinalYearProject.Api.Models;
using FinalYearProject.Shared.Models.Dtos;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace FinalYearProject.Api
{
    public class FinalYearProjectApiClient(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<AccuracyResultsDto?> RequestAnalysisAsync(
            RequestAnalysisData request,
            CancellationToken cancellationToken = default)
        {
            using var content = new MultipartFormDataContent
            {
                // GUID fields
                { new StringContent(request.Id.ToString()), "Id" },
                { new StringContent(request.PieceId.ToString()), "PieceId" }
            };

            // File field
            var fileContent = new StreamContent(request.AudioData);
            fileContent.Headers.ContentType =
                new MediaTypeHeaderValue("audio/wav");

            content.Add(fileContent, "AudioFile", request.FileName);

            content.Add(fileContent, "file", request.FileName);

            // Implementation for sending the analysis request to the API
            var response = await _httpClient.PostAsync("/api/analysis/audioanalysis", content, cancellationToken);

            // Read Response to Accuracy Details
            var details = await response.Content.ReadFromJsonAsync<AccuracyResultsDto>(cancellationToken);

            return details;
        }
    }
}
