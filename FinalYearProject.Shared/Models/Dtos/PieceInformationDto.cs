namespace FinalYearProject.Shared.Models.Dtos
{
    /// <summary>
    /// Outlines basic information about a Piece to be displayed
    /// to the user in a selectable list.
    /// </summary>
    public class PieceInformationDto
    {
        /// <summary>
        /// Piece Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the Piece
        /// </summary>
        public string PieceName { get; set; } = string.Empty;

        /// <summary>
        /// The Person / Group who made this piece
        /// </summary>
        public string Author { get; set; } = string.Empty;

        /// <summary>
        /// Description of the Piece
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
