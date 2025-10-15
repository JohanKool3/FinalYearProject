using FinalYearProject.Shared.Models.TabRepresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.UI.Components.Helpers
{
    internal static class BarInformationHelper
    {
        // TODO: Pull all the calculation out of the Strings and Notes
        // and put them in this helper class

        internal static int CalculateUniqueStartPositions(MusicalBar bar)
        {
            var uniquePostions = bar.Notes.Select(n => n.StartTime).Distinct().Count();

            return Math.Max(uniquePostions,
                bar.TimeSignature.BeatsPerMeasure);
        }

        internal static int CalculateBarWidth(
            int timeSignatureSpace,
            int uniqueStartPositions,
            int noteSize,
            int notePadding)
            => timeSignatureSpace +
                (uniqueStartPositions
                * (noteSize + 2 * notePadding));
    }
}
