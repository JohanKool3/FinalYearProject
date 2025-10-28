using FinalYearProject.UI.Components.Models.InterfaceElements.Bar;
using FinalYearProject.UI.Components.Models.Settings;
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
        /// <param name="settings">The settings</param>
        /// <param name="noteGroup">The Note Group for which width is being calculated</param>
        /// <returns></returns>
        public static int GetNoteGroupWidth(RepresentationSettings settings,
             NoteGroupInformation noteGroup)
        {
            // Note Spacing, multiplied by the number of notes, plus padding on either side
            return (settings.Notes.NoteSpacing * noteGroup.Notes.Count)
                + (settings.Notes.LeftPadding * 2);
        }
    }
}
