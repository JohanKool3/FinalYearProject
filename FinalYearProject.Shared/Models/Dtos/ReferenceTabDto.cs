namespace FinalYearProject.Shared.Models.Dtos
{
    public class ReferenceTabDto
    {
        public List<NoteGroupDto> NoteGroups { get; set; } = [];

        /// <summary>
        /// The Beats Per Minute of the Reference Tab
        /// </summary>
        public int Bpm { get; set; }
    }
}
