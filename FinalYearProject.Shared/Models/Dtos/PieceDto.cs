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
        /// Name of the Piece
        /// </summary>
        public required string PieceName { get; set; }

        /// <summary>
        /// Full set of Tab Information for this Piece
        /// </summary>
        public required ReferenceTabDto ReferenceTab { get; set; }
    }
}
