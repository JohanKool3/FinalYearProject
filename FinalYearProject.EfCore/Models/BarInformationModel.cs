namespace FinalYearProject.EfCore.Models
{
    public class BarInformationModel
    {
        /// <summary>
        /// The Beats Per Minute of this Bar
        /// </summary>
        public required int Bpm { get; set; }

        /// <summary>
        /// The Time Signature of this Bar
        /// </summary>
        public required TimeSignatureModel TimeSignature { get; set; }

        /// <summary>
        /// Where this Bar is in the Tab
        /// </summary>
        public required PositionInTabModel Position { get; set; }
    }
}