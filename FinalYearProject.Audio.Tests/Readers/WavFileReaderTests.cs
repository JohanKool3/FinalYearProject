using FinalYearProject.Audio.AudioAnalysis.Readers;

namespace FinalYearProject.Audio.Tests.Readers
{
    public class WavFileReaderTests
    {
        #region ReadAudioFile

        [Fact]
        public void WavFileReader_ReadAudioFile_ValidFile_ReturnsData() 
        {
            var reader = new WavFileReader();

            var fileName = "TestData\\eminor-test.wav";

            var data = reader.ReadAudioFile(fileName);

            Assert.NotEmpty(data);
        
        }

        [Fact]
        public void WavFileReader_ReadAudioFile_InvalidFile_ReturnsEmpty()
        {
            var reader = new WavFileReader();

            var fileName = "TestData\\non-existent-file.wav";

            var data = reader.ReadAudioFile(fileName);

            Assert.Empty(data);

        }

        [Fact]
        public void WavFileReader_ReadAudioFile_MalformedPath_ReturnsEmpty()
        {
            var reader = new WavFileReader();

            var fileName = "TestData\\non-existent-file";

            var data = reader.ReadAudioFile(fileName);

            Assert.Empty(data);

        }

        #endregion

        #region ReadAudioFileMetadata

        [Fact]
        public void WavFileReader_ReadAudioFileMetadata_ValidFile_ReturnsData()
        {
            var reader = new WavFileReader();

            var fileName = "TestData\\eminor-test.wav";

            var data = reader.ReadAudioFileMetadata(fileName);

            Assert.Equal(48000, data?.SampleRate);
            Assert.Equal(2, data?.Channels);

        }

        [Fact]
        public void WavFileReader_ReadAudioFileMetadata_InvalidFile_ReturnsNull()
        {
            var reader = new WavFileReader();

            var fileName = "TestData\\non-existent-file.wav";

            var data = reader.ReadAudioFileMetadata(fileName);

            Assert.Null(data);

        }

        [Fact]
        public void WavFileReader_ReadAudioFileMetadata_MalformedPath_ReturnsNull()
        {
            var reader = new WavFileReader();

            var fileName = "TestData\\non-existent-file";

            var data = reader.ReadAudioFileMetadata(fileName);

            Assert.Null(data);

        }

        #endregion
    }
}
