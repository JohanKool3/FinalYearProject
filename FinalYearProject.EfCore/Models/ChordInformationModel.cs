using System;
using System.Collections.Generic;
using System.Text;

namespace FinalYearProject.EfCore.Models
{
    public class ChordInformationModel
    {
        /// <summary>
        /// How far across the bar the chord starts (0-100) in %
        /// </summary>
        public required double StartPercentage { get; set; }

        /// <summary>
        /// The Chord Name to display
        /// </summary>
        public required string ChordName { get; set; } = string.Empty;

        //TODO: Extend this to include more chord information
    }
}
