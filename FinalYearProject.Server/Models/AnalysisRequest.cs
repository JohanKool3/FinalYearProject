using Microsoft.AspNetCore.Http;

namespace FinalYearProject.Server.Models
{
    /// <summary>
    /// Represents the body of a POST request for audio analysis.
    /// </summary>
    public class AnalysisRequest
    {
        //// TODO: Extend this to include additional properties such as:
        //// 1. UserToken: The Unique Identifier for the user making the request.

        /// <summary>
        /// The unique identifier for the analysis request.
        /// </summary>
        public required Guid Id { get; set; }

        /// <summary>
        /// The Unique Identifier for the piece being analyzed.
        /// </summary>
        public required Guid PieceId { get; set; }

        /// <summary>
        /// The Audio File being analyzed.
        /// </summary>
        public required IFormFile AudioFile { get; set; }
    }
}
