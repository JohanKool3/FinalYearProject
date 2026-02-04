using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.TabBrowser.Elements
{
    public partial class BrowserItem
    {

        /// <summary>
        /// The Name of the Piece
        /// </summary>
        [Parameter, EditorRequired]
        public required string Name { get; set; }

        /// <summary>
        /// The Unique Piece Identifier
        /// </summary>
        [Parameter, EditorRequired]
        public required Guid Id { get; set; }
    }
}