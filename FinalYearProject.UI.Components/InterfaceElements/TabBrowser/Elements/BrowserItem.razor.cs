using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.TabBrowser.Elements
{
    public partial class BrowserItem
    {
        /// <summary>
        /// Where this lies in the collection of results
        /// </summary>
        [Parameter, EditorRequired]
        public int ResultIndex { get; set; }

        /// <summary>
        /// The Name of the Piece
        /// </summary>
        [Parameter, EditorRequired]
        public required string Name { get; set; }

        /// <summary>
        /// Who made the piece
        /// </summary>
        [Parameter, EditorRequired]
        public required string Author { get; set; }

        /// <summary>
        /// Description of the piece
        /// </summary>
        [Parameter, EditorRequired]
        public required string Description { get; set; }

        /// <summary>
        /// Action to be performed when this item is clicked
        /// </summary>
        [Parameter, EditorRequired]
        public required Action OnClick { get; set; }

        
    }
}