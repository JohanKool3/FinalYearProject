using FinalYearProject.Audio.AudioAnalysis.Windowers;

namespace FinalYearProject.Audio.Tests.UnitTests.Windowers
{
    public class SimpleWindowerTests
    {
        [Theory]
        [InlineData(0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f)] // Silence
        [InlineData(0.000f, 0.309f, 0.588f, 0.809f, 0.951f, 1.000f, 0.951f, 0.809f, 0.588f, 0.309f)] // 20hz Sine Wave
        [InlineData(1f, 1f, 1f, 1f, 1f, -1f, -1f, -1f, -1f, -1f)] // 1 hz Square Wave
        public void SimpleWindower_ConvertPCMStreamToWindows_ValidInput_NotEmpty(params float[] pcmSamples)
        {
            // Assume Sample rate of 10 samples per second
            var sampleRate = 10;

            SimpleWindower windower = new();

            var windows = windower
                .ConvertPCMStreamToWindows(
                    [.. pcmSamples], 
                    sampleRate,
                    2, 
                    1);

            Assert.Equal(9, windows.Count);

        }
    }
}
