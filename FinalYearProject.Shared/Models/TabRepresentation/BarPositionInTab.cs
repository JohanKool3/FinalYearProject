namespace FinalYearProject.Shared.Models.TabRepresentation
{
    /// <summary>
    /// Holds information about where a bar is in the tab as a whole
    /// </summary>
    public class BarPositionInTab
    {
        /// <summary>
        /// When the Bar Starts Relative to the Tab in Time
        /// </summary>
        public float StartTimestamp { get; set; }

        /// <summary>
        /// When the Bar Ends Relative to the Tab in Time
        /// </summary>
        public float EndTimestamp { get; set; }

        /// <summary>
        /// How Long the Bar is Relative to the Tab in Seconds
        /// </summary>
        public float Length 
            => EndTimestamp - StartTimestamp;

        /// <summary>
        /// Creates a Default Bar Position in Tab
        /// </summary>
        /// <remarks>
        /// Default Values Include:
        /// <list type="bullet">
        /// <item>StartTimestamp: 0 seconds</item>
        /// <item>EndTimestamp: 0 seconds</item>
        /// <item>Length: 0 seconds</item>
        /// </list>
        /// </remarks>
        public static BarPositionInTab Default => new()
        {
            StartTimestamp = 0,
            EndTimestamp = 0
        };
    }
}