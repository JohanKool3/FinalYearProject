using FinalYearProject.Shared.Models.TabRepresentation;
using FinalYearProject.Shared.Services;
using FinalYearProject.UI.Components.Models.Settings;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace FinalYearProject.UI.Components.InterfaceElements
{
    public partial class PlaybackIndicator : IDisposable

    {
        public PlaybackIndicator(SettingsService representationService,
        SettingsService settingsService,
        DisplayService displayService,
        PlaybackService playbackService,
        GlobalTimerService timer)
        {
            RepresentationService = representationService;
            DisplayService = displayService;
            PlaybackService = playbackService;
            Timer = timer;

            // Register to be notified when settings change
            RegisterEventHandlers();

        }

        #region Event Handlers

        private void RegisterEventHandlers()
        {
            Timer.OnTick += HandleTickAsync;
            PlaybackService.RegisterOnStartPlaybackEvent(OnPlaybackStartAsync);
            PlaybackService.RegisterOnStopPlaybackEvent(OnPlaybackEndAsync);
        }

        #endregion

        #region Parameters

        /// <summary>
        /// Where the Playback Indicator is positioned on the Y axis
        /// </summary>
        [Parameter]
        public int YPosition { get; set; }

        /// <summary>
        /// Where in the bar the indicator should start (Used when a time signature is present)
        /// </summary>
        [Parameter]
        public int XPosition { get; set; }

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
        public DisplayService DisplayService { get; }

        private RepresentationSettings Settings
            => RepresentationService.Settings;

        public PlaybackService PlaybackService { get; }
        public GlobalTimerService Timer { get; }

        #endregion

        #region Settings

        private int _width
            => Settings.PlaybackIndicator.Width;

        private int _height
            => Settings.PlaybackIndicator.Height;

        private string _color
            => Settings.PlaybackIndicator.Color;

        #endregion

        private bool _isVisible
            => PlaybackService.IsPlaying &&
               PlaybackService.IsBarActive(BarNumber, Timer.CurrentTime);

        /// <summary>
        /// When playback starts, refresh the component state.
        /// </summary>
        /// <returns></returns>
        private Task OnPlaybackStartAsync()
        {
            return InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// When playback ends, referesh the component state.
        /// </summary>
        /// <returns></returns>
        private Task OnPlaybackEndAsync()
        {
            return InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            // Unregister event handlers if needed
            PlaybackService.UnregisterOnStartPlaybackEvent(OnPlaybackStartAsync);
            PlaybackService.UnregisterOnStopPlaybackEvent(OnPlaybackEndAsync);
        }

        private int _playbackXPosition = 0;

        private Task HandleTickAsync()
        {
            double time = Timer.CurrentTime;

            // Calculate the modulo of the position within the bar
            double secondsPerBeat = 60.0 / DisplayService.Bpm;
            double barDuration = secondsPerBeat * BarTimeSignature.BeatsPerMeasure;

            double timeInBar = time % barDuration;

            double progress = timeInBar / barDuration;

            _playbackXPosition = (int)(progress * ParentBarWidth);
            _playbackXPosition = Math.Clamp(_playbackXPosition, XPosition, ParentBarWidth);

            return InvokeAsync(StateHasChanged);
        }
    }
}