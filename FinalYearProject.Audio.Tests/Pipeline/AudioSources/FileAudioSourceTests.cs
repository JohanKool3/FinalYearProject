using FinalYearProject.Audio.Pipeline.AudioSources;
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
    }
}
