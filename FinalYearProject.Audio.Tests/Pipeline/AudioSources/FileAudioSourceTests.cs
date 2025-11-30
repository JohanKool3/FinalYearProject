using FinalYearProject.Audio.Pipeline.AudioSources;
using FinalYearProject.Shared.Helpers;

namespace FinalYearProject.Audio.Tests.Pipeline.AudioSources
{
    public class FileAudioSourceTests
    {
        #region Constructor Tests

        [Fact]
        public void FileAudioSource_Constructor_ShouldInitializeNullProperties_ForInvalidFilePath()
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
        public void FileAudioSource_Constructor_ShouldInitializeNullProperties_ForMalformedFilePath()
        {
            // Arrange
            string testFilePath = ":::malformed_path:::/file.wav";
            
            // Act
            var audioSource = new FileAudioSource(testFilePath);

            // Assert
            Assert.NotNull(audioSource);
            Assert.Null(audioSource.SampleRate); // Default value
            Assert.Null(audioSource.Channels);   // Default value
        }

        [Fact]
        public void FileAudioSource_Constructor_ShouldInitializeNullProperties_ForNoFileExtension()
        {
            // Arrange
            string testFilePath = "file";

            // Act
            var audioSource = new FileAudioSource(testFilePath);

            // Assert
            Assert.NotNull(audioSource);
            Assert.Null(audioSource.SampleRate); // Default value
            Assert.Null(audioSource.Channels);   // Default value
        }

        [Fact]
        public void FileAudioSource_Constructor_ShouldInitializeNullProperties_ForEmptyPath()
        {
            // Arrange
            string testFilePath = string.Empty;

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
            string testFilePath = FileHelper.GetTestFilePath("eminor-test.wav", "TestData");

            // Act
            var audioSource = new FileAudioSource(testFilePath);
            
            // Assert
            Assert.NotNull(audioSource);
            Assert.Equal(44100, audioSource.SampleRate); // 44100 Hz
            Assert.Equal(2, audioSource.Channels);   // 2 Channels
        }

        #endregion

        #region Read Tests
        [Fact]
        public void FileAudioSource_Read_ShouldReturnZero_ForInactiveSource()
        {
            // Arrange
            string testFilePath = "invalid_file.wav";
            var audioSource = new FileAudioSource(testFilePath);
            float[] buffer = new float[1024];
            
            // Act
            int samplesRead = audioSource.Read(buffer);
            
            // Assert
            Assert.Equal(0, samplesRead);
        }

        [Fact]
        public void FileAudioSource_Read_ShouldReturnSamples_ForActiveSource()
        {
            // Arrange
            string testFilePath = FileHelper.GetTestFilePath("eminor-test.wav", "TestData");
            var audioSource = new FileAudioSource(testFilePath);
            float[] buffer = new float[1024];
            
            // Act
            int samplesRead = audioSource.Read(buffer);
            
            // Assert
            Assert.True(samplesRead > 0);
            Assert.NotEmpty(buffer);
        }
        #endregion
    }
}
