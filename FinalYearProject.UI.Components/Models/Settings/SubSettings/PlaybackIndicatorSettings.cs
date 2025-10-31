namespace FinalYearProject.UI.Components.Models.Settings.SubSettings
{
    public class PlaybackIndicatorSettings
    {
        /// <summary>
        /// How tall the Playback Indicator is
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// How wide the Playback Indicator is
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// What color the Playback Indicator is
        /// </summary>
        public string Color { get; set; } = "black";
    }
}