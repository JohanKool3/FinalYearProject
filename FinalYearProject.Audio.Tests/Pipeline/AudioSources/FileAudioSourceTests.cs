using FinalYearProject.Audio.Pipeline.AudioSources;
using FinalYearProject.Audio.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalYearProject.Audio.Tests.Pipeline.AudioSources
{
    public class FileAudioSourceTests
    {

        [Fact]
        public void FileAudioSource_Constructor_ShouldInitializeNullProperties()
        {
            // Arrange
            string testFilePath = "invalid_file.wav";
            
            // Act
            var audioSource = new FileAudioSource(testFilePath);

            // Assert
            Assert.NotNull(audioSource);
            Assert.Null(audioSource.SampleRate); // Default value
            Assert.Null(audioSource.Channels);   // Default value
        }

        [Fact]
        public async Task FileAudioSource_Constructor_ShouldInitializeProperly()
        {
            // Arrange
            string testFilePath = FileHelper.GetTestFilePath("eminor-test.wav");

            // Act
            var audioSource = new FileAudioSource(testFilePath);
            
            // Assert
            Assert.NotNull(audioSource);
            Assert.Equal(44100, audioSource.SampleRate); // 44100 Hz
            Assert.Equal(2, audioSource.Channels);   // 2 Channels
        }
    }
}
