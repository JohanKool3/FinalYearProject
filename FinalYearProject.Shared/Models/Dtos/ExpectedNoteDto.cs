namespace FinalYearProject.Shared.Models.Dtos
{
    /// <summary>
    /// A Note Name that is expected to be present e.g. C4
    /// </summary>
    public class ExpectedNoteDto
    {
        public string Name { get; set; } = string.Empty;

        // TODO: Extend this to include more information such as articulation
    }
}