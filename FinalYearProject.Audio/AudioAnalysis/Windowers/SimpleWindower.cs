using FinalYearProject.Audio.Interfaces;
using FinalYearProject.Audio.Models;

namespace FinalYearProject.Audio.AudioAnalysis.Windowers
{
    public class SimpleWindower : IWindower
    {
        /// <summary>
        /// Converts Whole PCM Stream into windows for later analysis
        /// </summary>
        /// <param name="pcmStream"></param>
        /// <param name="sampleRate"></param>
        /// <param name="windowSize"></param>
        /// <param name="hop"></param>
        /// <returns></returns>
        public List<Window> ConvertPCMStreamToWindows(List<float> pcmStream, int sampleRate, int windowSize, int hop)
        {
            List<Window> output = [];

            double startTime = 0;

            double windowDuration = windowSize / (double)sampleRate;

            for (int startIndex = 0; startIndex + windowSize < pcmStream.Count; startIndex += hop)
            {
                List<float> windowSamples = [.. pcmStream.GetRange(startIndex, windowSize)];
                double time = startIndex / windowDuration;

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
