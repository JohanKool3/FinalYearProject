using FinalYearProject.Services.Audio.Windows.AudioBuses;
using FinalYearProject.Services.Interfaces;
using FinalYearProject.Services.Models;

namespace FinalYearProject.Services.Audio
{
    /// <summary>
    /// Audio Engine Service for Windows Devices
    /// </summary>
    public class WindowsAudioService: IAudioService
    {
        /// <summary>
        /// The output for this Audio Service.
        /// </summary>
        private MainBus _bus;

        public WindowsAudioService(
            MainBus mainBus, 
            BackingTrackBus backingTrackBus,
            MetronomeBus metronomeBus,
            UserBus userBus)
        {
            // Register the main Bus 
            _bus = mainBus;

            // Add Inputs into Main Bus
            _bus.AddSource(userBus);
            _bus.AddSource(backingTrackBus);
            _bus.AddSource(metronomeBus);
        }

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
            _bus.Start();
        }

        public void StopPlayback()
        {
            _bus.Stop();
        }
    }
}
