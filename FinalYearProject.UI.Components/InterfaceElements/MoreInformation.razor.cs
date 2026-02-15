using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements
{
    public partial class MoreInformation
    {

        /// <summary>
        /// Information Message
        /// </summary>
        [Parameter]
        public string Message { get; set; } = string.Empty;
    }
}