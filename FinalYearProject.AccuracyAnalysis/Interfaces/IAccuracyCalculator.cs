using FinalYearProject.Audio.Models;
using FinalYearProject.Shared.Models.Dtos;

namespace FinalYearProject.Accuracy.Analysis.Interfaces
{
    public interface IAccuracyCalculator
    {
        /// <summary>
        /// Given a player's performance and an expected tab, calculate a percentage accuracy.(between 0 and 1)
        /// </summary>
        /// <param name="playerTimeline"></param>
        /// <param name="expectedTimeline"></param>
        /// <returns></returns>
        float CalculateAccuracy(
            NoteTimeline playerTimeline,
            ReferenceTabDto expectedTimeline
            );
    }
}
