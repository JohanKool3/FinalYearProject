using FinalYearProject.Audio.AudioAnalysis.NoteDetectors;
using FinalYearProject.Audio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.Audio.Tests.NoteDetectors
{
    public class SimpleNoteDetectorTests
    {

        [Theory]
        [InlineData("F#4", 0)]
        [InlineData("G4", 1)]
        [InlineData("G#4", 2)]
        [InlineData("A4", 3)]
        [InlineData("A#4", 4)]
        [InlineData("B4", 5)]
        [InlineData("C5", 6)]
        [InlineData("C#5", 7)]
        public void CalculateNoteSlice_ShouldReturnCorrectNote(string expected, int maxFrequency)
        {
            // Arrange
            var tuningScheme = new TuningScheme
            {
                A4 = 440.0f
            };

            var noteDetector = new SimpleNoteDetector(tuningScheme, 0);

            // Imitate a frequency magnitude snapshot where only one frequency
            // has a significant magnitude
            float[] frequencies = [370.2f,  // F#4-ish
                                    392.0f,  // G4
                                    415.3f,  // G#4
                                    440.1f,  // A4
                                    466.4f,  // A#4
                                    493.9f,  // B4
                                    523.4f,  // C5
                                    554.1f];// C#5

            float[] magnitudeSnapshot = new float[frequencies.Length];
            magnitudeSnapshot[maxFrequency] = 1.0f;

            // Act
            var noteSlice = noteDetector.CalculateNoteConfidenceValues(
                frequencyMagnitudeSnapshot: magnitudeSnapshot,
                frequencies: [.. frequencies],
                startTime: 0.0);

            var mostConfidentNote = noteSlice
                .NoteConfidences
                .OrderByDescending(nc => nc.Confidence)
                .First();

            // Assert
            Assert.Equal(expected, mostConfidentNote.Name);
        }

    }
}
