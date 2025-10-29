using FinalYearProject.Shared.Models.UI.Bar;

namespace FinalYearProject.Shared.Helpers
{
    /// <summary>
    /// Helper Class for Note Related Methods
    /// </summary>
    public static class NoteHelper
    {
        /// <summary>
        /// Returns the Length of a given Note in Beats
        /// </summary>
        /// <param name="note"></param>
        /// <param name="noteGroupInformation"></param>
        /// <returns></returns>
        public static double GetNoteLength(NoteInformation note, NoteGroupInformation noteGroupInformation)
        {
            // Get the Group Length in Beats
            var groupLengthInBeats = noteGroupInformation.TotalGroupBeatLength;

            // Get the Group Percentage Length
            var groupLengthPercentage = 
               GetGroupLengthPercentage(note);

            return groupLengthInBeats * groupLengthPercentage;
        }

        #region Helper Methods

        private static double GetGroupLengthPercentage(NoteInformation note)
            => Math.Abs(note.EndPercentage - note.StartPercentage)
                / 100.0;

        #endregion
    }
}
