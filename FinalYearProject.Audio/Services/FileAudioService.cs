using FinalYearProject.Audio.Helpers;
using FinalYearProject.Audio.Interfaces;
using FinalYearProject.Audio.Pipeline.AudioSources;
using FinalYearProject.Shared.Helpers;
using FinalYearProject.Shared.Models.AudioRepresentation;
using System.Timers;

namespace FinalYearProject.Audio.Services
{
    /// <summary>
    /// Represents an audio Service that uses a File Input
    /// </summary>
    public class FileAudioService : IAudioService
    {
        /// <summary>
        /// The Audio File Source
        /// </summary>
        private FileAudioSource? _source = null;

        // Where audio samples are stored
        public float[] Buffer { get; private set; } = new float[2048];

        private System.Timers.Timer? _timer = null;

        #region Register and Call Events on Timer Tick
        /// <summary>
        /// Holds the events that will be triggered on the Tick Event for the timer
        /// </summary>
        private event EventHandler? _onTickEventHandlers;

        public event EventHandler OnTickEvent
        {
            add { _onTickEventHandlers += value; }
            remove { _onTickEventHandlers -= value; }
        }

        /// <summary>
        /// Handles calling the subscribed event handlers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerTickInternal(object? sender, ElapsedEventArgs e)
        {
            if(_source is null || Buffer is null)
            {
                return;
            }

            // Load new Samples into buffer
            ReadToBuffer();

            _onTickEventHandlers?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        /// <summary>
        /// Loads a Given File to the Audio Service
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="folderName"></param>
        public void Load(string filename, string folderName)
        {
            var path = FileHelper.GetFilePath(filename, folderName);
            _source = new FileAudioSource(path);

            _timer = new System.Timers.Timer(30); // ~33fps

            // Reset Handlers (so no unexpected behaviour)
            _timer.Elapsed -= TimerTickInternal;

            // Register the new Listener's Event Handlers
            _timer.Elapsed += TimerTickInternal;
        }

        /// <summary>
        /// Reads the next set of samples from the Audio Stream into the buffer. 
        /// </summary>
        /// <returns>Number of Samples Read.
        /// -1 if the Source is unset</returns>
        private void ReadToBuffer()
            => _source?.Read(Buffer);

        /// <summary>
        /// Converts the set of samples held in the buffer to Frequency Domain (Using Fast Fourier Transform).
        /// This method does not progress playback, it is purely to take existing information and convert into
        /// a new dimension for analysis.
        /// </summary>
        /// <param name="resolution"></param>
        /// <returns></returns>
        public FftResult? ReadBufferToFrequencyDomain(int resolution)
            => AnalysisConverter.ConvertToFrequencyDomain(
                Buffer,
                Buffer.Length,
                resolution,
                _source?.SampleRate ?? 0);

        #region Start, Stop and Reset

        /// <summary>
        /// Removes the information loaded from the Audio Service
        /// </summary>
        public void Remove()
        {
            _source = null;

            _timer = null;
        }

        public void Start()
        {
            // Cannot start the timer if it is null
            if (_timer is null)
            {
                return;
            }

            _timer.Start();
        }

        public void Stop()
        {
            if (_timer is null)
            {
                return;
            }

            _timer.Stop();
        }

        public void Reset()
        {
            // Cannot Reset if either the timer or source is null
            if (_timer is null || _source is null)
            {
                return;
            }

            _timer.Stop();

            // Reset FFT readout
            _source.Seek(0);
        }

        #endregion
    }
}
