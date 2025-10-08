using FinalYearProject.Shared.Models.TabRepresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.Shared.Test.Models.TabRepresentation
{
    public class TabNoteTests
    {

        [Fact]
        public void TabNote_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            int stringNumber = 3;
            int fretNumber = 5;
            int startTime = 0;
            int duration = 4;
            
            // Act
            var tabNote = new TabNote(stringNumber, fretNumber,startTime, duration);
            
            // Assert
            Assert.Equal(stringNumber, tabNote.StringNumber);
            Assert.Equal(fretNumber, tabNote.FretNumber);
            Assert.Equal(duration, tabNote.Duration);
        }

        [Theory]
        [InlineData(0)]  // Invalid string number (too low)
        [InlineData(7)]  // Invalid string number (too high)
        public void TabNote_Constructor_InvalidStringNumber_ThrowsArgumentOutOfRangeException(int invalidStringNumber)
        {
            // Arrange
            int fretNumber = 5;
            int startTime = 0;
            int duration = 4;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() 
                => new TabNote(invalidStringNumber, fretNumber, startTime, duration));
        }

        [Theory]
        [InlineData(-1)]  // Invalid fret number (negative)
        [InlineData(31)]  // Invalid fret number (too high)
        public void TabNote_Constructor_InvalidFretNumber_ThrowsArgumentOutOfRangeException(int invalidFretNumber)
        {
            // Arrange
            int stringNumber = 3;
            int startTime = 0;
            int duration = 4;
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() 
                => new TabNote(stringNumber, invalidFretNumber, startTime, duration));
        }

        [Fact]
        public void TabNote_Constructor_NegativeStartTime_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            int stringNumber = 3;
            int fretNumber = 5;
            int invalidStartTime = -1;
            int duration = 4;
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() 
                => new TabNote(stringNumber, fretNumber, invalidStartTime, duration));
        }

        [Theory]
        [InlineData(0)]  // Invalid duration (zero)
        [InlineData(-2)] // Invalid duration (negative)
        public void TabNote_Constructor_InvalidDuration_ThrowsArgumentOutOfRangeException(int invalidDuration)
        {
            // Arrange
            int stringNumber = 3;
            int fretNumber = 5;
            int startTime = 0;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() 
                => new TabNote(stringNumber, fretNumber, startTime, invalidDuration));
        }
    }
}
