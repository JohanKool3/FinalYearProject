using FinalYearProject.Audio.Readers;

namespace FinalYearProject.Audio.Tests.Readers
{
    public class WavFileReaderTests
    {
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
    }
}
