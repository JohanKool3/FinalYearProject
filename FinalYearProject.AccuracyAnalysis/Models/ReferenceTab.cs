
namespace FinalYearProject.Accuracy.Analysis.Models
{
    public class ReferenceTab
    {
        public List<NoteGroup> NoteGroups { get; set; } = [];

        /// <summary>
        /// The Beats Per Minute of the Reference Tab
        /// </summary>
        public int Bpm { get; set; }
    }
}
