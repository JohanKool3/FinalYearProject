using FinalYearProject.Shared.Models.UI.Bar;

namespace FinalYearProject.Shared.Helpers
{
    public static class NoteHelper
    {
        public static double GetNoteLength(NoteInformation note, NoteGroupInformation noteGroupInformation)
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
