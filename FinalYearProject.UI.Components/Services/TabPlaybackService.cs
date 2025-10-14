
namespace FinalYearProject.UI.Components.Services
{
    public class TabPlaybackService
    {

        /// <summary>
        /// Returns whether the tab is currently being played.
        /// </summary>
        public bool IsPlaying { get; private set; }

        public int Bpm { get; private set; }

        public TabPlaybackService()
        {
            Bpm = 120;
            IsPlaying = false;
        }

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

        public void SetBpm(int bpm)
        {
            Bpm = Math.Clamp(bpm, 20, 300);
        }
    }
}
