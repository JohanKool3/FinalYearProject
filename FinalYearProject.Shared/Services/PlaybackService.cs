using FinalYearProject.Shared.Models.UI;

namespace FinalYearProject.Shared.Services
{
    /// <summary>
    /// Service to manage Tab playback
    /// </summary>
    public class PlaybackService(DisplayService displayService,
        GlobalTimerService timer)
    {
        #region Services

        /// <summary>
        /// Registers the display service to get tab information from
        /// </summary>
        public DisplayService DisplayService { get; } = displayService;
        public GlobalTimerService Timer { get; } = timer;

        #endregion

        #region Properties

        /// <summary>
        /// Returns whether the tab is currently being played.
        /// </summary>
        public bool IsPlaying { get; private set; } = false;

        /// <summary>
        /// Keeps track of the current progress through the tab as a time
        /// </summary>
        public float CurrentTimeInSeconds { get; private set; } = 0;

        /// <summary>
        /// How long the current tab is in total, in seconds
        /// </summary>
        public float TotalTabLengthInSeconds
            => DisplayService.CurrentTab?.TotalLengthInSeconds ?? 0;

        #endregion


        private event Func<Task>? OnStartPlayback;

        private event Func<Task>? OnStopPlayback;

        #region Registration of Events

        /// <summary>
        /// Registers a callback for when playback is started
        /// </summary>
        /// <param name="event"></param>
        public void RegisterOnStartPlaybackEvent(Func<Task> @event)
        {
            OnStartPlayback += @event;
        }

        /// <summary>
        /// Registers a callback for when playback is stopped
        /// </summary>
        /// <param name="event"></param>
        public void RegisterOnStopPlaybackEvent(Func<Task> @event)
        {
            OnStopPlayback += @event;
        }

        /// <summary>
        /// Removes a callback for when playback is started.
        /// Prevents memory leaks and invocations of non existent methods.
        /// </summary>
        /// <param name="event"></param>
        public void UnregisterOnStartPlaybackEvent(Func<Task> @event)
        {
            OnStartPlayback -= @event;
        }

        /// <summary>
        /// Removes a callback for when playback is stopped. 
        /// Prevents memory leaks and invocations of non existent methods.
        /// </summary>
        /// <param name="event"></param>
        public void UnregisterOnStopPlaybackEvent(Func<Task> @event)
        {
            OnStopPlayback -= @event;
        }

        #endregion

        #region Events Invocation
        private async Task InvokeOnStartPlaybackEvent()
        {
            if (OnStartPlayback is null)
            {
                return;
            }

            await OnStartPlayback.Invoke();
        }

        /// <summary>
        /// Call the registered OnStopPlayback events
        /// </summary>
        /// <returns></returns>
        private async Task InvokeOnStopPlaybackEvent()
        {
            if (OnStopPlayback is null)
            {
                return;
            }

            await OnStopPlayback.Invoke();

        }
        #endregion

        #region Playback Controls

        /// <summary>
        /// Starts playback of tab
        /// </summary>
        public Task StartPlaybackAsync()
        {
            IsPlaying = true;

            Timer.Start();
            
            return InvokeOnStartPlaybackEvent();
        }

        /// <summary>
        /// Stops playback of tab.
        /// </summary>
        public Task StopPlaybackAsync()
        {
            // TODO: Implement Stopping of Timer here
            IsPlaying = false;

            Timer.Stop();

            return InvokeOnStopPlaybackEvent();
        }

        public Task ResetPlaybackAsync()
        {
            // Currently, resetting playback only stops it.
            StopPlaybackAsync();
            SetProgress(0f);

            return InvokeOnStopPlaybackEvent();
        }

        /// <summary>
        /// Sets the current progress percentage for playback, 
        /// clamped between 0% and 100%
        /// </summary>
        /// <param name="playbackPercentage"></param>
        /// <remarks>
        /// This is used for seeking across the tab during playback.
        /// </remarks>
        public void SetProgress(float playbackPercentage)
        {
            // Get a Fraction of the total length
            var progressPercentage = 1 / Math.Clamp(playbackPercentage, 0, 100);

            // Set Current Time based on percentage of total length
            // this way we don't have to recalculate the entire tab length
            CurrentTimeInSeconds
                = TotalTabLengthInSeconds * progressPercentage;
        }

        #endregion


        private double GetBarDuration(BarInformation bar)
        {
            double secondsPerQuarter = 60.0 / DisplayService.Bpm;

            double beatMultiplier = 4.0 / bar.TimeSignature.BeatUnit;

            return secondsPerQuarter * beatMultiplier * bar.TimeSignature.BeatsPerMeasure;
        }

        private int GetCurrentBar(double elapsedSeconds)
        {
            double accumulated = 0;

            var bars = DisplayService?.CurrentTab?.Bars ?? [];

            for (int i = 0; i < bars.Count; i++)
            {
                double duration = GetBarDuration(bars[i]);

                if (elapsedSeconds < accumulated + duration)
                {
                    return i;
                }

                accumulated += duration;
            }

            // Stop Playback as we have reached the end
            return -1;
        }

        public bool IsBarActive(int barNumber, double time)
        {
            var currentBar = GetCurrentBar(time);
            var barIndex = barNumber - 1;

            return currentBar == barIndex;
        }
    }
}
