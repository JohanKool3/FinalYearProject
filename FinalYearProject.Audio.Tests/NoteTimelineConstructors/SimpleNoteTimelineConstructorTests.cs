using FinalYearProject.Audio.AudioAnalysis.NoteTimelineConstructors;
using FinalYearProject.Audio.Models;

namespace FinalYearProject.Audio.Tests.NoteTimelineConstructors
{
    public class SimpleNoteTimelineConstructorTests
    {

        [Fact]
        public void SimpleNoteTimelineConstructur_GenerateTimeline_ValidInput_ReturnsNoteTimeline()
        {
            // Arrange
            var tuningScheme = new TuningScheme()
            {
                A4 = 440.0
            };
            var constructor = new SimpleNoteTimelineConstructor(tuningScheme);
            var frequencyTimeline = new FrequencyMagnitudeTimeline()
            {
                Frequencies = [261.63f, 293.66f, 329.63f], // C4, D4, E4
                FrequencyMagnitude = new Dictionary<float, List<float>>()
                {
                    { 261.63f, new List<float> { 0.1f, 0.3f } },
                    { 293.66f, new List<float> { 0.5f, 0.2f } },
                    { 329.63f, new List<float> { 0.2f, 0.6f } }
                },
                FrequencyMagnitudeWindows =
                [
                    [0.1f, 0.5f, 0.2f], // Window 1
                    [0.3f, 0.2f, 0.6f]  // Window 2
                ],
                DataPointLength = 0.1,
                Length = 0.2f
            };


            // Act
            var noteTimeline = constructor.GenerateTimeline(frequencyTimeline, 0.0f);

            // Assert
            Assert.NotNull(noteTimeline);
            Assert.Equal(2, noteTimeline.NoteSlices.Count);

            // First slice should detect D4
            var firstSlice = noteTimeline.NoteSlices[0];
            Assert.Equal(0.0, firstSlice.Time);

            // Second slice should detect E4
            var secondSlice = noteTimeline.NoteSlices[1];
            Assert.Equal(0.1, secondSlice.Time);
        }


        [Fact]
        public void SimpleNoteTimelineConstructor_GenerateTimeline_EmptyInput_ReturnsEmptyNoteTimeline()
        {
            // Arrange
            var tuningScheme = new TuningScheme()
            {
                A4 = 440.0
            };
            var constructor = new SimpleNoteTimelineConstructor(tuningScheme);
            var frequencyTimeline = new FrequencyMagnitudeTimeline()
            {
                Frequencies = [],
                FrequencyMagnitude = [],
                FrequencyMagnitudeWindows = [],
                DataPointLength = 0.1,
                Length = 0.0f
            };

            // Act
            var noteTimeline = constructor.GenerateTimeline(frequencyTimeline, 0.0f);

            // Assert
            Assert.NotNull(noteTimeline);
            Assert.Empty(noteTimeline.NoteSlices);
        }

        [Fact]
        public void SimpleNoteTimelineConstructor_GenerateTimeline_NullFrequencies_ThrowsException()
        {
            // Arrange
            var tuningScheme = new TuningScheme()
            {
                A4 = 440.0
            };
            var constructor = new SimpleNoteTimelineConstructor(tuningScheme);
            var frequencyTimeline = new FrequencyMagnitudeTimeline()
            {
                Frequencies = null!,
                FrequencyMagnitude = new Dictionary<float, List<float>>()
                {
                    { 261.63f, new List<float> { 0.1f, 0.3f } }
                },
                FrequencyMagnitudeWindows =
                [
                    [0.1f] // Window 1
                ],
                DataPointLength = 0.1,
                Length = 0.1f
            };
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                constructor.GenerateTimeline(frequencyTimeline, 0.0f));
        }
    }
}
