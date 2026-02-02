namespace FinalYearProject.Shared.Models.Dtos
{
    /// <summary>
    /// Holds the information for a Piece to be transferred over the API
    /// </summary>
    public class PieceDto
    {
        /// <summary>
        /// Unique Identifier for this Piece
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// The Display Information for this Piece
        /// </summary>
        public required TabInformationDto TabInformation { get; set; }

    }
}
