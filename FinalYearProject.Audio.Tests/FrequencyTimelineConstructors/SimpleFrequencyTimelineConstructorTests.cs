using FinalYearProject.Audio.AudioAnalysis.FrequencyTimelineConstructors;
using FinalYearProject.Audio.Models;

namespace FinalYearProject.Audio.Tests.FrequencyTimelineConstructors
{
    public class SimpleFrequencyTimelineConstructorTests
    {

        [Fact]
        public void SimpleFrequencyTimelineConstructor_ValidInput_ReturnsCorrectFrequency()
        {
            // Arrange
            var fftOutputs = new List<FftOutput>
            {
                new() {
                    Frequencies = [1, 2, 3],
                    Magnitudes = [0, 0, 0],
                    AudioLength = 1,
                    StartTime = 0,
                    EndTime = 1,
                },
                new() {
                    Frequencies = [1, 2, 3],
                    Magnitudes = [1, 0, 0],
                    AudioLength = 1,
                    StartTime = 1,
                    EndTime = 2,
                },
                new() {
                    Frequencies = [1, 2, 3],
                    Magnitudes = [0, 0, 0],
                    AudioLength = 1,
                    StartTime = 2,
                    EndTime = 3,
                },
            };

            var constructor = new SimpleFrequencyTimelineConstructor();

            // Act
            var timeline = constructor.GenerateTimeline(fftOutputs);


            // Assert
            Assert.Equal([0, 1, 0], timeline.FrequencyMagnitude[1]);
            Assert.Equal([0, 0, 0], timeline.FrequencyMagnitude[2]);
            Assert.Equal([0, 0, 0], timeline.FrequencyMagnitude[3]);
        }


        [Fact]
        public void SimpleFrequencyTimelineConstructor_InconsistentFrequencies_ThrowsArgumentException()
        {
            // Arrange
            var fftOutputs = new List<FftOutput>
            {
                new() {
                    Frequencies = [1, 2, 3],
                    Magnitudes = [0, 0, 0],
                    AudioLength = 1,
                    StartTime = 0,
                    EndTime = 1,
                },
                new() {
                    Frequencies = [1, 2], // Inconsistent frequency length
                    Magnitudes = [1, 0],
                    AudioLength = 1,
                    StartTime = 1,
                    EndTime = 2,
                },
            };
            var constructor = new SimpleFrequencyTimelineConstructor();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => constructor.GenerateTimeline(fftOutputs));
        }

        [Fact]
        public void SimpleFrequencyTimelineConstructor_EmptyWindows_ThrowsArgumentException()
        {
            // Arrange
            var fftOutputs = new List<FftOutput>();
            var constructor = new SimpleFrequencyTimelineConstructor();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => constructor.GenerateTimeline(fftOutputs));
        }

        [Fact]
        public void SimpleFrequencyTimelineConstructor_EmptyFrequencies_ThrowsArgumentException()
        {
            // Arrange
            var fftOutputs = new List<FftOutput>
            {
                new() {
                    Frequencies = [],
                    Magnitudes = [],
                    AudioLength = 1,
                    StartTime = 0,
                    EndTime = 1,
                },
            };
            var constructor = new SimpleFrequencyTimelineConstructor();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => constructor.GenerateTimeline(fftOutputs));
        }
    }
}
