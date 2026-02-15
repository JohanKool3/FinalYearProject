using FinalYearProject.Services.Interfaces;
using FinalYearProject.Services.Models;

namespace FinalYearProject.Services.Audio
{
    /// <summary>
    /// Audio Engine Service for Windows Devices
    /// </summary>
    public class WindowsAudioService : IAudioService
    {
        public List<AudioDevice> GetInputDevices()
        {
            throw new NotImplementedException();
        }

        public List<AudioDevice> GetOutputDevices()
        {
            throw new NotImplementedException();
        }

        public void StartPlayback()
        {
            throw new NotImplementedException();
        }

        public void StopPlayback()
        {
            throw new NotImplementedException();
        }
    }
}
