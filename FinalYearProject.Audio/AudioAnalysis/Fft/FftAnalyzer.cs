using FinalYearProject.Audio.Models;
using NAudio.Dsp;

namespace FinalYearProject.Audio.AudioAnalysis.Fft
{
    public class FftAnalyzer
    {
        /// <summary>
        /// Converts a Window of audio samples to the frequency domain using FFT.
        /// </summary>
        /// <param name="window"></param>
        /// <param name="samplingRate">The sample rate of the Audio File</param>
        public FftOutput ConvertToFrequencyDomain(Window window, int samplingRate)
        {
            // FFT Size is the number of samples in the window
            var fftSize = window.Samples.Count;

            // What power of 2 is the fft size
            int fftExponent = (int)Math.Log2(fftSize);

            Complex[] fftBuffer = new Complex[fftSize];

            // Get Samples from the Window Input
            var samples = window.Samples;


            // Convert float[] into Complex[] for FFT
            for (int i = 0; i < fftSize; i++)
            {
                fftBuffer[i].X = samples[i];
                fftBuffer[i].Y = 0;
            }

            FastFourierTransform.FFT(true, fftExponent, fftBuffer);

            // Get the Binaries for this window
            int binCount = fftSize / 2;
            float[] magnitudes = new float[binCount];

            for (int i = 0; i < binCount; i++)
            {
                float real = fftBuffer[i].X;
                float imag = fftBuffer[i].Y;

                magnitudes[i] = MathF.Sqrt(real * real + imag * imag);
            }

            // Map to Frequencies (related to the Sampling Rate)

            // As the Window is smaller than the full audio, the 
            // frequency resolution is lower.
            // This is the step size between bins.
            var frequencyStep = (float)samplingRate / fftSize;

            List<float> frequencies = [];

            for (var binIndex = 0; binIndex < binCount; binIndex++)
            {
                frequencies.Add(binIndex * frequencyStep);
            }

            // Return Magnitudes and Frequencies
            return new FftOutput
            {
                Frequencies = [.. frequencies],
                Magnitudes = magnitudes
            };
        }
    }
}
