using FinalYearProject.Shared.Models.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.Services.Helpers
{
    /// <summary>
    /// Calculates information about positioning of bars within a Tab
    /// </summary>
    public static class BarPositioningHelper
    {
        internal static List<BarInformation> CalculateBarPositionsInTab(List<BarInformation> bars)
        {
            // Iterate over each bar and assign start and end timestamps
            var currentTime = 0f;
            foreach (var bar in bars)
            {
                var barLengthInSeconds = CalculateBarLengthInSeconds(bar);
                
                bar.PositionInTab.StartTimestamp = currentTime;
                bar.PositionInTab.EndTimestamp = currentTime + barLengthInSeconds;
                currentTime += barLengthInSeconds;
            }

            return bars;
        }

        /// <summary>
        /// Calculate how long a single bar is in seconds
        /// </summary>
        /// <param name="bar"></param>
        /// <returns></returns>
        private static float CalculateBarLengthInSeconds(BarInformation bar)
        {
            // 1. Get the Denominator (Beat Unit)
            // 2. Divide by 4 to get fraction of whole note
            // 3. Multiply by number of beats (Numerator)
            // 4. Calculate seconds per beat from BPM
            var beatUnitFraction = bar.TimeSignature.BeatUnit / 4f;
            var beatsInBar = bar.TimeSignature.BeatsPerMeasure * beatUnitFraction;
            var beatsPerSecond = bar.Bpm / 60f;
            
            return  beatsInBar / beatsPerSecond;
        }
    }
}
