using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.Audio.Models
{
    /// <summary>
    /// Represents a slice in time containing note confidence data.
    /// </summary>
    public class NoteSlice
    {
        /// <summary>
        /// The Time Stamp in Seconds of this Note Slice
        /// </summary>
        public float Time { get; set; }

        /// <summary>
        /// List of NoteConfidence objects representing the confidence levels 
        /// for various notes at this time slice.
        /// </summary>
        public List<NoteConfidence> NoteConfidences { get; set; } = [];
    }
}
