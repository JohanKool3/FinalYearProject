
namespace FinalYearProject.Shared.Models.TabRepresentation
{
    /// <summary>
    /// Representation of a full tablature piece, consisting of multiple bars
    /// </summary>
    public class FullTab
    {
        /// <summary>
        /// Holds all the bars in this tablature piece
        /// </summary>
        public required List<TabBar> Bars { get; set; }
    }
}
