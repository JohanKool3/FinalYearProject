using FinalYearProject.Api.Models;
using FinalYearProject.Shared.Models.Dtos;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace FinalYearProject.Api
{
    public class FinalYearProjectApiClient(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;

        #region Audio Analysis 

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
                new MediaTypeHeaderValue("audio/wave");

            content.Add(fileContent, "AudioFile", request.FileName);

            content.Add(fileContent, "file", request.FileName);

            // Implementation for sending the analysis request to the API
            var response = await _httpClient.PostAsync("/api/audioanalysis", content, cancellationToken);


            if (!response.IsSuccessStatusCode)
            {
                // Handle error response as needed
                return null;
            }

            // Read Response to Accuracy Details
            var details = await response.Content.ReadFromJsonAsync<AccuracyResultsDto>(cancellationToken);

            return details;
        }

        #endregion

        #region Piece Information

        public async Task<IEnumerable<PieceInformationDto>> GetAllPieceInformationAsync(
            CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync("/api/pieceinformation", cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                return [];
            }

            var pieces = await response.Content.ReadFromJsonAsync<IEnumerable<PieceInformationDto>>(cancellationToken);
            
            return (pieces == null)
                ? []
                : pieces;
        }

        public async Task<PieceInformationDto?> GetPieceInformationByIdAsync(
            Guid pieceId,
            CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync($"/api/pieceinformation/{pieceId}", cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var piece = await response.Content.ReadFromJsonAsync<PieceInformationDto>(cancellationToken);

            return piece;
        }

        public async Task<PieceDto?> GetPieceByIdAsync(
            Guid pieceId,
            CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync($"/api/piece/{pieceId}", cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var piece = await response.Content.ReadFromJsonAsync<PieceDto>(cancellationToken);
            return piece;
        }

        #endregion
    }
}
