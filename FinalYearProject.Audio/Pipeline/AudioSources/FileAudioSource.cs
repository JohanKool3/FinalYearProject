using FinalYearProject.Audio.Interfaces;
using NAudio.Wave;

namespace FinalYearProject.Audio.Pipeline.AudioSources
{
    public class FileAudioSource : IAudioSource
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="FileAudioSource"/> class.
        /// </summary>
        /// <param name="filePath"></param>
        public FileAudioSource(string filePath)
        {
            try
            {
                _reader = new WaveFileReader(filePath);
                _sampleProvider = _reader.ToSampleProvider();
                SampleRate = _reader.WaveFormat.SampleRate;
                Channels = _reader.WaveFormat.Channels;
                IsActive = true;
            }
            catch(FileNotFoundException)
            {
                _reader = null;
                _sampleProvider = null;
                IsActive = false;

            }
            
           
        }

        /// <inheritdoc />
        public int? SampleRate { get; set;  }

        /// <inheritdoc />
        public int? Channels { get; set; }

        /// <inheritdoc />
        public bool IsActive { get; private set; }

        /// <inheritdoc />
        private readonly ISampleProvider? _sampleProvider;
        
        /// <inheritdoc />
        private WaveFileReader? _reader;

        /// <inheritdoc />
        public ValueTask DisposeAsync()
        {
            // Cannot dispose reader as it was never set
            if(_reader is null)
            {
                return ValueTask.CompletedTask;
            }

            // Ensure that the reader is disposed of properly, freeing up resources.
            return _reader.DisposeAsync();
        }

        public int Read(float[] buffer)
        {
            // Handle the case where the sample provider is not initialized.
            if (_sampleProvider is null)
            {
                return 0;
            }

            return _sampleProvider.Read(buffer, 0, buffer.Length);
        }
    }
}
