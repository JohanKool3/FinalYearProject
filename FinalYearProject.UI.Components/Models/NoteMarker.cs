using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.UI.Components.Models
{
    /// <summary>
    /// Holds information about where a note marker is to be placed in a 
    /// Tab Bar
    /// </summary>
    internal class NoteMarker
    {
        /// <summary>
        /// 0 = top string, 6 = bottom string
        /// </summary>
        public int StringIndex { get; set; }

        /// <summary>
        // X position as a fraction of the bar from 0.0 (left) to 1.0 (right)
        /// </summary>
        public double Position { get; set; }

        // The Fret Number to display
        public int Fret { get; set; }
    }
}
