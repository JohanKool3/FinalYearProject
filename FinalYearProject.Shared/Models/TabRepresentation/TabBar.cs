
namespace FinalYearProject.Shared.Models.TabRepresentation
{

    /// <summary>
    /// Representation of a Bar of music in a tablature format
    /// </summary>
    public class TabBar
    {
        /// <summary>
        /// The total number of beats in this bar
        /// </summary>
        public required TimeSignature TimeSignature { get; set; }

        /// <summary>
        /// The number of this bar in the tablature, starting from 1
        /// </summary>
        public int BarNumber { get; set; }

        /// <summary>
        /// Collection of all the notes in this bar
        /// </summary>
        public required List<TabNote> Notes { get; set; } = [];
    }
}
