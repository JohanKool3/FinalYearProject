namespace FinalYearProject.Audio.Helpers
{
    public static class FrequencyToNoteHelper
    {

        /// <summary>
        /// Given a frequency and the A4 frequency, calculate its MIDI note number.
        /// </summary>
        /// <param name="frequency"></param>
        /// <param name="a4_frequency"></param>
        /// <returns></returns>
        public static int GetFrequencySemiTones(float frequency, double a4_frequency)
        {
            // Special case when frequency is 0 Hz, this will be lowest note possible
            if (frequency == 0)
            {
                return 0;
            }

            // Ensure the Frequency is within a valid range
            if (frequency < 0 || frequency > 20000)
            {
                throw new ArgumentOutOfRangeException(nameof(frequency), "Frequency must be between 0 and 20,000 Hz.");
            }

            // Calculate the number of semi-tones from A4
            int semiTonesFromA4 = (int)Math.Round(12 * Math.Log2(frequency / a4_frequency));

            return 69 + semiTonesFromA4;
        }
    }
}
