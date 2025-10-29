using FinalYearProject.UI.Components.Models.InterfaceElements.Bar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.UI.Components.Helpers
{
    internal static class NoteHelper
    {
        internal static double GetNoteLength(NoteInformation note, NoteGroupInformation noteGroupInformation)
        {
            // Get the Group Length in Beats
            var groupLengthInBeats = noteGroupInformation.TotalGroupBeatLength;

            // Get the Group Percentage Length
            var groupLengthPercentage = 
               GetGroupLengthPercentage(note);

            return groupLengthInBeats * groupLengthPercentage;
        }

        private static double GetGroupLengthPercentage(NoteInformation note)
            => Math.Abs(note.EndPercentage - note.StartPercentage)
                / 100.0;
    }
}
