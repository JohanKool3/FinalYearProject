using FinalYearProject.Shared.Services;
using FinalYearProject.UI.Components.Interfaces;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class UploadForAnalysisButton(
        PerformanceService performanceService,
        PlaybackService playbackService,
        IUserDataService dataService)
    {
        private readonly PerformanceService _performanceService = performanceService;
        private readonly PlaybackService _playbackService = playbackService;
        private readonly IUserDataService _dataService = dataService;

        /// <summary>
        /// Notify the parent component that a change has occurred.
        /// </summary>
        [Parameter, EditorRequired]
        public Func<Task> NotifyParentOfChange { get; set; } = null!;

        /// <summary>
        /// Navigation Function to the Results Page
        /// </summary>
        [Parameter, EditorRequired]
        public Action<Guid> NavigateToResults { get; set; } = null!;

        private async Task UploadAsync()
        {
            // 1. Fire off Analysis Request
            var filePath = GetLatestRecording();

            if (filePath == string.Empty || _playbackService.ActivePieceId is null)
            {
                // TODO: Log exception or give visual feedback (or both)
                return;
            }

            if (!File.Exists(filePath))
            {
                // TODO: Log Exception or give visual feedback (or both)
                return;
            }

            // We already check that the piece ID is not null, but to be safe use empty
            Guid pieceId = _playbackService.ActivePieceId ?? Guid.Empty;

            var stream = File.OpenRead(filePath);
            await _performanceService.GetResultsAsync(stream, pieceId);

            // 2. Navigate to Results Page (when request has been returned)
            NavigateToResults(pieceId);

            // 3. Notify Changes
            await NotifyParentOfChange();
            return;
        }

        internal string GetLatestRecording()
        {
            var files = _dataService.GetFilesAtDirectoryByFileExtension(Guid.Empty, ".wav");

            return files.FirstOrDefault()
                ?? string.Empty;
        }
    }
}