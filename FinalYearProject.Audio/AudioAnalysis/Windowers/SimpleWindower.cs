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

            // Gets the time in seconds for each hop
            double hopTime = hop / (double)sampleRate;

            // Slide across the PCM stream creating windows, of size windowSize,
            // moving across by hop samples each time
            for (int startIndex = 0; startIndex + windowSize < pcmStream.Count; startIndex += hop)
            {
                List<float> windowSamples = [.. pcmStream.GetRange(startIndex, windowSize)];
                double time = startTime + hopTime;

                output.Add(new Window
                {
                    Samples = windowSamples,
                    StartTime = startTime,
                    EndTime = time,
                    AudioLength = windowDuration
                });

                startTime = time;
            }

            // Handle last window if there are remaining samples
            if (startTime < pcmStream.Count / (double)sampleRate)
            {
                int remainingSamples = pcmStream.Count - (pcmStream.Count - (pcmStream.Count % hop));
                List<float> windowSamples = [.. pcmStream.GetRange(pcmStream.Count - remainingSamples, remainingSamples)];

                // Pad the WindowSamples with zeros to make it the correct size
                while (windowSamples.Count < windowSize)
                {
                    windowSamples.Add(0);
                }

                double time = startTime + (remainingSamples / (double)sampleRate);
                output.Add(new Window
                {
                    Samples = windowSamples,
                    StartTime = startTime,
                    EndTime = time,
                    AudioLength = time - startTime
                });
            }

            return output;
        }
    }
}
