using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.UI.Components.Models.Settings.SubSettings
{
    /// <summary>
    /// Holds settings related to the display of notes
    /// </summary>
    public class NoteSettings
    {
        /// <summary>
        /// How much space to leave at the top
        /// </summary>
        public int TopPadding { get; set; }

        /// <summary>
        /// How much space to leave at the left
        /// </summary>
        public int LeftPadding { get; set; }


        /// <summary>
        /// How much space to leave between each note
        /// </summary>
        public int NoteSpacing { get; set; }

        /// <summary>
        /// How much space to leave between each string
        /// </summary>
        public int StringSpacing { get; set; }
    }
}
