using FinalYearProject.Audio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.Audio.Interfaces
{
    /// <summary>
    /// Converts a raw input of Audio PCM Samples and returns an array of 
    /// windows
    /// </summary>
    public interface IWindower
    {
        /// <summary>
        /// Converts a sequence of PCM audio samples into a list of windowed segments for further processing.
        /// </summary>
        /// <param name="pcmStream">The list of PCM audio samples to be divided into windows. Each value represents a single audio sample.
        /// <param name="sampleRate">How many samples were recorded per second.
        /// <param name="windowSize">How large the Window is (in samples).
        /// <param name="hop">How many samples to move over when changing window (in samples).
        /// Cannot be null.</param>
        /// <returns>A list of windows, where each window contains a segment of the input PCM stream. The list will be empty if
        /// the input contains no samples.</returns>
        public List<Window> ConvertPCMStreamToWindows(List<float> pcmStream, int sampleRate, int windowSize, int hop);
    }
}
