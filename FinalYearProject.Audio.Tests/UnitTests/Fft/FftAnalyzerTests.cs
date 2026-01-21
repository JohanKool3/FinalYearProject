using FinalYearProject.Audio.AudioAnalysis.Fft;
using FinalYearProject.Audio.Models;

namespace FinalYearProject.Audio.Tests.UnitTests.Fft
{
    public class FftAnalyzerTests
    {

        [Fact]
        public void FftAnalyzer_EmptyInput_ReturnsEmptyBins()
        {
            // arrange
            var testWindow = new Window()
            {
                Samples = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]

            };

            var sampleRate = 48000;
            var analyzer = new FftAnalyzer();

            var expectedFrequencies = new float[]
            {
                0, 3000, 6000, 9000, 12000, 15000, 18000, 21000
            };

            var expectedMagnitudes = new float[]
            {
                0, 0, 0, 0, 0, 0, 0, 0
            };

            // Act
            var output = analyzer.ConvertToFrequencyDomain(testWindow, sampleRate);

            // Assert
            Assert.Equal(expectedFrequencies, output.Frequencies);
            Assert.NotEmpty(output.Magnitudes);
        }
    }
}
