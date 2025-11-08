namespace FinalYearProject.Shared.Models.UI
{
    /// <summary>
    /// Holds information about the entire tab
    /// </summary>
    public class TabInformation
    {
        /// <summary>
        /// The name of this tab
        /// </summary>
        public string Title { get; set; } = "Unknown Title";

        /// <summary>
        /// The author of this tab
        /// </summary>
        public string Author { get; set; } = "Unknown Author";

        /// <summary>
        /// Short optional description of this tab
        /// </summary>
        public string Description
        {
            get => _description.Length > 400 ? _description[..400] : _description;
            set => _description = value;
        }

        private string _description = string.Empty;

        /// <summary>
        /// Holds the Bars of this tab
        /// </summary>
        public List<BarInformation> Bars { get; set; } = [];

        /// <summary>
        /// Holds how long the entire tab is in seconds
        /// </summary>
        public float TotalLengthInSeconds
            => Bars.Count == 0 ? 0 : Bars[^1].PositionInTab.EndTimestamp;

    }
}
