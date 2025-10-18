
namespace FinalYearProject.UI.Components.Models
{
    /// <summary>
    /// Holds information about a single bar in the tab
    /// </summary>
    public class BarDisplayInformation
    {
        //TODO: Add Time Singature here

        /// <summary>
        /// The Notes in this bar
        /// </summary>
        public List<NoteDisplayInformation> Notes { get; set; } = [];
    }
}
