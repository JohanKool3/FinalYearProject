
using FinalYearProject.Shared.Models.TabRepresentation;
using FinalYearProject.UI.Components.Interfaces;
using FinalYearProject.UI.Components.Models;

namespace FinalYearProject.UI.Components.Services
{
    public class TabPlaybackService
    {
        public TabPlaybackService(ITabDisplayLoaderService displayLoaderService)
        {
            //Pull Display Loader Service from Dependency Injection
            DisplayLoaderService = displayLoaderService;
            
            // Load the Initial Piece
            LoadPiece();
        }
        /// <summary>
        /// Returns whether the tab is currently being played.
        /// </summary>
        public bool IsPlaying { get; private set; } = false;

        public int Bpm { get; private set; } = 120;

        public TabDisplayInformation? CurrentTab {get; private set;}
        public ITabDisplayLoaderService DisplayLoaderService { get; }

        /// <summary>
        /// Starts playback of tab
        /// </summary>
        public void StartPlayback()
        {
            IsPlaying = true;
        }

        /// <summary>
        /// Stops playback of tab.
        /// </summary>
        public void StopPlayback()
        {
            IsPlaying = false;
        }

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
            var tab = DisplayLoaderService.GetCurrentTab();

            CurrentTab = tab;
            Bpm = tab?.Bpm ?? 120;
        }

        // TODO: Add Overload that allows loading of a specific tab
    }
}
