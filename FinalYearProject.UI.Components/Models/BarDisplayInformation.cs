
using FinalYearProject.Shared.Models.TabRepresentation;

namespace FinalYearProject.UI.Components.Models
{
    /// <summary>
    /// Holds information about a single bar in the tab
    /// </summary>
    public class BarDisplayInformation
    {
        /// <summary>
        /// 
        /// </summary>
        public TimeSignature TimeSignature { get; set; } 
            = TimeSignature.Default;

        /// <summary>
        /// The Notes in this bar
        /// </summary>
        public List<NoteDisplayInformation> Notes { get; set; } = [];
    }
}
