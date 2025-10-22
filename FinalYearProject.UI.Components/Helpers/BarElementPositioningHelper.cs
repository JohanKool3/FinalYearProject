using FinalYearProject.UI.Components.Interfaces;
using FinalYearProject.UI.Components.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.UI.Components.Helpers
{
    internal static class BarElementPositioningHelper
    {
        /// <summary>
        /// Get the X Coordinate for the Note
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public static int GetNoteXPosition(IPositionedElement note, 
            int leftPadding,
            int width)
        {
            // Calculate the position based on the BarPercentage and Width
            return leftPadding + (int)(note.BarPercentage / 100.0 * width);
        }
    }
}
