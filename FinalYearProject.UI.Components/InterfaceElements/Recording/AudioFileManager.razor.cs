using FinalYearProject.Api;
using FinalYearProject.UI.Components.Helpers;
using FinalYearProject.UI.Components.Interfaces;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.Recording
{
    public partial class AudioFileManager(IUserDataStorage storage,
        FinalYearProjectApiClient apiClient)
    {
        #region Parameters
        /// <summary>
        /// The Current Recording Session's Piece Id
        /// </summary>
        [Parameter, EditorRequired]
        public required Guid PieceId { get; set; }

        #endregion

        #region Dependencies

        public IUserDataStorage Storage { get; } = storage;

        public FinalYearProjectApiClient ApiClient { get; } = apiClient;

        #endregion

        public Task SetIdAsync(Guid guid)
        {
            PieceId = guid;

            // Create the Folder Location 
            var location = Storage.GetPieceDirectory(guid);

            Console.WriteLine();

            return InvokeAsync(StateHasChanged);
        }

        internal string GetLatestRecording()
        {
            var files = Storage.GetFilesAtDirectoryByFileExtension(PieceId, ".wav");

            return files.FirstOrDefault()
                ?? string.Empty;
        }

        public async Task UploadAsync()
        {
            Stream data = File.OpenRead(GetLatestRecording());

            if(data is null || ApiClient is null)
            {
                return;
            }

            var request = ApiRequestHelper
                .GenerateAnalysisRequestData(PieceId,
                $"{Guid.NewGuid().ToString()[..4]}.wav", // Generate a placeholder name
                data
                );

            var results = await ApiClient.RequestAnalysisAsync(request, CancellationToken.None);

            Console.WriteLine();
        }
    }
}