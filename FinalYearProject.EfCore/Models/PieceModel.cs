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

        /// <summary>
        /// Holds information about the Tab
        /// </summary>
        public required TabInformationModel TabInformationModel { get; set; }
    }
}
