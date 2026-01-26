using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.Audio.Helpers
{
    public static class SemitonesToNoteHelper
    {
        /// <summary>
        /// Converts a number of semitones to its corresponding note name.
        /// </summary>
        /// <param name="semitones"></param>
        /// <returns></returns>
        /// <remarks>
        /// When there is a note between two notes (e.g., C and D),
        /// the sharp (#) notation is used (e.g., C#).
        /// </remarks>
        public static string ConvertToNoteName(int semitones)
        {
            // Ensure that the semitones value is within the valid MIDI range
            // see <a href="https://inspiredacoustics.com/en/MIDI_note_numbers_and_center_frequencies">MIDI Specifications</a>
            if (semitones < 0 || semitones > 128)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(semitones),
                    "Semitones must be between 0 and 127 inclusive.");
            }

            return MidiToName(semitones);
        }

        /// <summary>
        /// Converts a MIDI note number to its corresponding note name.
        /// </summary>
        /// <param name="midiNote"></param>
        /// <returns></returns>
        private static string MidiToName(int midiNote)
        {
            // Define the note names in an octave
            string[] noteNames =
            {
                "C", "C#", "D", "D#", "E", "F",
                "F#", "G", "G#", "A", "A#", "B"
            };

            // Calculate the octave number (assuming MIDI note 0 is C-1)
            int octave = (midiNote / 12) - 1;

            // Get the note position within the octave
            return $"{noteNames[midiNote % 12]}{octave}";
        }
    }
}
