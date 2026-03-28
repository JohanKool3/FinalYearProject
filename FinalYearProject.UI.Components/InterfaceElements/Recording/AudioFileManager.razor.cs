using FinalYearProject.Api;
using FinalYearProject.UI.Components.Helpers;
using FinalYearProject.UI.Components.Interfaces;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.Recording
{
    public partial class AudioFileManager(
        IUserDataService storage,
        PerformanceService performanceService,
        NavigationManager navigationManager)
    {
        #region Parameters
        /// <summary>
        /// The Current Recording Session's Piece Id
        /// </summary>
        [Parameter, EditorRequired]
        public required Guid PieceId { get; set; }

        #endregion

        #region Dependencies

        public IUserDataService Storage { get; } = storage;
        public PerformanceService PerformanceService { get; } = performanceService;
        public NavigationManager NavigationManager { get; } = navigationManager;

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

            await PerformanceService.GetResultsAsync(data, PieceId);
            NavigationManager.NavigateTo($"/results/{PieceId}");
        }
    }
}