using FinalYearProject.Audio.Models;

namespace FinalYearProject.Audio.Interfaces
{
    public interface INoteTimelineConstuctor
    {

        /// <summary>
        /// Takes frequency timeline and converts it to a note timeline
        /// </summary>
        /// <param name="frequencyTimeline"></param>
        /// <returns></returns>
        public NoteTimeline GenerateTimeline(FrequencyMagnitudeTimeline frequencyTimeline, float noteDetectionThreshold);
    }
}
