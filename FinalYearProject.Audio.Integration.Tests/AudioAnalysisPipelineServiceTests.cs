using FinalYearProject.Audio.AudioAnalysis.FrequencyTimelineConstructors;
using FinalYearProject.Audio.AudioAnalysis.NoteTimelineConstructors;
using FinalYearProject.Audio.AudioAnalysis.Readers;
using FinalYearProject.Audio.AudioAnalysis.Windowers;
using FinalYearProject.Audio.Models;
using FinalYearProject.Audio.Services;

namespace FinalYearProject.Audio.Integration.Tests
{
    public class AudioAnalysisPipelineServiceTests
    {
        [Fact]
        public void AudioAnalysisPipelineService_ValidPath_ReturnsExpectedResult()
        {
            // Arrange

            var tuningScheme = new TuningScheme()
            {
                A4 = 440.0
            };

            var settings = new DetectionSettings()
            {
                NoteDetectionThreshold = 0f,
                HopSize = 2048,
                WindowSize = 4096
            };


            var reader = new WavFileReader();
            var windower = new SimpleWindower();
            var frequencyConstructor = new SimpleFrequencyTimelineConstructor();
            var noteConstructor = new SimpleNoteTimelineConstructor(tuningScheme);


            var pipeline = new AudioAnalysisPipelineService
                (reader,
                windower,
                frequencyConstructor,
                noteConstructor,
                tuningScheme,
                settings);

            // Act
            var result = pipeline.AnalyzeAudioFile("TestData\\pure-sine-c4.wav");

            // Assert
            Assert.NotNull(result);
            Assert.Contains("C5",
                result.NoteSlices
                .SelectMany(ns => ns.NoteConfidences)
                .Where(ns => ns.Confidence > settings.NoteDetectionThreshold)
                .Select(n => n.Name));

        }
    }
}
