using FinalYearProject.Audio.Helpers;

namespace FinalYearProject.Audio.Tests.Helpers
{
    public class FrequencyToNoteHelperTests
    {

        [Theory]
        #region Notes to Semitones Test Data
        // Octave 0
        [InlineData(8.18f, 0)]    // C0 
        [InlineData(8.66f, 1)]    // C#0
        [InlineData(9.18f, 2)]    // D0
        [InlineData(9.72f, 3)]    // D#0
        [InlineData(10.30f, 4)]   // E0
        [InlineData(10.91f, 5)]   // F0
        [InlineData(11.56f, 6)]   // F#0
        [InlineData(12.25f, 7)]   // G0
        [InlineData(12.98f, 8)]   // G#0
        [InlineData(13.75f, 9)]   // A0
        [InlineData(14.57f, 10)]  // A#0
        [InlineData(15.43f, 11)]  // B0

        // Octave 1
        [InlineData(16.35f, 12)]  // C1
        [InlineData(17.32f, 13)]  // C#1
        [InlineData(18.35f, 14)]  // D1
        [InlineData(19.45f, 15)]  // D#1
        [InlineData(20.60f, 16)]  // E1
        [InlineData(21.83f, 17)]  // F1
        [InlineData(23.12f, 18)]  // F#1
        [InlineData(24.50f, 19)]  // G1
        [InlineData(25.96f, 20)]  // G#1
        [InlineData(27.50f, 21)]  // A1
        [InlineData(29.14f, 22)]  // A#1
        [InlineData(30.87f, 23)]  // B1

        // Octave 2
        [InlineData(32.70f, 24)]  // C2
        [InlineData(34.65f, 25)]  // C#2
        [InlineData(36.71f, 26)]  // D2
        [InlineData(38.89f, 27)]  // D#2
        [InlineData(41.20f, 28)]  // E2
        [InlineData(43.65f, 29)]  // F2
        [InlineData(46.25f, 30)]  // F#2
        [InlineData(49.00f, 31)]  // G2
        [InlineData(51.91f, 32)]  // G#2
        [InlineData(55.00f, 33)]  // A2
        [InlineData(58.27f, 34)]  // A#2
        [InlineData(61.74f, 35)]  // B2

        // Octave 3
        [InlineData(65.41f, 36)]  // C3
        [InlineData(69.30f, 37)]  // C#3
        [InlineData(73.42f, 38)]  // D3
        [InlineData(77.78f, 39)]  // D#3
        [InlineData(82.41f, 40)]  // E3
        [InlineData(87.31f, 41)]  // F3
        [InlineData(92.50f, 42)]  // F#3
        [InlineData(98.00f, 43)]  // G3
        [InlineData(103.83f, 44)] // G#3
        [InlineData(110.00f, 45)] // A3
        [InlineData(116.54f, 46)] // A#3
        [InlineData(123.47f, 47)] // B3

        // Octave 4
        [InlineData(130.81f, 48)] // C4
        [InlineData(138.59f, 49)] // C#4
        [InlineData(146.83f, 50)] // D4
        [InlineData(155.56f, 51)] // D#4
        [InlineData(164.81f, 52)] // E4
        [InlineData(174.61f, 53)] // F4
        [InlineData(185.00f, 54)] // F#4
        [InlineData(196.00f, 55)] // G4
        [InlineData(207.65f, 56)] // G#4
        [InlineData(220.00f, 57)] // A4
        [InlineData(233.08f, 58)] // A#4
        [InlineData(246.94f, 59)] // B4

        // Octave 5
        [InlineData(261.63f, 60)] // C5
        [InlineData(277.18f, 61)] // C#5
        [InlineData(293.66f, 62)] // D5
        [InlineData(311.13f, 63)] // D#5
        [InlineData(329.63f, 64)] // E5
        [InlineData(349.23f, 65)] // F5
        [InlineData(369.99f, 66)] // F#5
        [InlineData(392.00f, 67)] // G5
        [InlineData(415.30f, 68)] // G#5
        [InlineData(440.00f, 69)] // A5
        [InlineData(466.16f, 70)] // A#5
        [InlineData(493.88f, 71)] // B5

        // Octave 6
        [InlineData(523.25f, 72)] // C6
        [InlineData(554.37f, 73)] // C#6
        [InlineData(587.33f, 74)] // D6
        [InlineData(622.25f, 75)] // D#6
        [InlineData(659.25f, 76)] // E6
        [InlineData(698.46f, 77)] // F6
        [InlineData(739.99f, 78)] // F#6
        [InlineData(783.99f, 79)] // G6
        [InlineData(830.61f, 80)] // G#6
        [InlineData(880.00f, 81)] // A6
        [InlineData(932.33f, 82)] // A#6
        [InlineData(987.77f, 83)] // B6

        // Octave 7
        [InlineData(1046.50f, 84)]  // C7
        [InlineData(1108.73f, 85)]  // C#7
        [InlineData(1174.66f, 86)]  // D7
        [InlineData(1244.51f, 87)]  // D#7
        [InlineData(1318.51f, 88)]  // E7
        [InlineData(1396.91f, 89)]  // F7
        [InlineData(1479.98f, 90)]  // F#7
        [InlineData(1567.98f, 91)]  // G7
        [InlineData(1661.22f, 92)]  // G#7
        [InlineData(1760.00f, 93)]  // A7
        [InlineData(1864.66f, 94)]  // A#7
        [InlineData(1975.53f, 95)]  // B7

        // Octave 8
        [InlineData(2093.00f, 96)]  // C8
        [InlineData(2217.46f, 97)]  // C#8
        [InlineData(2349.32f, 98)]  // D8
        [InlineData(2489.02f, 99)]  // D#8
        [InlineData(2637.02f, 100)] // E8
        [InlineData(2793.83f, 101)] // F8
        [InlineData(2959.96f, 102)] // F#8
        [InlineData(3135.96f, 103)] // G8
        [InlineData(3322.44f, 104)] // G#8
        [InlineData(3520.00f, 105)] // A8
        [InlineData(3729.31f, 106)] // A#8
        [InlineData(3951.07f, 107)] // B8

        // Octave 9
        [InlineData(4186.00f, 108)] // C9
        [InlineData(4434.92f, 109)] // C#9
        [InlineData(4698.63f, 110)] // D9
        [InlineData(4978.03f, 111)] // D#9
        [InlineData(5274.04f, 112)] // E9
        [InlineData(5587.65f, 113)] // F9
        [InlineData(5919.91f, 114)] // F#9
        [InlineData(6271.93f, 115)] // G9
        [InlineData(6644.88f, 116)] // G#9
        [InlineData(7040.00f, 117)] // A9
        [InlineData(7458.62f, 118)] // A#9
        [InlineData(7902.13f, 119)] // B9

        #endregion
        public void FrequencyToNoteHelper_GetFrequencySemiTones_ReturnsExpectedMidiNoteNumber(float frequency, int expectedMidiNoteNumber)
        {
            // Arrange
            const double a4Frequency = 440.0;
            // Act
            int midiNoteNumber = FrequencyToNoteHelper
                .GetSemiTonesFromFrequency(frequency, a4Frequency);
            // Assert
            Assert.Equal(expectedMidiNoteNumber, midiNoteNumber);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(float.MaxValue)]
        public void FrequencyToNoteHelper_GetFrequencySemiTones_InvalidFrequency_ThrowsArgumentOutOfRangeException(float frequency)
        {
            // Arrange
            const double a4Frequency = 440.0;
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                FrequencyToNoteHelper.GetSemiTonesFromFrequency(frequency, a4Frequency));
        }

        [Fact]
        public void FrequencyToNoteHelper_GetFrequencySemiTones_Zero_ReturnsLowestNote()
        {
           // Arrange
            const float frequency = 0.0f;
            const double a4Frequency = 440.0;
            const int expectedMidiNoteNumber = 0; // C0
            // Act
            int midiNoteNumber = FrequencyToNoteHelper
                .GetSemiTonesFromFrequency(frequency, a4Frequency);
            // Assert
            Assert.Equal(expectedMidiNoteNumber, midiNoteNumber);

        }
    }
}
