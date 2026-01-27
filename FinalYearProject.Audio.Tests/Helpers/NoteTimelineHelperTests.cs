using FinalYearProject.Audio.Helpers;
using FinalYearProject.Audio.Models;

namespace FinalYearProject.Audio.Tests.Helpers
{
    public class NoteTimelineHelperTests
    {

        [Fact]
        public void NoteTimelineHelper_GetNotesAtTime_ValidInput_ReturnsExpectedNotes()
        {
            // Arrange
            var tuningScheme = new TuningScheme
            {
                A4 = 440.0
            };

            var timeline = new NoteTimeline
            {
                Length = 10.0f,
                DataPointLength = 1.0,
                NoteSlices =
                [
                    new(0, tuningScheme)
                    {
                        NoteConfidences =
                        [
                            new() { Name = "D4", Confidence = 0.9f, FundamentalFrequencyBounds = new(0, 0) },
                            new() { Name = "E4", Confidence = 0.8f, FundamentalFrequencyBounds = new(0, 0) }
                        ]
                    }
                ]
            };

            double time = 0;
            float noteConfidenceMinimum = 0.8f;

            // Act
            var result = NoteTimelineHelper
                .GetNotesAtTime(timeline, time, noteConfidenceMinimum);
            
            // Assert
            Assert.Contains("D4", result);
            Assert.Contains("E4", result);
            Assert.DoesNotContain("F4", result);
        }

        [Fact]
        public void NoteTimelineHelper_GetNotesAtTime_TimeOutOfBounds_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var tuningScheme = new TuningScheme
            {
                A4 = 440.0
            };
            var timeline = new NoteTimeline
            {
                Length = 5.0f,
                DataPointLength = 1.0,
                NoteSlices = []
            };
            double time = 10.0; // Out of bounds
            float noteConfidenceMinimum = 0.5f;
            
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                NoteTimelineHelper.GetNotesAtTime(timeline, time, noteConfidenceMinimum));
        }
    }
}
