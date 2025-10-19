using FinalYearProject.UI.Components.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.UI.Components.Helpers
{
    /// <summary>
    /// Used to determine whether to render certain parts of a Bar
    /// </summary>
    internal static class BarConditionalRenderingHelper
    {
        /// <summary>
        /// Determines whether to render the time signature for the current bar
        /// </summary>
        /// <param name="previousBar"></param>
        /// <param name="currentBar"></param>
        /// <returns></returns>
        internal static bool RenderTimeSignature(BarDisplayInformation? previousBar,
            BarDisplayInformation currentBar)
        {
            // Always render if there is no previous bar
            if (previousBar == null)
            {
                return true;
            }

            // Render if the time signatures are different
            return !previousBar.TimeSignature.Equals(currentBar.TimeSignature);
        }
    }
}
