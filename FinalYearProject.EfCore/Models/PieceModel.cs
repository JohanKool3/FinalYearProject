using FinalYearProject.Shared.Models.Dtos;

namespace FinalYearProject.EfCore.Models
{
    /// <summary>
    /// Represents a Piece of Tab that will be stored in a database
    /// </summary>
    public class PieceModel
    {
        /// <summary>
        /// Unique Identifier for this Piece
        /// </summary>
        public required Guid Id { get; set; }

        public required string PieceName { get; set; }

        /// <summary>
        /// Full set of Tab Information for this Piece
        /// </summary>
        public required ReferenceTabDto ReferenceTab { get; set; }
    }
}
