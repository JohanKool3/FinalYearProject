using FinalYearProject.UI.Components.Interfaces;
using System;

namespace FinalYearProject.UI.Components.Models
{
    /// <summary>
    /// Represents a Grouping of Notes
    /// </summary>
    public class NoteGroupDisplayInformation
    {
        /// <summary>
        /// The Notes that are assigned to this group
        /// </summary>
        public List<NoteDisplayInformation> Notes { get; set; } = [];

        /// <summary>
        /// Where this Group Starts Relative to the Bar (0-100%)
        /// </summary>
        public int BarStartPercentage { get; set; }

        /// <summary>
        /// Where this Groups Ends Relative to the Bar (0-100%)
        /// </summary>
        public int BarEndPercentage { get; set; }

    }
}
