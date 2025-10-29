using FinalYearProject.Shared.Models.TabRepresentation;
using FinalYearProject.Shared.Models.UI.Bar;

namespace FinalYearProject.Shared.Helpers
{
    public static class NoteGroupHelper
    {
        /// <summary>
        /// Get the Total Beat Length of the Note Group
        /// </summary>
        /// <param name="parentBarTimeSignature">The time signature of the bar that the noteGroup is a part of</param>
        /// <param name="noteGroup">The NoteGroup</param>
        /// <returns></returns>
        public static double GetNoteGroupTotalBeatLength(
            TimeSignature parentBarTimeSignature,
            NoteGroupInformation noteGroup)
        {
            // Get the Beats per Measure
            var beatsPerMeasure = parentBarTimeSignature.BeatsPerMeasure;

            // Get the Relative Length
            var lengthOfGroupComparedToBarPercentage = 
                    GetNoteGroupLengthPercentage(noteGroup);

            var noteGroupBeats =  beatsPerMeasure
                * lengthOfGroupComparedToBarPercentage;

            return noteGroupBeats;
        }

        #region Helper Methods
        
        /// <summary>
        /// Gets the Length Percentage of the Note Group (0.0 - 1.0)
        /// </summary>
        /// <param name="noteGroup"></param>
        /// <returns></returns>
        private static double GetNoteGroupLengthPercentage(NoteGroupInformation noteGroup)
            => Math.Abs(noteGroup.BarEndPercentage - noteGroup.BarStartPercentage) / 100.0;

        #endregion
    }
}
