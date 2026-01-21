using FinalYearProject.Audio.Helpers;
using FinalYearProject.Audio.Interfaces;
using FinalYearProject.Audio.Models;
using NAudio.Wave;

namespace FinalYearProject.Audio.AudioAnalysis.Readers
{
    public class WavFileReader : IAudioReader
    {
        public List<float> ReadAudioFile(string filename)
        {
            // Convert Filename to Filepath
            var currentFilePath = FilepathHelper.GetCurrentDirectoryFilepath(filename);

            try
            {
                // Using to dispose of this at the end of extraction
                using var reader = new AudioFileReader(currentFilePath);

                return ExtractPCMSamples(reader);

            }
            catch (Exception)
            {
                // Cannot read as file not valid. 
                // TODO: Log this exception
                return [];
            }
        }

        /// <summary>
        /// Returns information about the audio file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public AudioFileMetadata? ReadAudioFileMetadata(string filename)
        {
            // Convert Filename to Filepath
            var currentFilePath = FilepathHelper.GetCurrentDirectoryFilepath(filename);

            try
            {
                // Using to dispose of this at the end of extraction
                using var reader = new AudioFileReader(currentFilePath);

                return new AudioFileMetadata()
                {
                    Channels = reader.WaveFormat.Channels,
                    SampleRate = reader.WaveFormat.SampleRate
                };

            }
            catch (Exception)
            {
                // Cannot read as file not valid. 
                // TODO: Log this exception
                return null;
            }
        }

        /// <summary>
        /// Return the Pulse Code Modulation Samples (Raw Audio Information)
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static List<float> ExtractPCMSamples(AudioFileReader reader)
        {
            List<float> samples = [];

            // Float array of length 1024 to be used as buffer
            float[] buffer = new float[1024];
            int read;

            // Get the amount of samples read 
            while ((read = reader.Read(buffer, 0, buffer.Length)) > 0)
            {
                for (int i = 0; i < read; i++)
                {
                    samples.Add(buffer[i]);
                }
            }

            return samples;

        }

    }
}
