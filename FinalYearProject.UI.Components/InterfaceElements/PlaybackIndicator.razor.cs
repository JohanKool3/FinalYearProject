using FinalYearProject.Shared.Models.TabRepresentation;
using FinalYearProject.UI.Components.Models.Settings;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements
{
    public partial class PlaybackIndicator(
        SettingsService representationService,
        DisplayService displayService,
        PlaybackService playbackService) : IDisposable
    {

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
        /// The width of the parent bar that the indicator is linked to
        /// </summary>
        [Parameter]
        public int ParentBarWidth { get; set; }

        #endregion

        #region Services
        
        public RepresentationSettings Settings { get; } = representationService.Settings;
        
        private int _bpm => displayService.Bpm;
        
        public PlaybackService PlaybackService { get; } = playbackService;
        
        #endregion

        private PeriodicTimer? _timer;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _timer = new PeriodicTimer(TimeSpan.FromMilliseconds(GetFrameTime()));
                await foreach (var _ in RunAnimation(_timer))
                {
                    StateHasChanged();
                }
            }
        }

        private long GetFrameTime()
            => 1000 / Settings.PlaybackIndicator.FramesPerSecond;

        private async IAsyncEnumerable<int> RunAnimation(PeriodicTimer timer)
        {
            int frame = 0;
            while (await timer.WaitForNextTickAsync())
            {
                // Only move if playback is active
                if (PlaybackService.IsPlaying)
                {
                    // Calculate pixels per frame based on BPM
                    var speed = CalculateSpeedFromBpm();
                    XPosition += speed;
                }
                yield return frame++;
            }
        }

        private int CalculateSpeedFromBpm()
        {
            int beatsPerBar = BarTimeSignature.BeatsPerMeasure;
            long frameTimeMs = GetFrameTime();

            return (int)(ParentBarWidth * _bpm * frameTimeMs) / (60000 * beatsPerBar);
        }

        public void Dispose()
            => _timer?.Dispose();


        #region Settings

        private int _width
            => Settings.PlaybackIndicator.Width;

        private int _height
            => Settings.PlaybackIndicator.Height;

        private string _color
            => Settings.PlaybackIndicator.Color;

        private bool _isVisible
            => true; // TODO: Pull this from the playback service

        #endregion
    }
}