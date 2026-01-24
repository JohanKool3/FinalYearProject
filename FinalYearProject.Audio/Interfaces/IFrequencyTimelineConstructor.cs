using FinalYearProject.Audio.Models;

namespace FinalYearProject.Audio.Interfaces
{
    /// <summary>
    /// Purpose of this component is to construct a frequency timeline over time.
    /// Starting from 0 seconds to the end of the audio clip.
    /// </summary>
    /// <remarks>
    /// This will give all the information needed to analyse the audio clip.
    /// E.g. Frequency and its magnitude at a given time.
    /// </remarks>
    public interface IFrequencyTimelineConstructor
    {
        /// <summary>
        /// Takes fft results in and generates a Frequency Magnitude Timeline from 0s to length of the clip
        /// </summary>
        /// <param name="windows"></param>
        /// <returns></returns>
        public FrequencyMagnitudeTimeline GenerateTimeline(List<FftOutput> fftResults);
    }
}