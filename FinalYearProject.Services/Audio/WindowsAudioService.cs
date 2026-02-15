using FinalYearProject.Services.Audio.Windows.AudioBuses;
using FinalYearProject.Services.Interfaces;
using FinalYearProject.Services.Models;
using FinalYearProject.Services.Settings;
using Microsoft.Maui.Devices;
using NAudio.CoreAudioApi;

namespace FinalYearProject.Services.Audio
{
    /// <summary>
    /// Audio Engine Service for Windows Devices
    /// </summary>
    public class WindowsAudioService : IAudioService
    {
        /// <summary>
        /// The output for this Audio Service.
        /// </summary>
        private MainBus _bus;
        private readonly AudioServiceSettings _settings;

        public WindowsAudioService(
            MainBus mainBus,
            BackingTrackBus backingTrackBus,
            MetronomeBus metronomeBus,
            UserBus userBus,
            AudioServiceSettings settings)
        {
            // Register the main Bus 
            _bus = mainBus;
            _settings = settings;

            // Add Inputs into Main Bus
            _bus.AddSource(userBus);
            _bus.AddSource(backingTrackBus);
            _bus.AddSource(metronomeBus);


            // Set Initial Settings
            SetInitialSettings();
        }

        private void SetInitialSettings()
        {
            // Set Initial Audio Settings
            var inputDevices = GetInputDevices();
            var outputDevices = GetOutputDevices();

            if (inputDevices.Count > 0)
            {
                _settings.InputDeviceId = inputDevices[0].Id;
            }

            if (outputDevices.Count > 0)
            {
                _settings.OutputDeviceId = outputDevices[0].Id;
            }
        }

        public List<AudioDevice> GetInputDevices()
        {
            var enumerator = new MMDeviceEnumerator();

            var outputDevices = enumerator
                .EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active)
                .Select(d => new AudioDevice()
                {
                    Id = d.ID,
                    Name = d.FriendlyName
                }).ToList();


            // Handle no devices found
            if (outputDevices is null)
            {
                return [];
            }
            return outputDevices;
        }

        public List<AudioDevice> GetOutputDevices()
        {
            var enumerator = new MMDeviceEnumerator();

            var outputDevices = enumerator
                .EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active)
                .Select(d => new AudioDevice()
                {
                    Id = d.ID,
                    Name = d.FriendlyName
                }).ToList();


            // Handle no devices found
            if(outputDevices is null)
            {
                return [];
            }
            return outputDevices;
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
