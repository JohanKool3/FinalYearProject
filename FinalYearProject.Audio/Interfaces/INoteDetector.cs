using FinalYearProject.Audio.Models;

namespace FinalYearProject.Audio.Interfaces
{
    public interface INoteDetector
    {
        /// <summary>
        /// Calculates the notes and their confidence values given a window and its
        /// related frequency spectrum
        /// </summary>
        /// <param name="frequencyMagnitudeSnapshot">An array of magnitudes for each frequency in frequencies</param>
        /// <param name="frequencies">The frequencies that the magnitude snapshot represent e.g. frequencies[i] -> frequencyMagnitudeSnapshot[i]</param>
        /// <param name="startTime">When the snapshot started</param>
        /// <returns></returns>
        NoteSlice CalculateNoteConfidenceValues(float[] frequencyMagnitudeSnapshot, List<float> frequencies, double startTime);

        /// <summary>
        /// Calculates the notes and their confidence values for a batch of frequency magnitude snapshots
        /// </summary>
        /// <param name="frequencyMagnitudeSnapshots"></param>
        /// <param name="frequencies"></param>
        /// <param name="startTime"></param>
        /// <param name="dataPointLength"></param>
        /// <returns></returns>
        List<NoteSlice> BatchCalculateNoteConfidenceValues(List<float[]> frequencyMagnitudeSnapshots, List<float> frequencies, double startTime, double dataPointLength);
    }
}
