using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.UI.Components.Models
{
    /// <summary>
    /// Holds information about the entire tab
    /// </summary>
    public class TabDisplayInformation
    {
        /// <summary>
        /// The Beats Per Minute (BPM) of this tab
        /// </summary>
        public int Bpm { get; set; } = 120;

        /// <summary>
        /// The name of this tab
        /// </summary>
        public string Title { get; set; } = "Unknown Title";

        /// <summary>
        /// The author of this tab
        /// </summary>
        public string Author { get; set; } = "Unknown Author";

        /// <summary>
        /// Holds the Bars of this tab
        /// </summary>
        public List<BarDisplayInformation> Bars { get; set; } = [];
    }
}
