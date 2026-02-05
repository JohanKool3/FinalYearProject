using Microsoft.Maui.ApplicationModel;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalYearProject.UI.Components.Helpers
{
    internal static class WaveFileHelper
    {
        /// <summary>
        /// Takes a File Path and reads an array of floats representing sampled
        /// peaks at an even distribution.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="points"></param>
        /// <returns></returns>
        internal static float[] ReadWavFile(string filePath, int points)
        {
            if (!File.Exists(filePath))
            {
                return [];
            }

            using var reader = new AudioFileReader(filePath);

            int samplesPerPoint =
                (int)((reader.Length / 2) / points);

            // Define a Buffer to read samples to
            var buffer = new float[samplesPerPoint];
            var waveform = new float[points];

            for (int i = 0; i < points; i++)
            {
                int read = reader.Read(buffer, 0, samplesPerPoint);
                if (read == 0)
                    break;

                // peak value for this buffer
                float max = GetPeak(buffer);

                max = Normalize(max, 0.7f);

                waveform[i] = max;
            }

            return waveform;

        }

        private static float Normalize(float max, float exponent)
            => MathF.Pow(max, exponent);

        /// <summary>
        /// Finds the Local Maximum within a buffer
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        private static float GetPeak(float[] buffer)
        {
            var maxAmplitude = 0f;

            foreach(var sample in buffer)
            {
                var abs = Math.Abs(sample);
                
                if (abs > maxAmplitude)
                {
                    maxAmplitude = abs;
                }
            }

            return maxAmplitude;
        }
    }
}
