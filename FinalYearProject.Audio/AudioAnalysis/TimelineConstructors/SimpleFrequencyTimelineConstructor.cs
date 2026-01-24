using FinalYearProject.Audio.Interfaces;
using FinalYearProject.Audio.Models;

namespace FinalYearProject.Audio.AudioAnalysis.TimelineConstructors
{
    public class SimpleFrequencyTimelineConstructor : IFrequencyTimelineConstructor
    {
        public FrequencyMagnitudeTimeline GenerateTimeline(List<FftOutput> fftResults)
        {
            // Get the frequencies from the first window (this should not change)
            var firstWindow = fftResults.FirstOrDefault() 
                ?? throw new ArgumentException("Windows list cannot be empty");

            // Validate frequencies
            var frequencies = firstWindow.Frequencies;
            if(frequencies.Length == 0)
            {
                throw new ArgumentException("Frequencies array cannot be empty");
            }

            float? firstFrequency = frequencies.FirstOrDefault();

            if(firstFrequency is null)
            {
                throw new ArgumentException("Frequencies array contains no valid frequencies");
            }

            // Assume uniform window length

            // End time - start time as there will be window overlap.
            var firstDatapointLength 
                = fftResults[0].EndTime - fftResults[0].StartTime;

            // Initialize the timeline structure
            var timeline = new FrequencyMagnitudeTimeline
            {
                FrequencyMagnitude = [],
                Frequencies = [.. frequencies],
                FrequencyMagnitudes = [.. fftResults.Select(w => w.Magnitudes)],
                Length = (float)fftResults.Max(w => w.EndTime),
                DataPointLength = firstDatapointLength,
            };


            // Fill out the timeline based on the frequency magnitudes
            for(int index = 0; index < frequencies.Length; index++)
            {
                // Get the Frequency that is being processed
                float frequency = frequencies[index];

                // Initialize the list for this frequency
                timeline.FrequencyMagnitude[frequency] = [];

                foreach(var window in fftResults)
                {
                    // Ensure the current window has the same frequency structure
                    if(window.Frequencies.Length != frequencies.Length)
                    {
                        throw new ArgumentException("Inconsistent frequency data across windows");
                    }
                    
                    float magnitude = window.Magnitudes[index];
                    timeline.FrequencyMagnitude[frequency].Add(magnitude);
                }
            }

            return timeline;
        }
    }
}
