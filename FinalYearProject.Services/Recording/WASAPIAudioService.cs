using FinalYearProject.Services.Enums;
using FinalYearProject.Services.Exceptions;
using FinalYearProject.Services.Interfaces;
using FinalYearProject.Services.Models;
using FinalYearProject.Services.SampleProviders;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.Data;

namespace FinalYearProject.Services.Recording
{
    public class WASAPIAudioService(
        AudioRecordingServiceSettings settings) : IAudioRecordingService
    {

        private WasapiCapture? _capture;
        private WasapiOut? _playback;

        // The Audio Input Device
        private WaveInProvider? _audioInputProvider;
        private WaveFileWriter? _writer;

        public AudioRecordingServiceSettings Settings { get; } = settings;

        #region Metadata and Setup
        
        public List<AudioDevice> GetInputDevices()
        {
            var enumerator = new MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);

            return [.. devices.Select(d => new AudioDevice
            {
                Id = d.ID,
                Name = d.FriendlyName
            })];
        }

        public List<AudioDevice> GetOutputDevices()
        {
            var enumerator = new MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);

            return [.. devices.Select(d => new AudioDevice
            {
                Id = d.ID,
                Name = d.FriendlyName
            })];
        }

        #endregion
        
        public void StartRecording(string outputPath)
        {
            // Check if the Input Device has not been set.
            if (Settings.InputDeviceId == string.Empty)
            {
                throw new InputDeviceNotSetException("Input Device ID has not been set");
            }

            // AUDIO CAPTURE
            var inputDevice = new MMDeviceEnumerator()
                .GetDevice(Settings.InputDeviceId);

            
            _capture = new WasapiCapture(inputDevice, true);
            _audioInputProvider = new WaveInProvider(_capture);
            var audioSampleProvider = _audioInputProvider.ToSampleProvider();

            // METRONOME
            var metronome = new MetronomeSampleProvider(
                        150,
                        audioSampleProvider.WaveFormat.SampleRate,
                        audioSampleProvider.WaveFormat);


            var mixer = new MixingSampleProvider(audioSampleProvider.WaveFormat);
            mixer.AddMixerInput(audioSampleProvider);
            mixer.AddMixerInput(metronome);


            _playback = new WasapiOut(AudioClientShareMode.Shared, false, Settings.InputLatency);
            _playback.Init(mixer);
            _playback.Play();



            _writer = new WaveFileWriter(outputPath, _capture.WaveFormat);
      
            // Register Event Handlers
            _capture.DataAvailable += OnRecordedDataAvailable;
            _capture.RecordingStopped += OnRecordingStopped;

            _capture.StartRecording();
        }

        public void StopRecording()
        {
            if (_capture is null || _playback is null)
            {
                throw new ArgumentNullException("Capture Device is null, Cannot stop a null object");
            }

            _capture.StopRecording();
            _playback.Stop();
            OnRecordingStopped(null, null);
        }

        /// <summary>
        /// Indicates the actions to be performed when the recording process
        /// has stopped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnRecordingStopped(object? sender, StoppedEventArgs? args)
        {
            _writer?.Dispose();
            _writer = null;
            _capture?.Dispose();
            _capture = null;
        }

        private void OnRecordedDataAvailable(object? sender, WaveInEventArgs args)
        {
            if (_writer is null)
            {
                throw new AudioDataWriterNullException("Writer is null, cannot perform recording");
            }

            _writer.Write(args.Buffer, 0, args.BytesRecorded);
        }
    }
}
