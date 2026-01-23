using FinalYearProject.Audio.AudioAnalysis.Fft;
using FinalYearProject.Audio.AudioAnalysis.Readers;
using FinalYearProject.Audio.AudioAnalysis.TimelineConstructors;
using FinalYearProject.Audio.AudioAnalysis.Windowers;
using FinalYearProject.Audio.Models;

namespace FinalYearProject.Audio.Tests.IntegrationTests
{
    public class SimpleTimelineConstructorTests
    {
        [Fact]
        public void SimpleTImelineConstructor_C4SineWave_ReturnsValid()
        {
            // Arrange
            var reader = new WavFileReader();
            var fileName = "TestData\\pure-sine-c4.wav";
            var windower = new SimpleWindower();
            var fftAnalyzer = new FftAnalyzer();
            var timelineConstructor = new SimpleTimelineConstructor();

            // Act

            // Read
            var pcmStream = reader.ReadAudioFile(fileName);

            // Chunk
            var windows = windower.ConvertPCMStreamToWindows
                (pcmStream, 44100, 4096, 2048);

            // Convert Chunks to Frequency Domain Snapshots
            List<FftOutput> fftOutputs = [];

            foreach(var window in windows)
            {
                var fftOutput = fftAnalyzer.ConvertToFrequencyDomain(window, 44100);

                fftOutputs.Add(fftOutput);
            }

            // Construct Timeline from Frequency Domain Snapshots
            var timeline = timelineConstructor.GenerateTimeline(fftOutputs);

            var frequencyTotals = new Dictionary<double, double>();

            foreach(var frequency in timeline.FrequencyMagnitude.Keys)
            {

                frequencyTotals[frequency] = timeline.FrequencyMagnitude[frequency].Sum();
            }

            // Assert
            Assert.NotNull(timeline);

            var frequencyBin = frequencyTotals
                .Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

            Assert.True(frequencyBin > 515 && frequencyBin < 535,
                    $"Expected frequency bin to be around 520Hz, but got {frequencyBin}Hz");
        }
    }
}
