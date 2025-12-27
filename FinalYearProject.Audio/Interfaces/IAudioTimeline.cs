namespace FinalYearProject.Audio.Interfaces
{
    public interface IAudioTimeline
    {
        /// <summary>
        /// The total duration of the audio in seconds.
        /// </summary>
        public double TotalDurationInSeconds { get; set; }

        /// <summary>
        /// Holds all time slices in the audio timeline.
        /// </summary>
        public List<ITimeSlice> TimeSlices { get; set; }
    }
}
