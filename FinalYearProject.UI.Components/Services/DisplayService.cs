using FinalYearProject.Services.Interfaces;
using FinalYearProject.Shared.Models.UI;

namespace FinalYearProject.UI.Components.Services
{
    public class DisplayService
    {
        public DisplayService(ITabLoaderService displayLoaderService)
        {
            //Pull Display Loader Service from Dependency Injection
            TabLoaderService = displayLoaderService;

            // Load the Initial Piece
            LoadPiece();
        }

        #region Properties

        /// <summary>
        /// Returns whether the tab is currently being played.
        /// </summary>
        public bool IsPlaying { get; private set; } = false;

        /// <summary>
        /// The current Beats Per Minute (BPM) for playback
        /// </summary>
        public int Bpm { get; private set; } = 120;

        /// <summary>
        /// Keeps track of the current progress through the tab as a time
        /// </summary>
        public float CurrentTimeInSeconds { get; private set; } = 0;

        public float TotalTabLengthInSeconds
            => CurrentTab?.TotalLengthInSeconds ?? 0;

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
        
        public ITabLoaderService TabLoaderService { get; }
        
        #endregion

        /// <summary>
        /// Starts playback of tab
        /// </summary>
        public void StartPlayback()
        {
            IsPlaying = true;

            // TODO: Implement Timer here to update
            // CurrentTimeInSeconds based on Bpm of current bar
        }

        /// <summary>
        /// Stops playback of tab.
        /// </summary>
        public void StopPlayback()
        {
            // TODO: Implement Stopping of Timer here
            IsPlaying = false;
        }

        public void ResetPlayback()
        {
            // Currently, resetting playback only stops it.
            StopPlayback();
            SetProgressPercent(0);
        }

        /// <summary>
        /// Sets the current progress percentage for playback, 
        /// clamped between 0% and 100%
        /// </summary>
        /// <param name="playbackPercentage"></param>
        public void SetProgressPercent(int playbackPercentage)
            => CurrentTimeInSeconds = Math.Clamp(playbackPercentage, 0, 100);

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
        public void LoadPiece()
        {
            // Load the tab from the display loader service
            var tab = TabLoaderService.GetTab();

            CurrentTab = tab;

            // Get the BPM for the first bar, or default to 120 if not available
            Bpm = tab?.Bars[0].Bpm ?? 120;
        }

        // TODO: Add Overload that allows loading of a specific tab
    }
}
