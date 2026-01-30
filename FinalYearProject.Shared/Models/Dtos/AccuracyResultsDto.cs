namespace FinalYearProject.Shared.Models.Dtos
{
    /// <summary>
    /// Represents the response to an API POST request for accuracy analysis
    /// </summary>
    public class AccuracyResultsDto
    {
        /// <summary>
        /// Represents the User's Note Accuracy (from 0 to 1)
        /// </summary>
        public float NoteAccuracy { get; set; }
    }
}
