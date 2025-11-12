namespace FinalYearProject.UI.Components.Services
{
    /// <summary>
    /// Service to manage Tab playback
    /// </summary>
    public class PlaybackService(DisplayService displayService)
    {
        /// <summary>
        /// Registers the display service to get tab information from
        /// </summary>
        public DisplayService DisplayService { get; } = displayService;

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
            SetProgress(0f);
        }

        /// <summary>
        /// Sets the current progress percentage for playback, 
        /// clamped between 0% and 100%
        /// </summary>
        /// <param name="playbackPercentage"></param>
        public void SetProgress(float playbackPercentage)
        {
            // Get a Fraction of the total length
            var progressPercentage = 1 / Math.Clamp(playbackPercentage, 0, 100);

            // Set Current Time based on percentage of total length
            // this way we don't have to recalculate the entire tab length
            CurrentTimeInSeconds
                = TotalTabLengthInSeconds * progressPercentage;
        }

    }
}
