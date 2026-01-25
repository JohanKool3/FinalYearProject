using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.Audio.Helpers
{
    public static class SemitonesToNoteHelper
    {
        public static string ConvertToNoteName(int semitonesFromA4)
        {
            // as A4 is 69th semitone
            int midiNote = 69 + semitonesFromA4;

            return MidiToName(midiNote);
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
