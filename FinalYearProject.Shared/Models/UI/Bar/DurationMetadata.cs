using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.Shared.Models.UI.Bar
{
    /// <summary>
    /// Holds The Subdivision and Dotted amount for a given Note
    /// </summary>
    public class DurationMetadata
    {
        /// <summary>
        /// How many Parts the Beat has been Divided into (e.g. 2, 3, 4)
        /// </summary>
        public int Subdivision { get; set; }

        /// <summary>
        /// How many dots are applied to the note (e.g. 1 for dotted, 2 for double dotted)
        /// </summary>
        public int DottedAmount { get; set; }
        }
}
