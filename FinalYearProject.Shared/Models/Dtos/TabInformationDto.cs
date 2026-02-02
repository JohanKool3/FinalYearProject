namespace FinalYearProject.Shared.Models.Dtos
{
    public class TabInformationDto
    {
        /// <summary>
        /// The Name of the Tab / Piece
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Who Wrote this Tab / Piece
        /// </summary>
        public required string Author { get; set; }

        /// <summary>
        /// Description of this Piece / Tab
        /// </summary>
        public required string Description { get; set; }

        /// <summary>
        /// How long this Piece / Tab will last
        /// </summary>
        public required float TotalLengthInSeconds { get; set; }

        //TODO: Extend to Include Bar Information
        public List<BarInformationDto> Bars { get; set; } = [];
    }
}