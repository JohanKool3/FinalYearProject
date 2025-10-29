using FinalYearProject.Shared.Models.TabRepresentation;
using FinalYearProject.UI.Components.Models.InterfaceElements.Bar;
using FinalYearProject.UI.Components.Models.Settings;

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
