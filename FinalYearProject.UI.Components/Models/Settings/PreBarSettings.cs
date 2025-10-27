using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.UI.Components.Models.Settings
{
    /// <summary>
    /// Holds settings related to the display of Time Signatures
    /// </summary>
    public class PreBarSettings
    {
        /// <summary>
        /// How Much space to leave between the Time Signature and the left edge of the Bar
        /// </summary>
        public int TimeSignatureWidth { get; set; } = 20;

        /// <summary>
        /// How much space to leave between the Tuning and the left edge of the Bar
        /// </summary>
        public int TuningWidth { get; set; } = 20;

        /// <summary>
        /// How large the font for the Tuning display should be
        /// </summary>
        public int TuningFontSize { get; set; } = 12;
    }
}
