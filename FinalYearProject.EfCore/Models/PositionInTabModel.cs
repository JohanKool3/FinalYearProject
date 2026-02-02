namespace FinalYearProject.EfCore.Models
{
    public class PositionInTabModel
    {
        /// <summary>
        /// When this Bar Starts (in Seconds)
        /// </summary>
        public float StartTime { get; set; }

        /// <summary>
        /// When this Bar Ends (in Seconds)
        /// </summary>
        public float EndTime { get; set; }

        /// <summary>
        /// How long this Bar lasts (in Seconds)
        /// </summary>
        public float Length { get; set; }
    }
}