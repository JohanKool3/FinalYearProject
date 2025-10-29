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

        public static DurationMetadata GetDurationMetadata(double lengthInBeats)
        {
            // TODO: Extend this for Triplet values
            return CalculateStandardDurationMetadata(lengthInBeats);

        }


        #region Helper Methods

        private static double GetGroupLengthPercentage(NoteInformation note)
            => Math.Abs(note.EndPercentage - note.StartPercentage)
                / 100.0;


        private static DurationMetadata CalculateStandardDurationMetadata(double lengthInBeats)
        {
            var currentLength = lengthInBeats;
            var division = 2.0d;
            var dottedAmount = 0;

            while (currentLength > 0.0d)
            {
                double fractionalValue = (1.0d / division);

                if (currentLength < fractionalValue)
                {
                    division *= 2;
                }
                else
                {
                    // Subtract the value
                    currentLength -= fractionalValue;

                    // Check if the current length is zero
                    while (currentLength > 0)
                    {
                        // Check for dotted values
                        fractionalValue /= 2.0d;
                        if (currentLength >= fractionalValue)
                        {
                            currentLength -= fractionalValue;
                            dottedAmount++;
                        }
                    }
                }
            }

            return new()
            {
                Subdivision = (int)division,
                DottedAmount = 0
            };

            #endregion
        }
    }
}
