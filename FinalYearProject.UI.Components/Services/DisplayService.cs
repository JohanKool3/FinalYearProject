using FinalYearProject.Services.Interfaces;
using FinalYearProject.Shared.Models.UI;

namespace FinalYearProject.UI.Components.Services
{
    /// <summary>
    /// Service for storing and managing the display of tabs
    /// </summary>
    /// <param name="displayLoaderService"></param>
    public class DisplayService(ITabLoaderService displayLoaderService)
    {

        #region Properties



        /// <summary>
        /// The current Beats Per Minute (BPM) for playback
        /// </summary>
        public int Bpm { get; private set; } = 120;

        /// <summary>
        /// Who authored the current tab
        /// </summary>
        public string Author
            => CurrentTab?.Author ?? "Unknown Author";

        /// <summary>
        /// The title of the current tab
        /// </summary>
        public string Title
            => CurrentTab?.Title ?? "Unknown Title";

        public string Description
            => CurrentTab?.Description ?? "No Description";

        public TabInformation? CurrentTab { get; private set; }

        public ITabLoaderService TabLoaderService { get; } = displayLoaderService;

        #endregion

        /// <summary>
        /// Sets the BPM for playback, clamped between 20BPM and 300BPM
        /// </summary>
        /// <param name="bpm"></param>
        public void SetBpm(int bpm)
        {
            Bpm = Math.Clamp(bpm, 20, 300);
        }

        /// <summary>
        /// Loads a new tab into the playback service from Loader Service
        /// </summary>
        public async Task LoadPieceAsync(Guid pieceId, CancellationToken cancellationToken)
        {
            // Load the tab from the display loader service
            var tab = await TabLoaderService.GetTabAsync(pieceId, cancellationToken);

            CurrentTab = tab;

            // Get the BPM for the first bar, or default to 120 if not available
            Bpm = tab?.Bars[0].Bpm ?? 120;
        }
    }
}
