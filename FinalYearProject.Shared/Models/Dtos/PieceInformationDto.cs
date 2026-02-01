namespace FinalYearProject.Shared.Models.Dtos
{
    public class PieceInformationDto
    {
        /// <summary>
        /// Piece Id
        /// </summary>
        public Guid PieceId { get; set; }

        /// <summary>
        /// Name of the Piece
        /// </summary>
        public string PieceName { get; set; } = string.Empty;
    }
}
