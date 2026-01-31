namespace FinalYearProject.Server.Models
{
    public class AnalysisRequestMetadata
    {
        /// <summary>
        /// The ID of the piece to be analyzed.
        /// </summary>
        public Guid PieceId { get; set; }

        // TODO: Extend this for additional information such as 
        // user id, timestamp, etc.
    }
}