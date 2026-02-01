using FinalYearProject.Accuracy.Analysis.Services.Calculators;
using FinalYearProject.Audio.Models;
using FinalYearProject.Shared.Models.Dtos;

namespace FinalYearProject.Accuracy.Analysis.Services
{
    public class PerformanceAccuracyService(
        NoteAccuracyCalculatorService noteAccuracyCalculator)
    {
        public NoteAccuracyCalculatorService NoteAccuracyCalculator { get; } = noteAccuracyCalculator;

        /// <summary>
        /// Calculate the performance accuracy of a player's timeline against the expected timeline.
        /// </summary>
        /// <param name="playerTimeline"></param>
        /// <param name="expectedTimeline"></param>
        /// <returns></returns>
        public AccuracyResultsDto CalculatePerformanceAccuracy(NoteTimeline playerTimeline,
            ReferenceTabDto expectedTimeline)
        {

            // Go through each aspect and calculate accuracy
            var noteAccuracy = NoteAccuracyCalculator.CalculateAccuracy(playerTimeline, expectedTimeline);
            // TODO: Extend this to allow for accuracy of each aspect to be analyzed

            return new AccuracyResultsDto()
            {
                NoteAccuracy = noteAccuracy
            };
        }
    }
}
