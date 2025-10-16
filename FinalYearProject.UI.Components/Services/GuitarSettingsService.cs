using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.UI.Components.Services
{
    /// <summary>
    /// Holds settings related to the Guitar display
    /// </summary>
    public class GuitarSettingsService
    {
        /// <summary>
        /// The number of strings to display on the guitar
        /// </summary>
        public int StringCount { get; private set; } = 6;

        public void SetStringCount(int count)
        {
            if (count < 0 || count > 18)
                throw new ArgumentOutOfRangeException(nameof(count), "String count must be between 0 and 18.");
            StringCount = count;
        }
    }
}
