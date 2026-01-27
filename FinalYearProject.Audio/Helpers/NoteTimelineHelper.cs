using FinalYearProject.Audio.Models;

namespace FinalYearProject.Audio.Helpers
{
    public static class NoteTimelineHelper
    {
        /// <summary>
        /// Returns a List of Note Names at a given time in the NoteTimeline
        /// </summary>
        /// <param name="timeline">The Full Timeline of Notes over Time</param>
        /// <param name="time">The Time (in seconds) of the desired time slice</param>
        /// <param name="noteConfidenceMinimum">The Minimum confidence for a note to be present</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static List<string> GetNotesAtTime(
            NoteTimeline timeline,
            double time,
            float noteConfidenceMinimum)
        {
            // Check that the time is within the bounds of the timeline
            if (time < 0 || time > timeline.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(time), "Time is out of bounds of the timeline.");
            }

            // Find the Closest Time Index (integer cast to nearest whole number)
            var timeIndex = (int)(time / timeline.DataPointLength);

            // Get the Note Slice at the given time index
            var noteSlice = timeline.NoteSlices[timeIndex];

            // Get the notes with the confidence greater than or equal
            // to the given threshold
            var notesAtTime = noteSlice.NoteConfidences
                .Where(nc => nc.Confidence >= noteConfidenceMinimum)
                .Select(nc => nc.Name)
                .ToList();

            // If null, then return an empty list (cannot find any notes)
            if (notesAtTime is null)
            {
                // TODO: Log Warning - No Notes Found at Time
                return [];
            }

            return notesAtTime;
        }
    }
}
