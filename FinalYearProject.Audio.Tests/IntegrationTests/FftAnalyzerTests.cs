using FinalYearProject.Audio.AudioAnalysis.Fft;
using FinalYearProject.Audio.AudioAnalysis.Readers;
using FinalYearProject.Audio.AudioAnalysis.Windowers;

namespace FinalYearProject.Audio.Tests.IntegrationTests
{
    public class FftAnalyzerTests
    {
        [Fact]
        public void FftAnalyzer_ConvertC4SineWaveSingleWindow_ReturnsValidApproximately520hz()
        {
            // Arrange
            var reader = new WavFileReader();
            var fileName = "TestData\\pure-sine-c4.wav";
            var windower = new SimpleWindower();

            var fftAnalyzer = new FftAnalyzer();

            // Act
            var pcmStream = reader.ReadAudioFile(fileName);

            var windows = windower.ConvertPCMStreamToWindows
                (pcmStream, 44100, 4096, 2048);

            var window = windows[100];

            var fftOutput = fftAnalyzer.ConvertToFrequencyDomain(window, 44100);

            var maxFrequencyBin = fftOutput
                .Frequencies
                .Where((frequency, index)
                    => fftOutput.Magnitudes[index] == fftOutput.Magnitudes.Max()).First();

            Assert.True(maxFrequencyBin > 515 && maxFrequencyBin < 535,
                $"Expected frequency bin to be around 520Hz, but got {maxFrequencyBin}Hz");
        }

        [Fact]
        public void FftAnalyzer_ConvertC4SineWaveMultipleWindows_ReturnsValidApproximately520hz()
        {
            // Arrange
            var reader = new WavFileReader();
            var fileName = "TestData\\pure-sine-c4.wav";
            var windower = new SimpleWindower();
            var fftAnalyzer = new FftAnalyzer();
            
            // Act
            var pcmStream = reader.ReadAudioFile(fileName);
            var windows = windower.ConvertPCMStreamToWindows
                (pcmStream, 44100, 4096, 2048);

            var frequencyBins = new List<double>();

            foreach (var window in windows)
            {
                var fftOutput = fftAnalyzer.ConvertToFrequencyDomain(window, 44100);
                var maxFrequencyBin = fftOutput
                    .Frequencies
                    .Where((frequency, index)
                        => fftOutput.Magnitudes[index] == fftOutput.Magnitudes.Max()).First();
                frequencyBins.Add(maxFrequencyBin);
            }

            // Assert
            foreach (var frequencyBin in frequencyBins)
            {
                Assert.True(frequencyBin > 515 && frequencyBin < 535,
                    $"Expected frequency bin to be around 520Hz, but got {frequencyBin}Hz");
            }
        }
    }
}
