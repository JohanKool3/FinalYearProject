namespace FinalYearProject.EfCore.Models
{
    /// <summary>
    /// Holds the Display Information for this Tab
    /// </summary>
    public class TabInformationModel
    {
        /// <summary>
        /// Name of the Piece / Tab
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Who Wrote this Piece / Tab
        /// </summary>
        public required string Author { get; set; }

        /// <summary>
        /// Short description of this piece / Tab
        /// </summary>
        public required string Description { get; set; }

        /// <summary>
        /// How long this piece lasts in seconds
        /// </summary>
        public required float TotalLengthInSeconds { get; set; }
    }
}