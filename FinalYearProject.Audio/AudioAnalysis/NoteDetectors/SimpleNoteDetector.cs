using FinalYearProject.Audio.Helpers;
using FinalYearProject.Audio.Interfaces;
using FinalYearProject.Audio.Models;

namespace FinalYearProject.Audio.AudioAnalysis.NoteDetectors
{
    public class SimpleNoteDetector(TuningScheme tuningScheme, float noteDetectionThreshold) : INoteDetector
    {
        public TuningScheme TuningScheme { get; } = tuningScheme;

        /// <summary>
        /// How much magnitude a frequency must have to be detected
        /// </summary>
        public float NoteDetectionThreshold { get; set; } = noteDetectionThreshold;

        /// <summary>
        /// Finds the greatest frequency magnitude and returns
        /// the note associated with it
        /// </summary>
        /// <param name="frequencyMagnitudeSnapshot"></param>
        /// <param name="frequencies"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        public NoteSlice CalculateNoteConfidenceValues(float[] frequencyMagnitudeSnapshot,
            List<float> frequencies,
            double startTime)
        {
            // - Find the index of the greatest magnitude.
            // - Naively this will be the fundamental frequency.
            // - This will need to be updated in future as this won't
            //   neccessarily be true for Guitar Notes
            var maxIndex = frequencyMagnitudeSnapshot
                .ToList()
                .IndexOf(frequencyMagnitudeSnapshot.Max());

            float? maxFrequency = frequencies[maxIndex];

            if(frequencyMagnitudeSnapshot[maxIndex] < NoteDetectionThreshold)
            {
                maxFrequency = null;
            }

            // Clamp Frequencies to max midi note (127)
            frequencies = ClampFrequencies(frequencies);

            var noteSlice = CalculateNoteSlice(maxFrequency, frequencies, startTime);

            return noteSlice;

        }


        #region Private Methods

        private static List<float> ClampFrequencies(List<float> frequencies)
        {
            List<float> clampedFrequencies = [];

            foreach (var frequency in frequencies)
            {
                // Skip this frequency, it is out of bounds
                if (frequency < MidiFrequencyBounds.MinFrequency || frequency > MidiFrequencyBounds.MaxFrequency)
                {
                    continue;
                }
                clampedFrequencies.Add(frequency);
            }

            return clampedFrequencies;
        }


        /// <summary>
        /// Using the max frequency, calculate the note and then
        /// set the confidence to 1.0f.
        /// </summary>
        /// <param name="maxFrequency"></param>
        /// <returns></returns>
        /// <remarks>The remaining notes will be set to 0.0f</remarks>
        private NoteSlice CalculateNoteSlice(float? maxFrequency,
            List<float> frequencies,
            double startTime)
        {
            // Create blank note slice, set confidences to empty
            var noteSlice = new NoteSlice(startTime, TuningScheme);


            foreach(var note in noteSlice.NoteConfidences)
            {
                var lower = note.FundamentalFrequencyBounds.Item1;
                var upper = note.FundamentalFrequencyBounds.Item2;

                if(maxFrequency is null)
                {
                    note.Confidence = 0.0f;
                    continue;
                }

                if (maxFrequency >= lower && maxFrequency <= upper)
                {
                    note.Confidence = 1.0f;
                }
                else
                {
                    note.Confidence = 0.0f;
                }
            }

            return noteSlice;
        }

        #endregion

        // <inheritdoc />
        public List<NoteSlice> BatchCalculateNoteConfidenceValues(List<float[]> frequencyMagnitudeSnapshots, List<float> frequencies, double startTime, double dataPointLength)
        {
            double currentTime = startTime;

            List<NoteSlice> noteSlices = [];

            foreach(var snapshot in frequencyMagnitudeSnapshots)
            {
                var noteSlice = CalculateNoteConfidenceValues(snapshot, frequencies, currentTime);
                noteSlices.Add(noteSlice);
                currentTime += dataPointLength;
            }

            return noteSlices;
        }
    }
}
