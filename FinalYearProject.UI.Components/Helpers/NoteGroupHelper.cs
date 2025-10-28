using FinalYearProject.UI.Components.Models.InterfaceElements.Bar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.UI.Components.Helpers
{
    public static class NoteGroupHelper
    {
        /// <summary>
        /// Gets the Width of the Note Group
        /// </summary>
        /// <param name="parentBarWidth">The Width of the container</param>
        /// <param name="noteGroup">The Note Group for which width is being calculated</param>
        /// <returns></returns>
        public static int GetNoteGroupWidth(int parentBarWidth
            , NoteGroupInformation noteGroup)
        {
            // Calculate the percentage width of the note group
            var percentageWidth = Math.Abs(noteGroup.BarEndPercentage - noteGroup.BarStartPercentage);

            return (int)(parentBarWidth * (percentageWidth / 100.0));
        }
    }
}
