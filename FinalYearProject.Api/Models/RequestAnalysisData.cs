namespace FinalYearProject.Api.Models
{
    public class RequestAnalysisData
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public required Guid PieceId { get; set; }

        public required string FileName { get; set; }

        public required Stream AudioData { get; set; }
    }
}
