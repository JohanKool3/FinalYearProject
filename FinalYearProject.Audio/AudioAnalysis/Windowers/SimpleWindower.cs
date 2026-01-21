using FinalYearProject.Audio.Interfaces;
using FinalYearProject.Audio.Models;

namespace FinalYearProject.Audio.AudioAnalysis.Windowers
{
    public class SimpleWindower : IWindower
    {
        /// <summary>
        /// Converts Whole PCM Stream into windows for later analysis
        /// </summary>
        /// <param name="pcmStream">Pulse Code Modulation samples</param>
        /// <param name="sampleRate">The base sample rate of the audio stream</param>
        /// <param name="windowSize">The size of the Window (in samples)</param>
        /// <param name="hop">How many samples to move across when creating windows (usually half the window size)</param>
        /// <returns></returns>
        public List<Window> ConvertPCMStreamToWindows(List<float> pcmStream, int sampleRate, int windowSize, int hop)
        {
            List<Window> output = [];

            double startTime = 0;

            double windowDuration = windowSize / (double)sampleRate;

            for (int startIndex = 0; startIndex + windowSize < pcmStream.Count; startIndex += hop)
            {
                List<float> windowSamples = [.. pcmStream.GetRange(startIndex, windowSize)];
                double time = startTime + windowDuration;

                output.Add(new Window
                {
                    Samples = windowSamples,
                    StartTime = startTime,
                    EndTime = time,
                    AudioLength = time - startTime
                });

                startTime = time;
            }

            return output;
        }
    }
}
