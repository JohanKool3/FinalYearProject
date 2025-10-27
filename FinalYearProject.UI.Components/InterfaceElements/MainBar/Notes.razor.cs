using FinalYearProject.UI.Components.Models.InterfaceElements.Bar;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.MainBar
{
    public partial class Notes
    {
        /// <summary>
        /// The Groups of Notes to be rendered
        /// </summary>
        [Parameter, EditorRequired]
        public List<NoteGroupInformation> NoteGroupsToDisplay { get; set; }

        /// <summary>
        /// The Total Area of the Notes Area
        /// </summary>
        [Parameter, EditorRequired]
        public int Width { get; set; }
    }
}