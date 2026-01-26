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
    }
}
