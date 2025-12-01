using FinalYearProject.Audio.Pipeline.AudioSources;
using FinalYearProject.Shared.Models.AudioRepresentation;

namespace FinalYearProject.Audio.Helpers
{
    /// <summary>
    /// Helper used to load waveform data
    /// </summary>
    public static class WaveformLoader
    {
        /// <summary>
        /// Loads a Simplified Waveform from a given file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="resolution"></param>
        /// <returns></returns>
        public static List<WaveformPoint> LoadFileWaveform(string path, int resolution = 400)
        {
            // Determine if the path is valid

            var audioSource = new FileAudioSource(path);
            var reader = audioSource.Reader;
            var provider = audioSource.SampleProvider;

            // Not Valid Audio Source, cannot get waveform
            if (audioSource is null || reader is null || provider is null)
            {
                return [];
            }

            // Always 8 bits per sample, length will be divided by 8 to
            // get number of samples
            long totalSamples = (long)(reader.Length / (reader.WaveFormat.BitsPerSample / 8));
            long samplesPerPoint = totalSamples / resolution;
            int channels = reader.WaveFormat.Channels;
            int floatPerFrame = channels;

            float[] buffer = new float[2048];
            long samplesRead = 0;

            var points = new List<WaveformPoint>();

            while (samplesRead < totalSamples)
            {
                long target = samplesPerPoint;
                float max = 0f;

                while (target > 0)
                {
                    // align chunk to complete sample frames
                    int maxChunk = (int)Math.Min(buffer.Length, target);

                    // ensure it's a multiple of channels
                    int chunk = (maxChunk / floatPerFrame) * floatPerFrame;


                    int read = provider.Read(buffer, 0, chunk);

                    if (read == 0)
                    {
                        break;
                    }

                    for (int i = 0; i < read; i++)
                    {
                        max = Math.Max(max, Math.Abs(buffer[i]));
                    }

                    samplesRead += read;
                    target -= read;
                }

                // Add the Compressed waveform Point
                points.Add(new()
                {
                    MaxPositive = max,
                    MaxNegative = -max,
                });
            }

            return points;
        }
    }
}
