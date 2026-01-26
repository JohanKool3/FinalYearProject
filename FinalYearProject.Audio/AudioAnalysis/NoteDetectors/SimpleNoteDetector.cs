using FinalYearProject.Audio.Helpers;
using FinalYearProject.Audio.Interfaces;
using FinalYearProject.Audio.Models;

namespace FinalYearProject.Audio.AudioAnalysis.NoteDetectors
{
    public class SimpleNoteDetector(TuningScheme tuningScheme) : INoteDetector
    {
        public TuningScheme TuningScheme { get; } = tuningScheme;

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

            var maxFrequency = frequencies[maxIndex];

            // Clamp Frequencies to max midi note (127)
            frequencies = ClampFrequencies(frequencies);

            var noteSlice = CalculateNoteSlice(maxFrequency, frequencies, startTime);

            return noteSlice;

        }

        private static List<float> ClampFrequencies(List<float> frequencies)
        {
            List<float> clampedFrequencies = [];

            foreach(var frequency in frequencies)
            {
                // Skip this frequency, it is out of bounds
                if(frequency < MidiFrequencyBounds.MinFrequency || frequency > MidiFrequencyBounds.MaxFrequency)
                {
                    continue;
                }
                clampedFrequencies.Add(frequency);
            }

            return clampedFrequencies;
        }

        #region Private Methods

        /// <summary>
        /// Using the max frequency, calculate the note and then
        /// set the confidence to 1.0f.
        /// </summary>
        /// <param name="maxFrequency"></param>
        /// <returns></returns>
        /// <remarks>The remaining notes will be set to 0.0f</remarks>
        private NoteSlice CalculateNoteSlice(float maxFrequency,
            List<float> frequencies,
            double startTime)
        {
            // Create blank note slice, set confidences to empty
            var noteSlice = new NoteSlice
            {
                Time = (float)startTime,
                NoteConfidences = []
            };

            // Iterate over each frequency bin 
            foreach (var frequency in frequencies)
            {
                // Frequency is the max frequency
                // Set confidence to max (as this is our fundamental)
                // and naively, we assume that the max frequency is the 
                // note being played
                if (frequency == maxFrequency)
                {
                    var semiTones = FrequencyToNoteHelper
                        .GetFrequencySemiTones(frequency, TuningScheme.A4);

                    var noteName = SemitonesToNoteHelper
                        .ConvertToNoteName(semiTones);

                    noteSlice.NoteConfidences.Add(new NoteConfidence
                    {
                        Name = noteName,
                        // TODO : Improve bounds calculation
                        FundamentalFrequencyBounds = Tuple.Create(frequency - 1.0f,
                            frequency + 1.0f),
                        Confidence = 1.0f
                    });
                }

                else
                {
                    var semiTones = FrequencyToNoteHelper
                        .GetFrequencySemiTones(frequency, TuningScheme.A4);
                    
                    var noteName = SemitonesToNoteHelper
                        .ConvertToNoteName(semiTones);
                    
                    noteSlice.NoteConfidences.Add(new NoteConfidence
                    {
                        Name = noteName,
                        // TODO : Improve bounds calculation
                        FundamentalFrequencyBounds = Tuple.Create(frequency - 1.0f,
                            frequency + 1.0f),
                        Confidence = 0.0f
                    });
                }
            }

            return noteSlice;
        }

        #endregion
    }
}
