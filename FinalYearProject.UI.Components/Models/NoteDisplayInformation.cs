
namespace FinalYearProject.UI.Components.Models
{
    public class NoteDisplayInformation
    {
        /// <summary>
        /// How far accross the bar the note is (0-100)
        /// </summary>
        public int BarPercentage { get; set; }

        /// <summary>
        /// Which Fret the note is on
        /// </summary>
        public int FretNumber { get; set; }

        /// <summary>
        /// Which String the note is on (1-6)
        /// </summary>
        public int StringNumber { get; set; } = 6;

    }
}
