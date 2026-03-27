using FinalYearProject.Services.Models;

namespace FinalYearProject.Services.Interfaces
{
    /// <summary>
    /// Represents the Service that is responsible for Audio Input and Output
    /// </summary>
    public interface IAudioService
    {
        /// <summary>
        /// Get a List of all the Available Output Devices
        /// </summary>
        /// <returns></returns>
        List<AudioDevice> GetOutputDevices();

        /// <summary>
        /// Get a List of all the Available Input Devices
        /// </summary>
        /// <returns></returns>
        List<AudioDevice> GetInputDevices();

        /// <summary>
        /// Starts the Playback with the registered sample providers
        /// </summary>
        void StartPlayback();

        /// <summary>
        /// Starts the Recording of the User Input channel
        /// </summary>
        void StartRecording();

        /// <summary>
        /// Ends audio Playback
        /// </summary>
        void StopPlayback();

        void RestartPlayback();
    }
}
