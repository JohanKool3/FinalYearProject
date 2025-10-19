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
        /// The name of this tab
        /// </summary>
        public string Title { get; set; } = "Unknown Title";

        /// <summary>
        /// The author of this tab
        /// </summary>
        public string Author { get; set; } = "Unknown Author";

        /// <summary>
        /// Short optional description of this tab
        /// </summary>
        public string Description
        {
            get => _description.Length > 400 ? _description[..400] : _description;
            internal set => _description = value;
        }

        private string _description = string.Empty;


        /// <summary>
        /// Holds the Bars of this tab
        /// </summary>
        public List<BarDisplayInformation> Bars { get; set; } = [];

    }
}
