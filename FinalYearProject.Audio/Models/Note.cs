using FinalYearProject.Audio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.Audio.Models
{
    /// <summary>
    /// Outlines an individual musical note.
    /// </summary>
    /// <param name="noteName">The name of the note</param>
    /// <param name="register">Which octave the note is in</param>
    public class Note(NoteName noteName, int register)
    {
        public NoteName NoteName { get; } = noteName;
        public int Register { get; } = register;
    }
}
