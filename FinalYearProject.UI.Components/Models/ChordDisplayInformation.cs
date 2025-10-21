using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.UI.Components.Models
{
    public class ChordDisplayInformation
    {
        /// <summary>
        /// How far accross the bar the chord starts (0-100) in %
        /// </summary>
        public int BarPercentage { get; set; }

        /// <summary>
        /// The Chord Name to display
        /// </summary>
        public string ChordName { get; set; } = string.Empty;

        //TODO: Extend this to include more chord information
    }
}
