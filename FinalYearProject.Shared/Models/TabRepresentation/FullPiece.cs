
namespace FinalYearProject.Shared.Models.TabRepresentation
{
    /// <summary>
    /// Representation of a full tablature piece, consisting of multiple bars
    /// </summary>
    public class FullPiece
    {
        /// <summary>
        /// Holds all the bars in this tablature piece
        /// </summary>
        public required List<MusicalBar> Bars { get; set; }
    }
}
