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
        /// Action to be performed when this item is clicked
        /// </summary>
        [Parameter, EditorRequired]
        public required Action OnClick { get; set; }


    }
}