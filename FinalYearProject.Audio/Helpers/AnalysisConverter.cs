using FftSharp;
using FinalYearProject.Shared.Models.AudioRepresentation;

namespace FinalYearProject.Audio.Helpers
{
    public static class AnalysisConverter
    {

        public static FftResult ConvertToFrequencyDomain(
            float[] samples, 
            int samplesLength,
            int fftSize,
            int sampleRate)
        {

            // Handle Invalid Cases
            if(sampleRate <= 0)
            {
                throw new ArgumentException("Sample rate must be greater than zero.", nameof(sampleRate));
            }

            if (Math.Log2(fftSize) % 1 != 0)
            {
                throw new ArgumentException("Fft Size must be a power of two.", nameof(sampleRate));
            }

            // Convert all samples to double
            double[] chunk = [.. samples
                .Take(samplesLength)
                .Select(x => (double)x)];

            // Zero Pad if needed (when loaded samples is less than FFT size)
            if (chunk.Length < fftSize)
            {
                Array.Resize(ref chunk, fftSize);
            }

            var window = new FftSharp.Windows.Hanning();

            // Apply Windowing to reduce Spectral Leakage
            double[] windowed = window.Apply(chunk);

            // Returns the Complex Numbers after FFT
            var fft = FFT.Forward(windowed);


            // Return the Magnitudes and Frequencies of each bin
            return new FftResult()
            {
                Magnitudes = FFT.Magnitude(fft),
                Frequencies = FFT.FrequencyScale(fftSize, sampleRate)
            };
        }
    }
}
