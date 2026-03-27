using FinalYearProject.Services.Interfaces;
using FinalYearProject.Services.Models;
using FinalYearProject.Services.Settings;
using FinalYearProject.UI.Components.Services.Audio.Windows.AudioBuses;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace FinalYearProject.UI.Components.Services.Audio
{
    /// <summary>
    /// Audio Engine Service for Windows Devices
    /// </summary>
    public class WindowsAudioService : IAudioService
    {
        /// <summary>
        /// The output for this Audio Service.
        /// </summary>
        private MainBus _mainBus;
        private readonly UserBus _userBus;
        private readonly AudioServiceSettings _settings;

        // Output
        private WasapiOut? _output;

        public WindowsAudioService(
            MainBus mainBus,
            BackingTrackBus backingTrackBus,
            MetronomeBus metronomeBus,
            UserBus userBus,
            AudioServiceSettings settings)
        {
            // Register the main Bus 
            _mainBus = mainBus;

            _userBus = userBus;
            _settings = settings;

            // Add Sub Busses as inputs into Main Bus
            _mainBus.AddSource(userBus);
            _mainBus.AddSource(backingTrackBus);
            _mainBus.AddSource(metronomeBus);


            // Set Initial Settings
            SetInitialSettings();

            // Set output
            _output = new WasapiOut();
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
            if (outputDevices is null)
            {
                return [];
            }
            return outputDevices;
        }


        public void EnableRecording()
        {
            throw new NotImplementedException();
        }

        public void StartPlayback()
        {
            // TODO: Log Exception
            if (_output is null)
            {
                return;
            }

            // TODO: Log Exception
            if(_userBus is null || _userBus.Source is null)
            {
                return;
            }

            // Initialize Input
            _userBus.Source.InitializeCapture();


            // Set the output device
            var enumerator = new MMDeviceEnumerator();
            var outputDevice = enumerator.GetDevice(_settings.OutputDeviceId);

            var deviceFormat = outputDevice.AudioClient.MixFormat;


            var floatFormat = WaveFormat.CreateIeeeFloatWaveFormat(
                    deviceFormat.SampleRate,
                    deviceFormat.Channels);

            _mainBus.SetMixer(floatFormat);

            var outputSampleProvider = _mainBus.GetOutput();

            if (outputSampleProvider is null)
            {
                return;
            }

            // Cannot start as no output device
            if (outputDevice is null)
            {
                return;
            }

            _output = new WasapiOut(outputDevice,
                AudioClientShareMode.Shared,
                true,
                _settings.OutputLatency);

            _output.Init(outputSampleProvider);
            _output.Play();
        }

        public void StopPlayback()
        {
            if (_output is null)
            {
                return;
            }

            _output.Stop();
        }

        /// <summary>
        /// Used to reset playback when changes have been made to settings
        /// </summary>
        public void RestartPlayback()
        {
            StopPlayback();
            StartPlayback();
        }
    }
}
