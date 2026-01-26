using FinalYearProject.Audio.Helpers;

namespace FinalYearProject.Audio.Tests.Helpers
{
    public class SemitonesToNoteHelperTests
    {

        [Theory]
        [InlineData(69, "A4")]
        [InlineData(70, "A#4")]
        [InlineData(71, "B4")]
        [InlineData(60, "C4")]
        public void SemitonesToNoteHelper_ConvertSemitonesToNote_ReturnsExpectedNote(int semitones, string expectedNote)
        {
            // Arrange
            // Act
            var result = SemitonesToNoteHelper
                .ConvertToNoteName(semitones);

            // Assert
            Assert.Equal(expectedNote, result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(128)]
        public void SemitonesToNoteHelper_ConvertSemitonesToNote_InvalidSemitones_ThrowsArgumentOutOfRangeException(int semitones)
        {
            // Arrange
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                    SemitonesToNoteHelper.ConvertToNoteName(semitones));
        }
    }
}
