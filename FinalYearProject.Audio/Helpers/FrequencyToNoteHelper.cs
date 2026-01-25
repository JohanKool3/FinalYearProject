using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.Audio.Helpers
{
    public static class FrequencyToNoteHelper
    {

        /// <summary>
        /// Given a frequency and the A4 frequency, calculate the nearest semi-tone offset from A4
        /// </summary>
        /// <param name="frequency"></param>
        /// <param name="a4_frequency"></param>
        /// <returns></returns>
        public static int GetFrequencySemiTonesFromA4(float frequency, double a4_frequency)
        {
            // Calculate the number of semi-tones from A4
            int semiTonesFromA4 = (int)Math.Round(12 * Math.Log2(frequency / a4_frequency));
            return semiTonesFromA4;
        }
    }
}
