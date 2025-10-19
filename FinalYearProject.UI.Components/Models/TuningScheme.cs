using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.UI.Components.Models
{
    /// <summary>
    /// Holds information about each string and its tuning
    /// </summary>
    public class TuningScheme
    {
        /// <summary>
        /// Holds a dictionary mapping string numbers to their respective tunings
        /// </summary>
        /// <remarks>
        /// String 1 refers to the highest-pitched string (thinnest string),
        /// </remarks>
        public required Dictionary<int, string> StringTunings { get; set; }

        public static TuningScheme SixStringStandard 
            => new()
            {
            StringTunings = new Dictionary<int, string>
            {
                { 1, "e" },
                { 2, "b" },
                { 3, "g" },
                { 4, "D" },
                { 5, "A" },
                { 6, "E" }
            }
        };
    }
}
