using FinalYearProject.Shared.Models.TabRepresentation;
using FinalYearProject.Shared.Services;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements
{
    public partial class PlaybackIndicator : IDisposable
        
    {
        public PlaybackIndicator(SettingsService representationService,
        SettingsService settingsService,
        DisplayService displayService,
        PlaybackService playbackService)
        {
            RepresentationService = representationService;
            SettingsService = settingsService;
            DisplayService = displayService;
            PlaybackService = playbackService;

            // Register to be notified when settings change
            RegisterEventHandlers();

        }

        #region Event Handlers

        private void RegisterEventHandlers()
        {
            PlaybackService.RegisterOnStartPlaybackEvent(OnPlaybackStartAsync);
            PlaybackService.RegisterOnStopPlaybackEvent(OnPlaybackEndAsync);
        }

        #endregion

        #region Parameters

        /// <summary>
        /// Where the Playback Indicator is positioned on the X axis
        /// </summary>
        [Parameter]
        public int XPosition { get; set; }

        /// <summary>
        /// Where the Playback Indicator is positioned on the Y axis
        /// </summary>
        [Parameter]
        public int YPosition { get; set; }

        /// <summary>
        /// The Time Signature for the bar that the indicator is linked to
        /// </summary>
        [Parameter, EditorRequired]
        public required TimeSignature BarTimeSignature { get; set; }

        /// <summary>
        /// The number of the bar that the indicator is linked to
        /// </summary>
        [Parameter, EditorRequired]
        public required int BarNumber { get; set; }

        /// <summary>
        /// The width of the parent bar that the indicator is linked to
        /// </summary>
        [Parameter]
        public int ParentBarWidth { get; set; }

        #endregion

        #region Services
        public SettingsService RepresentationService { get; }
        public SettingsService SettingsService { get; }
        public DisplayService DisplayService { get; }
        public PlaybackService PlaybackService { get; }
        
        #endregion
        
        #region Settings

        private int _width
            => SettingsService.Settings.PlaybackIndicator.Width;

        private int _height
            => SettingsService.Settings.PlaybackIndicator.Height;

        private string _color
            => SettingsService.Settings.PlaybackIndicator.Color;

        #endregion
    
        
        private bool _isVisible
            => PlaybackService.IsPlaying;

        private int _bpm
            => DisplayService.Bpm;

        /// <summary>
        /// When playback starts, refresh the component state.
        /// </summary>
        /// <returns></returns>
        private Task OnPlaybackStartAsync() 
            => InvokeAsync(StateHasChanged);

        /// <summary>
        /// When playback ends, referesh the component state.
        /// </summary>
        /// <returns></returns>
        private Task OnPlaybackEndAsync()
            => InvokeAsync(StateHasChanged);

        public void Dispose()
        {
            // Unregister event handlers if needed
            PlaybackService.UnregisterOnStartPlaybackEvent(OnPlaybackStartAsync);
            PlaybackService.UnregisterOnStopPlaybackEvent(OnPlaybackEndAsync);
        }
    }
}