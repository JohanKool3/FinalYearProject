using FinalYearProject.Services.Interfaces;
using FinalYearProject.Services.Settings;
using FinalYearProject.Shared.Services;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace FinalYearProject.UI.Components.Services.Audio.Windows.AudioSources
{
    public class UserInputSource(AudioServiceSettings audioServiceSettings,
        PlaybackService playbackService) : IAudioSource
    {
        public bool IsEnabled 
            => true;

        public string Name 
            => "user-input-source";

        #region User Input 

        private WasapiCapture? _capture;

        private ISampleProvider? _waveProvider;

        #endregion

        public AudioServiceSettings AudioServiceSettings { get; } = audioServiceSettings;
        private readonly PlaybackService _playbackService = playbackService;

        public ISampleProvider? SampleProvider => _waveProvider;

        public void Dispose()
        {
            _capture?.Dispose();
            _waveProvider = null;
        }

        public ISampleProvider? GetOutput()
            => _waveProvider;

        public void Start()
        {
            if (_capture?.CaptureState == CaptureState.Stopped)
            {
                _capture?.StartRecording();
            }
        }

        public void Stop()
        {
            _capture?.StopRecording();
        }

        public void InitializeCapture()
        {
            var device = GetDevice();

            if (device is null)
            {
                return;
            }

            _capture = new WasapiCapture(device);

            // Setup the Buffered Wave Provider
            var waveProvider = new BufferedWaveProvider(_capture.WaveFormat)
            {
                DiscardOnBufferOverflow = true
            };

            // When Audio Data is available in the capture, move
            // to buffered wave provider
            _capture.DataAvailable += (s, e) =>
            {
                waveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);

                if (_playbackService.InRecordingState)
                {
                    // TODO: Insert Writing to File Logic here
                }
            };

            _waveProvider = waveProvider.ToSampleProvider();
        }

        private MMDevice? GetDevice()
        {
            var inputDeviceId = AudioServiceSettings.InputDeviceId;
            var enumerator = new MMDeviceEnumerator();
            var device = enumerator.GetDevice(inputDeviceId);

            return device;
        }
    }
}
