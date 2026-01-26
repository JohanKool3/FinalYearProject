using FinalYearProject.Audio.AudioAnalysis.NoteDetectors;
using FinalYearProject.Audio.Interfaces;
using FinalYearProject.Audio.Models;

namespace FinalYearProject.Audio.AudioAnalysis.NoteTimelineConstructors
{
    public class SimpleNoteTimelineConstructor(TuningScheme tuningScheme) : INoteTimelineConstuctor
    {
        public TuningScheme TuningScheme { get; } = tuningScheme;

        public NoteTimeline GenerateTimeline(FrequencyMagnitudeTimeline frequencyTimeline) 
            => GenerateTimeline(frequencyTimeline, 0.0f);

        public NoteTimeline GenerateTimeline(FrequencyMagnitudeTimeline frequencyTimeline, float noteDetectionThreshold)
        {
            // Component used to detect notes within a frequency window
            var noteDetector = new SimpleNoteDetector(TuningScheme, noteDetectionThreshold);
            var frequencies = frequencyTimeline.Frequencies;

            var noteSlices = new List<NoteSlice>();

            var windows = frequencyTimeline.FrequencyMagnitudeWindows.Count;

            // Iterate over each window, calculate the notes present
            for (int index = 0; index < windows; index++)
            {
                var window = frequencyTimeline.FrequencyMagnitudeWindows[index];
                var startTime = index * frequencyTimeline.DataPointLength;

                var noteSlice = noteDetector
                    .CalculateNoteConfidenceValues(
                        window,
                        frequencies,
                        startTime);

                noteSlices.Add(noteSlice);
            }

            return new NoteTimeline()
                {
                    NoteSlices = noteSlices,
                    DataPointLength = frequencyTimeline.DataPointLength,
                    Length = frequencyTimeline.Length
                };
        }
    }
}
