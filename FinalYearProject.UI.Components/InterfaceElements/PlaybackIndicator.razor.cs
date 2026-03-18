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
        PlaybackService playbackService)
        {
            RepresentationService = representationService;
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
            => PlaybackService.IsPlaying;

        private Stopwatch _clock = new();
        private CancellationTokenSource? _playbackCts;

        /// <summary>
        /// When playback starts, refresh the component state.
        /// </summary>
        /// <returns></returns>
        private Task OnPlaybackStartAsync()
        {
            _playbackCts?.Cancel(); // stop previous clock if any
            _playbackCts = new CancellationTokenSource();

            _ = RunPlaybackClock(_playbackCts.Token);

            return InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// When playback ends, referesh the component state.
        /// </summary>
        /// <returns></returns>
        private Task OnPlaybackEndAsync()
        {
            _playbackCts?.Cancel();
            return InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            // Unregister event handlers if needed
            PlaybackService.UnregisterOnStartPlaybackEvent(OnPlaybackStartAsync);
            PlaybackService.UnregisterOnStopPlaybackEvent(OnPlaybackEndAsync);
        }


        private int _playbackXPosition = 0;

        private async Task RunPlaybackClock(CancellationToken token)
        {
            _clock.Restart();

            double secondsPerBeat = 60.0 / DisplayService.Bpm;
            double secondsPerBar = secondsPerBeat * BarTimeSignature.BeatsPerMeasure;

            while (!token.IsCancellationRequested)
            {
                double elapsed = _clock.Elapsed.TotalSeconds;

                double barProgress = (elapsed % secondsPerBar) / secondsPerBar;

                _playbackXPosition = (int)(barProgress * ParentBarWidth);

                // Ensure that the XPosition is within valid bounds
                _playbackXPosition = Math.Clamp(_playbackXPosition, XPosition, ParentBarWidth);

                await InvokeAsync(StateHasChanged);

                await Task.Delay(8, token);
            }
        }
    }
}