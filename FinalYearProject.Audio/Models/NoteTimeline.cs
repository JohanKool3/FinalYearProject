using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.Audio.Models
{
    /// <summary>
    /// Holds information about how the note confidence changes over time.
    /// </summary>
    public class NoteTimeline
    {
        /// <summary>
        /// The Length of the clip in seconds
        /// </summary>
        public float Length { get; set; }

        /// <summary>
        /// How long each data point is in seconds.
        /// </summary>
        public double DataPointLength { get; set; }

        /// <summary>
        /// List of NoteSlices representing the note confidence data over time.
        /// </summary>
        public required List<NoteSlice> NoteSlices { get; set; }
    }
}
