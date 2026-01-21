using FinalYearProject.Audio.AudioAnalysis.Readers;
using FinalYearProject.Audio.AudioAnalysis.Windowers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.Audio.Tests.IntegrationTests
{
    public class WavFileReaderAndSimpleWindowerTests
    {

        [Fact]
        public void WavFileReaderAndSimpleWindower_ReadValidWavFile_ReturnsCorrectFrames()
        {
            // Arrange
            var reader = new WavFileReader();
            var fileName = "TestData\\eminor-test.wav";
            var windower = new SimpleWindower();

            // Act
            var pcmStream = reader.ReadAudioFile(fileName);

            var windows = windower.ConvertPCMStreamToWindows
                (pcmStream, 48000, 2048, 1024);

            var lastWindow = windows.Last();
            
            // Assert
            Assert.Equal(2090, windows.Count);
            Assert.NotEmpty(pcmStream);
            Assert.Equal(2048, lastWindow.Samples.Count);

        }
    }
}
