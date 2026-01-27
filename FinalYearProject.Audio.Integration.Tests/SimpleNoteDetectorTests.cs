using FinalYearProject.Audio.AudioAnalysis.Fft;
using FinalYearProject.Audio.AudioAnalysis.FrequencyTimelineConstructors;
using FinalYearProject.Audio.AudioAnalysis.NoteDetectors;
using FinalYearProject.Audio.AudioAnalysis.Readers;
using FinalYearProject.Audio.AudioAnalysis.Windowers;
using FinalYearProject.Audio.Models;

namespace FinalYearProject.Audio.Integration.Tests
{
    public class SimpleNoteDetectorTests
    {

        [Fact]
        public void SimpleNoteDetectorTests_SingleC4SineWaveWindow_ReturnsC4NoteDetection()
        {
            // Arrange
            var tuningScheme = new TuningScheme()
            {
                A4 = 440.0
            };

            var reader = new WavFileReader();
            var fileName = "TestData\\pure-sine-c4.wav";
            var windower = new SimpleWindower();
            var fftAnalyzer = new FftAnalyzer();
            var timelineConstructor = new SimpleFrequencyTimelineConstructor();
            var noteDetector = new SimpleNoteDetector(tuningScheme, 0);

            // Act

            // Read
            var pcmStream = reader.ReadAudioFile(fileName);

            // Chunk
            var windows = windower.ConvertPCMStreamToWindows
                (pcmStream, 44100, 4096, 2048);

            // Convert Chunks to Frequency Domain Snapshots
            List<FftOutput> fftOutputs = [];

            foreach (var window in windows)
            {
                var fftOutput = fftAnalyzer.ConvertToFrequencyDomain(window, 44100);

                fftOutputs.Add(fftOutput);
            }

            // Construct Timeline from Frequency Domain Snapshots
            var timeline = timelineConstructor.GenerateTimeline(fftOutputs);

            var frequencyTotals = new Dictionary<double, double>();

            foreach (var frequency in timeline.FrequencyMagnitude.Keys)
            {

                frequencyTotals[frequency] = timeline.FrequencyMagnitude[frequency].Sum();
            }

            // Take first Snapshot from the Timeline
            var frequencies = timeline.Frequencies;
            var firstWindow = timeline.FrequencyMagnitudeWindows[0];

            var noteSlice = noteDetector.CalculateNoteConfidenceValues
                (firstWindow, frequencies, 0.0);

            // Assert
            Assert.Equal("C5", noteSlice.NoteConfidences
                .OrderByDescending(nc => nc.Confidence)
                .First()
                .Name);

        }

        [Fact]
        public void SimpleNoteDetectorTests_MultipleC4SineWaveWindow_ReturnsC4NoteDetection()
        {
            // Arrange
            var tuningScheme = new TuningScheme()
            {
                A4 = 440.0
            };

            var reader = new WavFileReader();
            var fileName = "TestData\\pure-sine-c4.wav";
            var windower = new SimpleWindower();
            var fftAnalyzer = new FftAnalyzer();
            var timelineConstructor = new SimpleFrequencyTimelineConstructor();
            var noteDetector = new SimpleNoteDetector(tuningScheme, 0);

            // Act

            // Read
            var pcmStream = reader.ReadAudioFile(fileName);

            // Chunk
            var windows = windower.ConvertPCMStreamToWindows
                (pcmStream, 44100, 4096, 2048);

            // Convert Chunks to Frequency Domain Snapshots
            List<FftOutput> fftOutputs = [];

            foreach (var window in windows)
            {
                var fftOutput = fftAnalyzer.ConvertToFrequencyDomain(window, 44100);

                fftOutputs.Add(fftOutput);
            }

            // Construct Timeline from Frequency Domain Snapshots
            var timeline = timelineConstructor.GenerateTimeline(fftOutputs);

            var frequencyTotals = new Dictionary<double, double>();

            foreach (var frequency in timeline.FrequencyMagnitude.Keys)
            {

                frequencyTotals[frequency] = timeline.FrequencyMagnitude[frequency].Sum();
            }

            // Take first Snapshot from the Timeline
            var frequencies = timeline.Frequencies;


            var allNoteSlices = new List<NoteSlice>();

            foreach (var window in timeline.FrequencyMagnitudeWindows)
            {

                var noteSlice = noteDetector.CalculateNoteConfidenceValues
                    (window, frequencies, 0.0);

                allNoteSlices.Add(noteSlice);
            }

            // Assert
            foreach (var noteSlice in allNoteSlices)
            {
                var detectedNote = noteSlice
                    .NoteConfidences
                    .Where(nc => nc.Confidence > 0)
                    .FirstOrDefault();

                Assert.Equal("C5", detectedNote?
                    .Name);
            }

        }

        [Fact]
        public void SimpleNoteDetectorTests_EMinorScaleGuitar_ReturnsCorrectNoteDetections()
        {
            // Arrange
            var tuningScheme = new TuningScheme()
            {
                A4 = 440.0
            };

            var reader = new WavFileReader();
            var fileName = "TestData\\eminor-test.wav";
            var windower = new SimpleWindower();
            var fftAnalyzer = new FftAnalyzer();
            var timelineConstructor = new SimpleFrequencyTimelineConstructor();
            var noteDetector = new SimpleNoteDetector(tuningScheme, 0.06185f);

            // Act

            // Read
            var pcmStream = reader.ReadAudioFile(fileName);

            // Chunk
            var windows = windower.ConvertPCMStreamToWindows
                (pcmStream, 48000, 4096, 2048);

            // Convert Chunks to Frequency Domain Snapshots
            List<FftOutput> fftOutputs = [];

            foreach (var window in windows)
            {
                var fftOutput = fftAnalyzer.ConvertToFrequencyDomain(window, 48000);

                fftOutputs.Add(fftOutput);
            }

            // Construct Timeline from Frequency Domain Snapshots
            var timeline = timelineConstructor.GenerateTimeline(fftOutputs);

            // Take first Snapshot from the Timeline
            var frequencies = timeline.Frequencies;


            var allNoteSlices = new List<NoteSlice>();

            foreach (var window in timeline.FrequencyMagnitudeWindows)
            {

                var noteSlice = noteDetector.CalculateNoteConfidenceValues
                    (window, frequencies, 0.0);

                allNoteSlices.Add(noteSlice);
            }

            var distinctNotes = allNoteSlices
                .SelectMany(ns => ns.NoteConfidences
                    .OrderByDescending(nc => nc.Confidence)
                    .Take(1)
                    .Where(nc => nc.Confidence > 0)
                    .Select(nc => nc.Name))
                .Distinct()
                .ToList();

            Assert.Equal(7, distinctNotes.Count);
        }
    }
}
