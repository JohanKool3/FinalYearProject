namespace FinalYearProject.UI.Components.Services
{
    /// <summary>
    /// Service to manage Tab playback
    /// </summary>
    public class PlaybackService(DisplayService displayService)
    {
        #region Services

        /// <summary>
        /// Registers the display service to get tab information from
        /// </summary>
        public DisplayService DisplayService { get; } = displayService;

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
            
            return InvokeOnStartPlaybackEvent();

            // TODO: Implement Timer here to update
            // CurrentTimeInSeconds based on Bpm of current bar
        }

        /// <summary>
        /// Stops playback of tab.
        /// </summary>
        public Task StopPlaybackAsync()
        {
            // TODO: Implement Stopping of Timer here
            IsPlaying = false;

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

    }
}
