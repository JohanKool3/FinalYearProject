using FinalYearProject.UI.Components.Models.Settings;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements
{
    public partial class PlaybackIndicator(TabRepresentationService representationService)
    {
        #region Parameters
        
        /// <summary>
        /// Where the Playback Indicator is positioned on the X axis
        /// </summary>
        [Parameter]
        public int XPosition { get; set; }

        /// <summary>
        /// Where the Playback Indicator is positioned on the Y axis
        /// </summary>
        [Parameter]
        public int YPosition { get; set; }

        #endregion

        public RepresentationSettings Settings { get; } = representationService.Settings;

        private int _width
            => Settings.PlaybackIndicator.Width;

        private int _height
            => Settings.PlaybackIndicator.Height;

        private string _color
            => Settings.PlaybackIndicator.Color;

        private bool _isVisible
            => false; // TODO: Pull this from the playback service
    }
}