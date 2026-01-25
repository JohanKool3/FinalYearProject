using FinalYearProject.Audio.Models;

namespace FinalYearProject.Audio.Interfaces
{
    public interface INoteDetector
    {
        /// <summary>
        /// Calculates the notes and their confidence values given a window and its
        /// related frequency spectrum
        /// </summary>
        /// <param name="window"></param>
        /// <param name="frequencies"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        NoteSlice CalculateNoteConfidenceValues(float[] window, List<float> frequencies, double startTime);
    }
}
