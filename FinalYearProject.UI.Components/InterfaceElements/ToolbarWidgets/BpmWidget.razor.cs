using FinalYearProject.Shared.Models;
using FinalYearProject.UI.Components.Services;
using Microsoft.AspNetCore.Components;

namespace FinalYearProject.UI.Components.InterfaceElements.ToolbarWidgets
{
    public partial class BpmWidget(UserSettings settings)
    {
        public UserSettings Settings { get; } = settings;
    }
}