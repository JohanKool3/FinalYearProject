
using FinalYearProject.Shared.Interfaces;

namespace FinalYearProject.Accuracy.Analysis.Models
{
    public class AccuracySettings : ISetting
    {
        /// <summary>
        /// How Confident the program should be that a note was played to consider it "played".
        /// </summary>
        public float RequiredNoteConfidence { get; set; } = 0.1f;
    }
}
