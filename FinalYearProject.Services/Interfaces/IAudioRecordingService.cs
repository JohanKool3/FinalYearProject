using FinalYearProject.Services.Models;

namespace FinalYearProject.Services.Interfaces
{
    public interface IAudioRecordingService
    {
        /// <summary>
        /// Returns a List of all Output Devices
        /// </summary>
        /// <returns></returns>
        List<AudioDevice> GetOutputDevices();


        /// <summary>
        /// Returns a List of all Input Devices
        /// </summary>
        /// <returns></returns>
        List<AudioDevice> GetInputDevices();


        /// <summary>
        /// Using Input and Ouput Settings, Start the recording
        /// process
        /// </summary>
        void StartRecording(string outputPath);

        void StopRecording();
    }
}
