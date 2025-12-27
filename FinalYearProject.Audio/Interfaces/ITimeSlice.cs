using FinalYearProject.Audio.Models;

namespace FinalYearProject.Audio.Interfaces
{
    public interface ITimeSlice
    {
        /// <summary>
        /// Gets the notes detected in this time slice.
        /// </summary>
        public List<Note> Notes { get; set; }

        /// <summary>
        /// How long this time slice lasted
        /// </summary>
        public double Duration { get; set; }
    }
}