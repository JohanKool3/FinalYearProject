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
            // If the File Path is empty, set the reader and sample provider to null
            // and mark as inactive.
            if (filePath == string.Empty)
            {
                Reader = null;
                SampleProvider = null;
                IsActive = false;
                return;
            }

            try
            {
                Reader = new WaveFileReader(filePath);
                SampleProvider = Reader.ToSampleProvider();
                SampleRate = Reader.WaveFormat.SampleRate;
                Channels = Reader.WaveFormat.Channels;
                IsActive = true;
            }
            catch (FileNotFoundException)
            {
                Reader = null;
                SampleProvider = null;
                IsActive = false;

            }
            catch (DirectoryNotFoundException)
            {
                Reader = null;
                SampleProvider = null;
                IsActive = false;

            }

        }

        /// <inheritdoc />
        public int? SampleRate { get; set; }

        /// <inheritdoc />
        public int? Channels { get; set; }

        /// <inheritdoc />
        public bool IsActive { get; private set; }

        /// <inheritdoc />
        internal ISampleProvider? SampleProvider { get; private set; }

        /// <inheritdoc />
        internal WaveFileReader? Reader { get; private set; }

        /// <inheritdoc />
        public ValueTask DisposeAsync()
        {
            // Cannot dispose reader as it was never set
            if (Reader is null)
            {
                return ValueTask.CompletedTask;
            }

            // Ensure that the reader is disposed of properly, freeing up resources.
            return Reader.DisposeAsync();
        }

        public int Read(float[] buffer)
        {
            // Handle the case where the sample provider is not initialized.
            if (!IsActive || SampleProvider is null)
            {
                return 0;
            }

            return SampleProvider.Read(buffer, 0, buffer.Length);
        }
    }
}
